using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication1
{
    /// <summary>
    ///benny 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
     [System.Web.Script.Services.ScriptService]
    public class benny : System.Web.Services.WebService
    {
        [WebMethod]
        public int Add(int a, int b)
        {
            return (a + b);
        }

        [WebMethod]
        public System.Single Subtract(System.Single A, System.Single B)
        {
            return (A - B);
        }

        [WebMethod]
        public System.Single Multiply(System.Single A, System.Single B)
        {
            return A * B;
        }

        [WebMethod]
        public System.Single Divide(System.Single A, System.Single B)
        {
            if (B == 0)
                return -1;
            return Convert.ToSingle(A / B);
        }




        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        [WebMethod]
        public  string GetWish(string value1, string value2, string value3, int value4)
        {
            return string.Format("祝您在{3} 年裡 {0}{1}{2}", value1, value2, value3, value4);
        }
    }
}
