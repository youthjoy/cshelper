using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WIA;
using System.IO;
using System.Configuration;
using System.Xml;
using System.Drawing;
using System.Windows.Forms;

namespace QX.Helper
{

    #region 数据常量
    class WIA_DPS_DOCUMENT_HANDLING_SELECT
    {
        public const uint FEEDER = 0x00000001;
        public const uint FLATBED = 0x00000002;
        public const uint Duplex = 0x00000004;
    }

    class WIA_DPS_DOCUMENT_HANDLING_STATUS
    {
        public const uint FEED_READY = 0x00000001;
    }

    class WIA_PROPERTIES
    {
        public const uint WIA_RESERVED_FOR_NEW_PROPS = 1024;
        public const uint WIA_DIP_FIRST = 2;
        public const uint WIA_DPA_FIRST = WIA_DIP_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
        public const uint WIA_DPC_FIRST = WIA_DPA_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
        //
        // Scanner only device properties (DPS)
        //
        public const uint WIA_DPS_FIRST = WIA_DPC_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
        public const uint WIA_DPS_DOCUMENT_HANDLING_STATUS = WIA_DPS_FIRST + 13;
        public const uint WIA_DPS_DOCUMENT_HANDLING_SELECT = WIA_DPS_FIRST + 14;
    }

    class WIA_ERRORS
    {
        public const uint BASE_VAL_WIA_ERROR = 0x80210000;
        public const uint WIA_ERROR_PAPER_EMPTY = BASE_VAL_WIA_ERROR + 3;
    }
    #endregion

    public class ScanHelper
    {
        #region 图片类型

        const string wiaFormatBMP = "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}";
        const string wiaFormatPNG = "{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}";
        const string wiaFormatGIF = "{B96B3CB0-0728-11D3-9D7B-0000F81EF32E}";
        const string wiaFormatJPEG = "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}";
        const string wiaFormatTIFF = "{B96B3CB1-0728-11D3-9D7B-0000F81EF32E}";

        #endregion

        public ScanHelper()
        {
            DefaultScaner = XmlHelper.GetConfig("DefaultScan");
            LocalSavePath = XmlHelper.GetConfig("LocalPath");
        }

        private List<System.Drawing.Image> imgs = new List<System.Drawing.Image>();
        private static string DefaultScaner = string.Empty;

        private static string LocalSavePath = string.Empty;

