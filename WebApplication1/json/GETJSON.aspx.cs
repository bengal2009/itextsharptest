using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.IO;
namespace WebApplication1
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        class Person
        {
            
            public string name { get; set; }
            public string phone { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            /* string jsonData = js.Serialize(Person);//序列化
             Console.WriteLine(jsonData);*/
            Stream req = Request.InputStream;
            req.Seek(0, System.IO.SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();
            Response.Write(json);

        }
    }
}