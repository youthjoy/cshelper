using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Drawing;


namespace QX.Helper
{
    public class PDFHelper
    {
        private string _pdfSavePath;
        /// <summary>
        /// pdf文件保存地址
        /// </summary>
        public string PDFSavePath
        {
            get
            {
                if (string.IsNullOrEmpty(_pdfSavePath))
                {
                    return AppDomain.CurrentDomain.BaseDirectory + Guid.NewGuid().ToString() + ".pdf";
                }
                return _pdfSavePath;
            }
            set { _pdfSavePath = value; }
        }

        /// <summary>
        /// PDF生成(重载)
        /// </summary>
        /// <param name="pdfSavePath"></param>
        public  void MakePDF(string pdfSavePath, List<System.Drawing.Image> list) { this.PDFSavePath = pdfSavePath; MakePDF(list); }

        /// <summary>
        /// PDF生成
        /// </summary>
        public  void MakePDF(List<System.Drawing.Image> list)
        {
            Document document = new Document(PageSize.A3);//创建一个Document实例
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(PDFSavePath, FileMode.Create));//创建Writer实例

            document.Open();

            #region 写入一些数据，包括：作者、标题、摘要、关键词、创建者、生产者、创建时间、头信息

            document.AddAuthor("重齿风电");
            document.AddCreationDate();
            document.AddCreator("重齿风电");
            //document.AddHeader("QQ", "346163801");
            //document.AddHeader("Email", "hudonglin@126.com");
            document.AddKeywords("重齿风电");
            document.AddProducer();
            document.AddSubject("重齿风电");
            document.AddTitle("重齿风电");

            #endregion

