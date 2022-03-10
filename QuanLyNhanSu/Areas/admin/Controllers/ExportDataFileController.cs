﻿using System;
using System.Web;
//using cExcel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyNhanSu.Areas.admin.Controllers;

namespace QuanLyNhanSu.Areas.admin
{
    public class ExportDataFileController : AuthorController
    {
        public void XuatFileExel(GridView gv, HttpResponseWrapper response, String fileName)
        {
            response.ClearContent();
            response.Buffer = true;
            String headerValue = "attachment;filename=" + fileName + ".xls";
            response.AddHeader("content-disposition", headerValue);
            response.ContentType = "application/excel";
            // Mã hóa UTF8
            response.ContentEncoding = System.Text.Encoding.UTF8;
            response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());

            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);

            gv.RenderControl(objHtmlTextWriter);
            response.Output.Write(objStringWriter.ToString());
            response.Flush();
            response.End();

        }
    }
}