        public List<Image> StartScan()
        {
            imgs = null;
            imgs = new List<Image>();

            //var tempPath=Path.GetTempPath();
            

            ImageFile imageFile;
            DeviceManagerClass manager = new DeviceManagerClass();
            Device WiaDev = null;
            CommonDialogClass devCdc = new WIA.CommonDialogClass();
            if (string.IsNullOrEmpty(DefaultScaner))
            {
                WiaDev = devCdc.ShowSelectDevice(WiaDeviceType.ScannerDeviceType, true, false);
                if (WiaDev != null)
                {
                    XmlHelper.UpdateConfig("DefaultScan", WiaDev.DeviceID);
                }
            }
            else
            {
                foreach (DeviceInfo info in manager.DeviceInfos)
                {
                    if (info.Type != WiaDeviceType.ScannerDeviceType) continue;
                    if (info.DeviceID == DefaultScaner)
                    {

                        WiaDev = info.Connect();
                        break;
                    }
                }
            }



            if (WiaDev == null)
            {
                try
                {
                    WiaDev = devCdc.ShowSelectDevice(WiaDeviceType.ScannerDeviceType, true, false);
                    if (WiaDev != null)
                    {
                        XmlHelper.UpdateConfig("DefaultScan", WiaDev.DeviceID); ;
                    }
                    else
                    {
                        throw new Exception("请确认扫描仪是否正常连接！");
                        //MessageBox.Show("请确认扫描仪是否正常连接！");
                        //return null;
                    }
                }
                catch
                {
                    return null;
                }

            }



            Property documentHandlingSelect1 = null;

            foreach (Property prop in WiaDev.Properties)
            {
                if (prop.PropertyID == WIA_PROPERTIES.WIA_DPS_DOCUMENT_HANDLING_SELECT)
                {
                    documentHandlingSelect1 = prop;
                    object obj = new object();
                    //obj = (WIA_DPS_DOCUMENT_HANDLING_SELECT.FEEDER);

                    obj = (WIA_DPS_DOCUMENT_HANDLING_SELECT.FEEDER);
                    documentHandlingSelect1.set_Value(ref obj);

                }
                //else if (prop.PropertyID == 3013)
                //{
                //    object val = 1;
                //    prop.set_Value(ref val);
                //}
                //Pages
                else if (prop.PropertyID == 3096)
                {
                    object val = 1;
                    prop.set_Value(ref val);
                }
                else if (prop.PropertyID == WIA_PROPERTIES.WIA_DPS_DOCUMENT_HANDLING_STATUS)
                {
                    documentHandlingSelect1 = prop;

                }
            }
            int dpi = 200;

            Item item = WiaDev.Items[1];
            foreach (WIA.Property itemProperty in item.Properties)
            {
                //IProperty tempProperty;
                Object tempNewProperty;

                if (itemProperty.Name.Equals("Horizontal Resolution"))
                {
                    tempNewProperty = dpi;
                    ((IProperty)itemProperty).set_Value(ref tempNewProperty);
                }
                else if (itemProperty.Name.Equals("Vertical Resolution"))
                {
                    tempNewProperty = dpi;
                    ((IProperty)itemProperty).set_Value(ref tempNewProperty);
                }//Colour intent
                else if (itemProperty.PropertyID == 6146)
                {
                    object val2 = 4;
                    ((IProperty)itemProperty).set_Value(ref val2);
                }
                //else if (itemProperty.PropertyID == 4110)
                //{
                //    object val2 = 1100;
                //    ((IProperty)itemProperty).set_Value(ref val2);
                //}
                //else if (itemProperty.PropertyID == 4120)
                //{
                //    object val1 = 2;
                //    ((IProperty)itemProperty).set_Value(ref val1);
                //}
                //else if (itemProperty.PropertyID == 4102)
                //{
                //    object val1 = 1;

                //    ((IProperty)itemProperty).set_Value(ref val1);
                //}
                //4104 _ Bits Per Pixel
                //else if (itemProperty.PropertyID == 4112)
                //{
                //    object val1 = 2481;

                //    ((IProperty)itemProperty).set_Value(ref val1);
                //}
                else if (itemProperty.Name.Equals("Horizontal Extent"))
                {
                    tempNewProperty = 8.27 * dpi;
                    ((IProperty)itemProperty).set_Value(ref tempNewProperty);
                }
                else if (itemProperty.Name.Equals("Vertical Extent"))
                {
                    tempNewProperty = 11.69 * dpi;
                    ((IProperty)itemProperty).set_Value(ref tempNewProperty);
                }
            }


            CommonDialogClass cdc = new WIA.CommonDialogClass();
            try
            {
                imageFile = cdc.ShowTransfer(item,wiaFormatJPEG, false) as ImageFile;
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                imageFile = null;

            }

            while (imageFile != null)
            {

                var buffer = imageFile.FileData.get_BinaryData() as byte[];
                //imageFile.SaveFile(Path.Combine(LocalSavePath, DateTime.Now.Millisecond + ".bmp"));
                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(buffer, 0, buffer.Length);
                    imgs.Add(System.Drawing.Image.FromStream(ms));
                    ms.Close();
                    ms.Dispose();
                }
                buffer = null;
                imageFile = null;
                //MethodInvoker mm = delegate
                //{
                //    try
                //    {
                //        var tmp = Path.GetTempPath();
                //        foreach (string d in Directory.GetFileSystemEntries(tmp))
                //        {
                //            if (d.Contains("img") && File.Exists(d))
                //            {
                //                FileInfo fi = new FileInfo(d);
                //                if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                //                    fi.Attributes = FileAttributes.Normal;
                //                File.Delete(d);//直接删除其中的文件  
                //            }
                //        }
                //    }
                //    catch (Exception ex)
                //    {

                //    }
                //};

                //mm.BeginInvoke(null, null);
                try
                {
                    imageFile = cdc.ShowTransfer(item, wiaFormatJPEG, false) as ImageFile;
                }
                catch (Exception ex)
                {
                    
                    continue;
                    //return imgs;
                    //throw new Exception(ex.Message);
                }
            }
            return imgs.ToList();
        }


