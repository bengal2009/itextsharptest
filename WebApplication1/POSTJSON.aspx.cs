using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
namespace WebApplication1
{
    public class Person
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var responseEntities = new List<Person>()
        {
            new Person{ Name="Joey1", Id="Id1"},
            new Person{ Name="Joey2", Id="Id2"}
        };

            var result = serializer.Serialize(responseEntities);
            Response.Write(result);
            Response.End();

        }
    }
}