            BaseFont baseFont = CreateChineseFont();

            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 22, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font fontUnderLine = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.UNDERLINE);
            iTextSharp.text.Font normalFont = new iTextSharp.text.Font(baseFont, 12);
            iTextSharp.text.Font normalRedFont = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL | iTextSharp.text.Font.BOLD, BaseColor.RED);
            //float titleLineHeight = 45f;
            float normalLineHeight = 25f;
            Paragraph pBlank = new Paragraph(" ", normalFont);
            pBlank.Leading = normalLineHeight;
            foreach (var im in list)
            {
                iTextSharp.text.Image jpeg = iTextSharp.text.Image.GetInstance(DoConvert(im,827,1169,80), BaseColor.WHITE);
                jpeg.Alignment = Element.ALIGN_CENTER;
                document.Add(jpeg);
            }

            document.Close();
            
        }

        /// <summary>
        /// 图片转换（裁剪并缩放）
        /// </summary>
        /// <param name="ASrcFileName">源文件名称</param>
        /// <param name="ADestFileName">目标文件名称</param>
        /// <param name="AWidth">转换后的宽度（像素）</param>
        /// <param name="AHeight">转换后的高度（像素）</param>
        /// <param name="AQuality">保存质量（取值在1-100之间）</param>
        public static System.Drawing.Image DoConvert(System.Drawing.Image ASrcFileName,int AWidth, int AHeight, int AQuality)
        {
            System.Drawing.Image ASrcImg = ASrcFileName;
            if (ASrcImg.Width <= AWidth && ASrcImg.Height <= AHeight)
            {//图片的高宽均小于目标高宽，直接保存
                return ASrcImg;
            }
            double ADestRate = AWidth * 1.0 / AHeight;
            double ASrcRate = ASrcImg.Width * 1.0 / ASrcImg.Height;
            //裁剪后的宽度
            double ACutWidth = ASrcRate > ADestRate ? (ASrcImg.Height * ADestRate) : ASrcImg.Width;
            //裁剪后的高度
            double ACutHeight = ASrcRate > ADestRate ? ASrcImg.Height : (ASrcImg.Width / ADestRate);
            //待裁剪的矩形区域，根据原图片的中心进行裁剪
            System.Drawing.Rectangle AFromRect = new System.Drawing.Rectangle(Convert.ToInt32((ASrcImg.Width - ACutWidth) / 2), Convert.ToInt32((ASrcImg.Height - ACutHeight) / 2), (int)ACutWidth, (int)ACutHeight);
            //目标矩形区域
            System.Drawing.Rectangle AToRect = new System.Drawing.Rectangle(0, 0, AWidth, AHeight);

            System.Drawing.Image ADestImg = new Bitmap(AWidth, AHeight);
            Graphics ADestGraph = Graphics.FromImage(ADestImg);
            ADestGraph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            ADestGraph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            ADestGraph.DrawImage(ASrcImg, AToRect, AFromRect, GraphicsUnit.Pixel);

            //获取系统image/jpeg编码信息
            System.Drawing.Imaging.ImageCodecInfo[] AInfos = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();
            System.Drawing.Imaging.ImageCodecInfo AInfo = null;
            foreach (System.Drawing.Imaging.ImageCodecInfo i in AInfos)
            {
                if (i.MimeType == "image/jpeg")
                {
                    AInfo = i;
                    break;
                }
            }
            //设置转换后图片质量参数
            System.Drawing.Imaging.EncoderParameters AParams = new System.Drawing.Imaging.EncoderParameters(1);
            AParams.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality,(long)AQuality);
            //保存
            return ADestImg;
        }

        #region 文档元素生成区域

        /// <summary>
        /// 生成段落文本
        /// </summary>
        /// <param name="txt">文本</param>
        /// <param name="txtFont">字体</param>
        /// <param name="lineHeight">行高</param>
        /// <returns>段落文本</returns>
        static Paragraph GetPTxt(string txt, iTextSharp.text.Font txtFont, float lineHeight)
        {
            Paragraph p = new Paragraph(lineHeight, txt, txtFont);
            return p;
        }

        /// <summary>
        /// 生成段落文本
        /// </summary>
        /// <param name="txt">文本</param>
        /// <param name="txtFont">字体</param>
        /// <param name="lineHeight">行高</param>
        /// <param name="elementAlign">对齐方式</param>
        /// <returns>段落文本</returns>
        static Paragraph GetPTxt(string txt, iTextSharp.text.Font txtFont, float lineHeight, int elementAlign)
        {
            Paragraph p = new Paragraph(lineHeight, txt, txtFont);
            p.Alignment = elementAlign;
            return p;
        }

        /// <summary>
        /// 生成段落文本
        /// </summary>
        /// <param name="chnkArr">Chunk数组</param>
        /// <param name="lineHeight">行高</param>
        /// <returns>段落文本</returns>
        static Paragraph GetPTxt(Chunk[] chnkArr, float lineHeight)
        {
            if (chnkArr == null || chnkArr.Length == 0) { return new Paragraph(""); }
            Paragraph p = new Paragraph();
            foreach (Chunk chnkTxt in chnkArr) { p.Add(chnkTxt); }
            p.Leading = lineHeight;
            return p;
        }

        /// <summary>
        /// 创建Table行
        /// </summary>
        /// <param name="txt">文本</param>
        /// <param name="txtFont">字体</param>
        /// <param name="align">对齐方式</param>
        /// <param name="colSpan">跨行数</param>
        /// <param name="padTop">顶部padding</param>
        /// <param name="padBottom">底部padding</param>
        /// <returns>Table行</returns>
        static PdfPCell CreateCell(string txt, iTextSharp.text.Font txtFont, int align, int colSpan, float padTop, float padBottom)
        {
            PdfPCell cell = new PdfPCell(new Phrase(txt, txtFont));
            if (padTop > 0) { cell.PaddingTop = padTop; }
            if (padBottom > 0) { cell.PaddingBottom = padBottom; }
            if (colSpan > 0) { cell.Colspan = colSpan; }
            cell.HorizontalAlignment = align;

            return cell;
        }

        /// <summary>
        /// 创建Table行(RowSpan)
        /// </summary>
        /// <param name="txt">文本</param>
        /// <param name="txtFont">字体</param>
        /// <returns>Table行(RowSpan)</returns>
        static PdfPCell CreateRowSpanCell(string txt, iTextSharp.text.Font txtFont)
        {
            PdfPCell cell = new PdfPCell(new Phrase(60f, txt, txtFont));
            cell.Rowspan = 6;
            cell.PaddingTop = 6f;
            cell.PaddingBottom = 6f;
            cell.PaddingLeft = 10f;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            return cell;
        }

        /// <summary>
        /// 创建Table行
        /// </summary>
        /// <param name="txt">文本</param>
        /// <param name="txtFont">字体</param>
        /// <param name="colSpan">跨行数</param>
        /// <param name="padTop">顶部padding</param>
        /// <param name="padBottom">底部padding</param>
        /// <param name="bgColor">背景色</param>
        /// <returns>Table行</returns>
        static PdfPCell CreateCellHeader(string txt, iTextSharp.text.Font txtFont, int colSpan, float padTop, float padBottom, BaseColor bgColor)
        {
            PdfPCell cell = new PdfPCell(new Phrase(txt, txtFont));
            if (padTop > 0) { cell.PaddingTop = padTop; }
            if (padBottom > 0) { cell.PaddingBottom = padBottom; }
            if (colSpan > 0) { cell.Colspan = colSpan; }
            cell.HorizontalAlignment = Element.ALIGN_CENTER; //0=Left, 1=Centre, 2=Right
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = bgColor;

            return cell;
        }

        /// <summary>
        /// 创建表格(PdfPTable)
        /// </summary>
        /// <returns></returns>
        static PdfPTable CreateTable()
        {
            PdfPTable table = new PdfPTable(6);
            table.TotalWidth = 470f;
            table.LockedWidth = true;
            table.HorizontalAlignment = 1;

            float[] widths = new float[] { 95f, 95f, 55f, 40f, 95f, 95f };
            table.SetWidths(widths);

            BaseFont baseFont = CreateChineseFont();
            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font normalFont = new iTextSharp.text.Font(baseFont, 10), normalBoldFont = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font normalRedFont = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL | iTextSharp.text.Font.BOLD, BaseColor.RED);
            float padding = 6f; BaseColor bgColor = new BaseColor(153, 204, 255);

            table.AddCell(CreateCellHeader("扫描文档", titleFont, 6, 8f, 8f, bgColor));

            table.AddCell(CreateCell("姓名", normalBoldFont, 1, 0, padding, padding));
            table.AddCell(CreateCell("$uName$", normalFont, 0, 5, padding, padding));

            table.AddCell(CreateCell("单位", normalBoldFont, 1, 0, padding, padding));
            table.AddCell(CreateCell("$cName$", normalFont, 0, 5, padding, padding));

            table.AddCell(CreateCell("联系电话", normalBoldFont, 1, 0, padding, padding));
            table.AddCell(CreateCell("$uTel$", normalFont, 0, 2, padding, padding));
            table.AddCell(CreateCell("职务", normalBoldFont, 1, 0, padding, padding));
            table.AddCell(CreateCell("$uHeadShip$", normalFont, 0, 2, padding, padding));

            table.AddCell(CreateCell("VIP编号", normalBoldFont, 1, 0, padding, padding));
            table.AddCell(CreateCell("SZRFID-VIP-0001", normalRedFont, 0, 5, padding, padding));

            table.AddCell(CreateRowSpanCell("其它参观人员 （如贵公司新增其它参观人员请在此栏填写姓名和联系方式，否则必须在现场排队登记）", normalFont));

            table.AddCell(CreateCellHeader("姓名", normalBoldFont, 0, padding, padding, bgColor));
            table.AddCell(CreateCellHeader("职务", normalBoldFont, 2, padding, padding, bgColor));
            table.AddCell(CreateCellHeader("联系电话", normalBoldFont, 0, padding, padding, bgColor));
            table.AddCell(CreateCellHeader("电子邮件", normalBoldFont, 0, padding, padding, bgColor));

            for (int i = 0; i < 5; i++)
            {
                table.AddCell(CreateCell("  ", normalFont, 0, 0, padding, padding));
                table.AddCell(CreateCell("  ", normalFont, 0, 2, padding, padding));
                table.AddCell(CreateCell("  ", normalFont, 0, 0, padding, padding));
                table.AddCell(CreateCell("  ", normalFont, 0, 0, padding, padding));
            }

            return table;
        }

        #endregion

        #region 公共函数区域

        /// <summary>
        /// 创建中文字体(实现中文)
        /// </summary>
        /// <returns></returns>
        public static BaseFont CreateChineseFont()
        {
            BaseFont.AddToResourceSearch(GlabolConfiguration.BaseDirectory+"\\"+"iTextAsian.dll");
            BaseFont.AddToResourceSearch(GlabolConfiguration.BaseDirectory + "\\" + "iTextAsianCmaps.dll"); //"STSong-Light", "UniGB-UCS2-H", 
            BaseFont baseFT = BaseFont.CreateFont("STSong-Light", "UniGB-UCS2-H", BaseFont.EMBEDDED);

            //iTextSharp.text.Font font = new iTextSharp.text.Font(baseFT);
            return baseFT;
        }

        #endregion
    }
}
