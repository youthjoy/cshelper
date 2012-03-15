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
    public class ScanAuto
    {
         #region 图片类型

        const string wiaFormatBMP = "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}";
        const string wiaFormatPNG = "{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}";
        const string wiaFormatGIF = "{B96B3CB0-0728-11D3-9D7B-0000F81EF32E}";
        const string wiaFormatJPEG = "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}";
        const string wiaFormatTIFF = "{B96B3CB1-0728-11D3-9D7B-0000F81EF32E}";

        #endregion

        public ScanAuto()
        {
            DefaultScaner = XmlHelper.GetConfig("DefaultScan");
            LocalSavePath = XmlHelper.GetConfig("LocalPath");
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
            manager.RegisterEvent("{0C5E2143-FD9B-490B-9AD5-7637A403566B}", WiaDev.DeviceID);

            manager.OnEvent += (eventID, deviceID, itemID) =>
            {
                Item item = WiaDev.Items[1];

                CommonDialogClass cdc = new WIA.CommonDialogClass();
                ImageFile imageFile = cdc.ShowTransfer(item,
                "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}",
                true) as ImageFile;

                if (imageFile != null)
                {
                    var buffer = imageFile.FileData.get_BinaryData() as byte[];
                    //imageFile.SaveFile(Path.Combine(LocalSavePath, DateTime.Now.Millisecond + ".jpg"));
                    using (MemoryStream ms = new MemoryStream())
                    {
                        ms.Write(buffer, 0, buffer.Length);
                        imgs.Add(System.Drawing.Image.FromStream(ms));
                    }
                }
            };
        }



        public List<System.Drawing.Image> imgs = new List<System.Drawing.Image>();
        private static string DefaultScaner = string.Empty;

        private static string LocalSavePath = string.Empty;

        public List<Image> StartScan()
        {
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

            Item item = WiaDev.Items[1];
            foreach (WIA.Property itemProperty in item.Properties)
            {
                //IProperty tempProperty;
                Object tempNewProperty;

                if (itemProperty.Name.Equals("Horizontal Resolution"))
                {
                    tempNewProperty = 100;
                    ((IProperty)itemProperty).set_Value(ref tempNewProperty);
                }
                else if (itemProperty.Name.Equals("Vertical Resolution"))
                {
                    tempNewProperty = 100;
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

                }
                imageFile = null;

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
            return imgs;
        }


        public List<Image> StartScan(int mode)
        {
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

            Item item = WiaDev.Items[1];
            foreach (WIA.Property itemProperty in item.Properties)
            {
                //IProperty tempProperty;
                Object tempNewProperty;

                if (itemProperty.Name.Equals("Horizontal Resolution"))
                {
                    tempNewProperty = 100;
                    ((IProperty)itemProperty).set_Value(ref tempNewProperty);
                }
                else if (itemProperty.Name.Equals("Vertical Resolution"))
                {
                    tempNewProperty = 100;
                    ((IProperty)itemProperty).set_Value(ref tempNewProperty);
                }//4104 _ Bits Per Pixel
                else if (itemProperty.PropertyID == 4104)
                {
                    object val1 = 24;
                    ((IProperty)itemProperty).set_Value(ref val1);
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

                }
                imageFile = null;

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