        public List<Image> StartScan(int mode)
        {
            imgs = null;
            imgs = new List<Image>();
            ImageFile imageFile;
            DeviceManagerClass manager = new DeviceManagerClass();
            Device WiaDev = null;
            CommonDialogClass devCdc = new WIA.CommonDialogClass();
            if (string.IsNullOrEmpty(DefaultScaner))
            {
                WiaDev = devCdc.ShowSelectDevice(WiaDeviceType.ScannerDeviceType, true, false);
                if (WiaDev != null)
                {
                    XmlHelper.UpdateConfig("DefaultScan", WiaDev.DeviceID);
                }
            }
            else
            {
                foreach (DeviceInfo info in manager.DeviceInfos)
                {
                    if (info.Type != WiaDeviceType.ScannerDeviceType) continue;
                    if (info.DeviceID == DefaultScaner)
                    {

                        WiaDev = info.Connect();
                        break;
                    }
                }
            }



            if (WiaDev == null)
            {
                WiaDev = devCdc.ShowSelectDevice(WiaDeviceType.ScannerDeviceType, true, false);
                if (WiaDev != null)
                {
                    XmlHelper.UpdateConfig("DefaultScan", WiaDev.DeviceID); ;
                }
                else
                {
                    //throw new Exception("请确认扫描仪是否正常连接！");
                    MessageBox.Show("请确认扫描仪是否正常连接！");
                }

            }



            Property documentHandlingSelect1 = null;

            foreach (Property prop in WiaDev.Properties)
            {
                if (prop.PropertyID == WIA_PROPERTIES.WIA_DPS_DOCUMENT_HANDLING_SELECT)
                {
                    documentHandlingSelect1 = prop;
                    object obj = new object();
                    //if (mode == 1)
                    //{
                        obj = (WIA_DPS_DOCUMENT_HANDLING_SELECT.Duplex);
                        documentHandlingSelect1.set_Value(ref obj);
                    //}
                    //else
                    //{
                    //    obj = (WIA_DPS_DOCUMENT_HANDLING_SELECT.FEEDER);
                    //    documentHandlingSelect1.set_Value(ref obj);
                    //}
                    //obj = (WIA_DPS_DOCUMENT_HANDLING_SELECT.FEEDER);
                    obj = WIA_DPS_DOCUMENT_HANDLING_SELECT.Duplex;
                    documentHandlingSelect1.set_Value(ref obj);

                }
                //else if (prop.PropertyID == 3013)
                //{
                //    object val = 1;
                //    prop.set_Value(ref val);
                //}
                //Pages
                else if (prop.PropertyID == 3096)
                {
                    object val = 1;
                    prop.set_Value(ref val);
                }
                else if (prop.PropertyID == WIA_PROPERTIES.WIA_DPS_DOCUMENT_HANDLING_STATUS)
                {
                    documentHandlingSelect1 = prop;

                }
            }
            int dpi = 300;
            Item item = WiaDev.Items[1];
            foreach (WIA.Property itemProperty in item.Properties)
            {
                //IProperty tempProperty;
                Object tempNewProperty;

                if (itemProperty.Name.Equals("Horizontal Resolution"))
                {
                    tempNewProperty = dpi;
                    ((IProperty)itemProperty).set_Value(ref tempNewProperty);
                }
                else if (itemProperty.Name.Equals("Vertical Resolution"))
                {
                    tempNewProperty = dpi;
                    ((IProperty)itemProperty).set_Value(ref tempNewProperty);
                }
                else if (itemProperty.Name.Equals("Horizontal Extent"))
                {
                    tempNewProperty = 8.27 * dpi;
                    ((IProperty)itemProperty).set_Value(ref tempNewProperty);
                }
                else if (itemProperty.Name.Equals("Vertical Extent"))
                {
                    tempNewProperty = 11.69 * dpi;
                    ((IProperty)itemProperty).set_Value(ref tempNewProperty);
                }
                //else if (itemProperty.Name.Equals("Horizontal Extent"))
                //{
                //    //tempNewProperty = 619;
                //    //((IProperty)itemProperty).set_Value(ref tempNewProperty);
                //}
                //else if (itemProperty.Name.Equals("Vertical Extent"))
                //{
                //    //tempNewProperty = 876;
                //    //((IProperty)itemProperty).set_Value(ref tempNewProperty);
                //}
            }


            CommonDialogClass cdc = new WIA.CommonDialogClass();
            try
            {
                imageFile = cdc.ShowTransfer(item, wiaFormatJPEG, false) as ImageFile;
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                imageFile = null;

            }

            while (imageFile != null)
            {

                var buffer = imageFile.FileData.get_BinaryData() as byte[];
                
                //imageFile.SaveFile(Path.Combine(LocalSavePath, DateTime.Now.Millisecond + ".jpg"));
                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(buffer, 0, buffer.Length);
                    imgs.Add(System.Drawing.Image.FromStream(ms));
                    ms.Close();
                    ms.Dispose();
                }
                buffer = null;

                imageFile = null;

                //MethodInvoker mm = delegate
                //{
                //    try
                //    {
                //        var tmp = Path.GetTempPath();
                //        foreach (string d in Directory.GetFileSystemEntries(tmp))
                //        {
                //            if (d.Contains("img") && File.Exists(d))
                //            {
                //                FileInfo fi = new FileInfo(d);
                //                if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                //                    fi.Attributes = FileAttributes.Normal;
                //                File.Delete(d);//直接删除其中的文件  
                //            }
                //        }
                //    }
                //    catch (Exception ex)
                //    {

                //    }
                //};

                //mm.BeginInvoke(null, null);

                try
                {
                    imageFile = cdc.ShowTransfer(item, wiaFormatJPEG, false) as ImageFile;
                }
                catch (Exception ex)
                {
                    //return imgs;
                    //throw new Exception(ex.Message);
                    continue;
                }
            }
            return imgs;
        }
    }
}
