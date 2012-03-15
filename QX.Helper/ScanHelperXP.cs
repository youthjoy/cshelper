using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIALib;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
namespace QX.Helper
{
    public class ScanHelperXP
    {

        #region 图片类型

        const string wiaFormatBMP = "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}";
        const string wiaFormatPNG = "{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}";
        const string wiaFormatGIF = "{B96B3CB0-0728-11D3-9D7B-0000F81EF32E}";
        const string wiaFormatJPEG = "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}";
        const string wiaFormatTIFF = "{B96B3CB1-0728-11D3-9D7B-0000F81EF32E}";

        #endregion

        public ScanHelperXP()
        {
            DefaultScaner = XmlHelper.GetConfig("DefaultScan");
            LocalSavePath = XmlHelper.GetConfig("LocalPath");
        }

        private List<System.Drawing.Image> imgs = new List<System.Drawing.Image>();
        private static string DefaultScaner = string.Empty;

        private static string LocalSavePath = string.Empty;

        WiaClass wiaManager = null;		// WIA manager COM object
        CollectionClass wiaDevs = null;		// WIA devices collection COM object
        ItemClass wiaRoot = null;		// WIA root device COM object
        CollectionClass wiaPics = null;		// WIA collection COM object
        ItemClass wiaItem = null;		// WIA image COM object

