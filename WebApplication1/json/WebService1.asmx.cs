using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.Collections;

namespace WebApplication1.json
{
    /// <summary>
    ///WebService1 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string  HelloWorld()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var responseEntities = new List<Person>()
        {
            new Person{ Name="Joey1", Id="Id1"},
            new Person{ Name="Joey2", Id="Id2"}
        };
            var result = serializer.Serialize(responseEntities);
            return new JavaScriptSerializer().Serialize(responseEntities) ;
            //return "ok";
            //HttpContext.Current.Response.Write("{property: value}");
        }
        
        [WebMethod]
        //[System.Web.Script.Services.ScriptMethod]
        public  string Deserial()
        {
            return "hello";
        }

        // Deserial3
        [WebMethod]
        //[System.Web.Script.Services.ScriptMethod]
         public string Deserial3(List<Student> Students)
       // public string Deserial3(Hashtable data)
        {


            /*var Persons = new Person();
            var serializer = new JavaScriptSerializer();
            Person Pers = serializer.Deserialize<Person>(s1);
            string name = Pers.Name;*/
            //return "1111";
            System.Console.WriteLine("Hello");
            //return st1.name;
            return Students[0].name+":"+Students[0].id+":"+ Students.Count;
        } //Deserial 3 end
        [WebMethod]
        //[System.Web.Script.Services.ScriptMethod]
        public string GenPDF(string dept,string filler,string contstart,
            List<tbl> tbls)
         {



            return dept+":Count-"+tbls.Count+":"+tbls[0].ComName;
        }
        [WebMethod]
        //[System.Web.Script.Services.ScriptMethod]
        public string Deserial4(List<Student> Students)
        // public string Deserial3(Hashtable data)
        {


            /*var Persons = new Person();
            var serializer = new JavaScriptSerializer();
            Person Pers = serializer.Deserialize<Person>(s1);
            string name = Pers.Name;*/
            //return "1111";
            System.Console.WriteLine("Hello");
            //return st1.name;
            return Students[0].name + ":" + Students[0].id + ":" + Students.Count;
        }

        [WebMethod]
    //[System.Web.Script.Services.ScriptMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string HelloWorld2(String name, String id2, List<datacom> DataArray)
    {
        /* Person p1;
         p1.Id = id2;
         p1.Name = name;
         JavaScriptSerializer serializer = new JavaScriptSerializer();
         var result = serializer.Serialize(p1);
         return result;
         */
        //return "it worked";

        var p1 = new Person();
        p1.Id = "111";
        p1.Name = "22223";
        var p2 = new EMA();
        p2.CompanyName = "benny";
        p2.Id = "1111";
        p2.datacoms = new List<datacom>
            {
                new datacom(){data1 ="111",data2="2222"},
                new datacom(){data1 ="333",data2="444"}

            };


        return new JavaScriptSerializer().Serialize(p2);
        //return new JavaScriptSerializer().Serialize("{'id':'111','Name':'2222','result':"+DataArray+" }");
        //return new JavaScriptSerializer().Serialize("{id:\"111\",\"Name\":\"2222\"}");
        //return ("{\"id\":\"111",\"Name\":\"2222\",\"resul\":" + DataArray[0].data1 + " }");
    }
        [WebMethod]
     
        public string GetWish(string value1, string value2, string value3, int value4)
        {
            return string.Format("祝您在{3}年裡 {0}{1}{2}", value1, value2, value3, value4);
        }

    }
    public class tbl
    {
        public string ComName { get; set; }
        public string UnNo { get; set; }
        public int Amount { get; set; }
        public string Deposit { get; set; }
        public string Ret_Date { get; set; }
        public string Real_Date { get; set; }

    }
    public class Student
    {
        public string name { get; set; }
        public int  id { get; set; }
    }
    public class Person
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public List<datacom> datacoms { get; set; }
    }
    public class EMA
    {
        public string CompanyName { get; set; }
        public string Id { get; set; }
        public List<datacom> datacoms { get; set; }

    }
    public class datacom
    {
        public string data1 { get; set; }
        public string data2 { get; set; }
    }


}
