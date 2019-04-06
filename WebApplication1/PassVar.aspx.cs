using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PassVar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string[] allkeys = Request.QueryString.AllKeys;
        /*
        foreach (String key in Request.QueryString.AllKeys)
        {
            Response.Write("Key: " + key + " Value: " + Request.QueryString[key]);
        }
        */
        //222
        Response.Write("<br >"+Request["id"]+ Request["id2"]);

    }
}