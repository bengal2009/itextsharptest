using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
public partial class Itxt5 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WebClient wc = new WebClient();
        var myUniqueFileName = string.Format(@"{0}.pdf", DateTime.Now.Ticks);
        //string htmlText = wc.DownloadString("http://localhost/web1/Preview.html");
        string htmlText = wc.DownloadString("http://localhost/web1/PDFExample.html");
        //if Strin9g.IsNullOrEmpty()
        htmlText = ChgHtml(htmlText);


        byte[] pdfFile = this.ConvertHtmlTextToPDF(htmlText);
        //FileStream fs = new FileStream("d:\\test\\Chapter1_Example2.pdf", FileMode.Create, FileAccess.Write, FileShare.None);

        //fs.Close();
        //File.WriteAllBytes("d:\\test\\Chapter1_Example2.pdf", pdfFile);
        //C:\inetpub\wwwroot\web1\download

        //FileSystem.MkDir("C:\\inetpub\\wwwroot\\web1\\download\\");
        //Directory.CreateDirectory("C:\\inetpub\\wwwroot\\web1\\download\\");
        File.WriteAllBytes("C:\\inetpub\\wwwroot\\web1\\download\\"+ myUniqueFileName, pdfFile);
        Response.Write("ok");

        /*  Response.ContentType = "application/octet-stream";
           //通知瀏覽器下載檔案而不是開啟
           Response.AddHeader("Content-Disposition", "attachment; filename ="+ HttpUtility.UrlEncode("test.pdf", System.Text.Encoding.UTF8));
           Response.BinaryWrite(pdfFile);
           Response.Flush();
           Response.End();*/


    }

    public string ChgHtml( string htmlText)
    {
        //String s1 = "1111";
        htmlText = htmlText.Replace("[dept]", Request["dept"]??"");
        htmlText = htmlText.Replace("[filler]", Request["filler"]??"");
        
        htmlText = htmlText.Replace("[no1]", Request["no1"] ?? "");
        htmlText = htmlText.Replace("[no2]", Request["no2"] ?? "");
        htmlText = htmlText.Replace("[no3]", Request["no3"] ?? "");
        htmlText = htmlText.Replace("[no4]", Request["no4"] ?? "");
        
        htmlText = htmlText.Replace("[contractid]", Request["contractid"]??"N/A");
        htmlText = htmlText.Replace("[planname]", Request["planname"]);
        htmlText = htmlText.Replace("[contractstart]", Request["contractstart"]);
        htmlText = htmlText.Replace("[contractend]", Request["contractend"]??"");
        String s1 = "";
        for (int i = 0; i < 5; i++)
        {
            s1 = s1+ " <tr><td class='auto - style2'>"+i+@"</td> <td>
                [unitno_1]
            </td>
            <td>
                [Amount_1]
            </td>
            <td>
                [item_1]
            </td>
            <td>
                [bank_1]
            </td>
            <td>
                [perdate_1]
            </td>
            <td>
                [norm_1]
            </td></tr>";
        }
        htmlText = htmlText.Replace("[tdgrid]", s1 ?? "");

        /*Table*/
        /*
        htmlText = htmlText.Replace("[company_1]", Request["company_1"]);
        htmlText = htmlText.Replace("[unitno_1]", Request["unitno_1"]);
        htmlText = htmlText.Replace("[Amount_1]", Request["Amount_1"]);
        htmlText = htmlText.Replace("[item_1]", Request["item_1"]);
        htmlText = htmlText.Replace("[bank_1]", Request["bank_1"]);
        htmlText = htmlText.Replace("[perdate_1]", Request["perdate_1"]);
        htmlText = htmlText.Replace("[norm_1]", Request["norm_1"]);
        */

        htmlText = htmlText + "<p>111111111</p> ";
        /*
        int i;
        String s1="";
        for (i=0;i<3;i++)
        {

            s1 = "< td style = 'border:1px solid #000000;text-align:center;font-size:20px;' >< span style = 'display: inline-block;' > 統一編號 </ span ></ td >";



        }
        //htmlText = htmlText + s1;
        htmlText = htmlText + "</table> ";*/
        
        return htmlText;
    }
    public byte[] ConvertHtmlTextToPDF(string htmlText)
    {
        if (string.IsNullOrEmpty(htmlText))
        {
            return null;
        }
        //避免當htmlText無任何html tag標籤的純文字時，轉PDF時會掛掉，所以一律加上<p>標籤
        htmlText = "<p>" + htmlText + "</p>";
        //System.IO.MemoryStream
        MemoryStream outputStream = new MemoryStream();//要把PDF寫到哪個串流
        byte[] data = Encoding.UTF8.GetBytes(htmlText);//字串轉成byte[]
        MemoryStream msInput = new MemoryStream(data);
        Document doc = new Document();//要寫PDF的文件，建構子沒填的話預設直式A4
        PdfWriter writer = PdfWriter.GetInstance(doc, outputStream);
        //指定文件預設開檔時的縮放為100%
        PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, doc.PageSize.Height, 1f);
        //開啟Document文件 
        doc.Open();
        //使用XMLWorkerHelper把Html parse到PDF檔裡
        XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, msInput, null, Encoding.UTF8, new UnicodeFontFactory());
       
        
        //將pdfDest設定的資料寫到PDF檔
        PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, writer);
        writer.SetOpenAction(action);
        doc.Close();
        msInput.Close();
        outputStream.Close();
        //回傳PDF檔案 
        return outputStream.ToArray();

    }


}