        public List<Image> StartScan()
        {

            //return null;
            wiaManager = new WiaClass();

            wiaDevs = wiaManager.Devices as CollectionClass;

            //if (string.IsNullOrEmpty(DefaultScaner))
            //{

                object selectUsingUI = System.Reflection.Missing.Value;			// = Nothing
                wiaRoot = (ItemClass)wiaManager.Create(ref selectUsingUI);	// let user select device

                if (wiaRoot != null)
                {
                    string selectId = wiaRoot.GetPropById((WiaItemPropertyId)WiaDeviceInfoPropertyId.DeviceInfoDevId) as string;
                    XmlHelper.UpdateConfig("DefaultScan", selectId);
                }
            //}
            else
            {
                foreach (object info in (wiaManager.Devices as CollectionClass))
                {
                    //string selectId = wiaRoot.GetPropById((WiaItemPropertyId)WiaDeviceInfoPropertyId.DeviceInfoDevId) as string;
                    //if (selectId == DefaultScaner)
                    //{

                    //    wiaRoot = (ItemClass)info.Create();
                    //    break;
                    //}
                }
            }

            try
            {
                //wiaManager = new WiaClass();		// create COM instance of WIA manager

                //wiaDevs = wiaManager.Devices as CollectionClass;			// call Wia.Devices to get all devices



                // this call shows the common WIA dialog to let the user select a picture:
                //wiaPics = wiaRoot.GetItemsFromUI(WiaFlag.SingleImage, WiaIntent.ImageTypeColor) as CollectionClass;
                //if (wiaPics == null)
                //{
                //    return null;
                //}



                //string imageFileName = string.Empty;
                //bool takeFirst = true;						// this sample uses only one single picture
                //foreach (object wiaObj in wiaPics)			// enumerate all the pictures the user selected
                //{
                //if (takeFirst)
                //{
                string imageFileName = string.Empty;
                ItemClass wiaObj =(ItemClass) wiaRoot.TakePicture();
             
                //wiaItem = (ItemClass)Marshal.CreateWrapperOfType(wiaObj, typeof(ItemClass));
                imageFileName = Path.GetTempFileName();				// create temporary file for image
                Cursor.Current = Cursors.WaitCursor;				// could take some time
                //this.Refresh();
                //wiaRoot.TakePicture();
                wiaObj.Transfer(imageFileName, false);			// transfer picture to our temporary file
                Image img = Image.FromFile(imageFileName);	// create Image instance from file
                //takeFirst = false;									// first and only one done.
                imgs.Add(img);

                //}
                //    Marshal.ReleaseComObject(wiaObj);					// release enumerated COM object
                //}
            }
            catch (Exception ee)
            {
                //MessageBox.Show(this, "Acquire from WIA Imaging failed\r\n" + ee.Message, "WIA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //Application.Exit();
            }
            finally
            {
                if (wiaItem != null)
                    Marshal.ReleaseComObject(wiaItem);		// release WIA image COM object
                if (wiaPics != null)
                    Marshal.ReleaseComObject(wiaPics);		// release WIA collection COM object
                if (wiaRoot != null)
                    Marshal.ReleaseComObject(wiaRoot);		// release WIA root device COM object
                if (wiaDevs != null)
                    Marshal.ReleaseComObject(wiaDevs);		// release WIA devices collection COM object
                if (wiaManager != null)
                    Marshal.ReleaseComObject(wiaManager);		// release WIA manager COM object
                Cursor.Current = Cursors.Default;				// restore cursor
            }


            return imgs;
            //    ImageFile imageFile;
            //    DeviceManagerClass manager = new DeviceManagerClass();
            //    Device WiaDev = null;
            //    CommonDialogClass devCdc = new WIA.CommonDialogClass();
            //    if (string.IsNullOrEmpty(DefaultScaner))
            //    {
            //        WiaDev = devCdc.ShowSelectDevice(WiaDeviceType.ScannerDeviceType, true, false);
            //        if (WiaDev != null)
            //        {
            //            XmlHelper.UpdateConfig("DefaultScan", WiaDev.DeviceID);
            //        }
            //    }
            //    else
            //    {
            //        foreach (DeviceInfo info in manager.DeviceInfos)
            //        {
            //            if (info.Type != WiaDeviceType.ScannerDeviceType) continue;
            //            if (info.DeviceID == DefaultScaner)
            //            {

            //                WiaDev = info.Connect();
            //                break;
            //            }
            //        }
            //    }



            //    if (WiaDev == null)
            //    {
            //        WiaDev = devCdc.ShowSelectDevice(WiaDeviceType.ScannerDeviceType, true, false);
            //        if (WiaDev != null)
            //        {
            //            XmlHelper.UpdateConfig("DefaultScan", WiaDev.DeviceID); ;
            //        }
            //        else
            //        {
            //            throw new Exception("请确认扫描仪是否正常连接！");
            //        }

            //    }



            //    Property documentHandlingSelect1 = null;

            //    foreach (Property prop in WiaDev.Properties)
            //    {
            //        if (prop.PropertyID == WIA_PROPERTIES.WIA_DPS_DOCUMENT_HANDLING_SELECT)
            //        {
            //            documentHandlingSelect1 = prop;
            //            object obj = new object();
            //            obj = (WIA_DPS_DOCUMENT_HANDLING_SELECT.FEEDER);
            //            documentHandlingSelect1.set_Value(ref obj);

            //        }
            //        else if (prop.PropertyID == 3013)
            //        {
            //            object val = 1;
            //            prop.set_Value(ref val);
            //        }
            //        //Pages
            //        else if (prop.PropertyID == 3096)
            //        {
            //            object val = 1;
            //            prop.set_Value(ref val);
            //        }
            //        else if (prop.PropertyID == WIA_PROPERTIES.WIA_DPS_DOCUMENT_HANDLING_STATUS)
            //        {
            //            documentHandlingSelect1 = prop;

            //        }
            //    }

            //    Item item = WiaDev.Items[1];
            //    foreach (WIA.Property itemProperty in item.Properties)
            //    {
            //        //IProperty tempProperty;
            //        Object tempNewProperty;

            //        if (itemProperty.Name.Equals("Horizontal Resolution"))
            //        {
            //            tempNewProperty = 100;
            //            ((IProperty)itemProperty).set_Value(ref tempNewProperty);
            //        }
            //        else if (itemProperty.Name.Equals("Vertical Resolution"))
            //        {
            //            tempNewProperty = 100;
            //            ((IProperty)itemProperty).set_Value(ref tempNewProperty);
            //        }
            //        //else if (itemProperty.Name.Equals("Horizontal Extent"))
            //        //{
            //        //    //tempNewProperty = 619;
            //        //    //((IProperty)itemProperty).set_Value(ref tempNewProperty);
            //        //}
            //        //else if (itemProperty.Name.Equals("Vertical Extent"))
            //        //{
            //        //    //tempNewProperty = 876;
            //        //    //((IProperty)itemProperty).set_Value(ref tempNewProperty);
            //        //}
            //    }


            //    CommonDialogClass cdc = new WIA.CommonDialogClass();
            //    try
            //    {
            //        imageFile = cdc.ShowTransfer(item, wiaFormatJPEG, false) as ImageFile;
            //    }
            //    catch (System.Runtime.InteropServices.COMException ex)
            //    {
            //        imageFile = null;

            //    }

            //    while (imageFile != null)
            //    {
            //        var buffer = imageFile.FileData.get_BinaryData() as byte[];
            //        imageFile.SaveFile(Path.Combine(LocalSavePath, DateTime.Now.Millisecond + ".jpg"));
            //        using (MemoryStream ms = new MemoryStream())
            //        {
            //            ms.Write(buffer, 0, buffer.Length);
            //            imgs.Add(System.Drawing.Image.FromStream(ms));

            //        }
            //        imageFile = null;

            //        try
            //        {
            //            imageFile = cdc.ShowTransfer(item, wiaFormatJPEG, false) as ImageFile;
            //        }
            //        catch (Exception ex)
            //        {
            //            return imgs;
            //            throw new Exception(ex.Message);
            //        }
            //    }
            //    return imgs;
            //}

        }
    }
}
