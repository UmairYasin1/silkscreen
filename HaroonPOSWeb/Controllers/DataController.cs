using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaroonPOSWeb.Controllers
{
    public class DataController : Controller
    {
        string adminLoginJsonFolder = ConfigurationManager.AppSettings["AdminLoginJsonFolder"];
        string webuserLoginJsonFolder = ConfigurationManager.AppSettings["WebUserLoginJsonFolder"];



        public dynamic LoadModelAdminUser<T>(string fileName)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath(adminLoginJsonFolder);
            string filePath = Path.Combine(path, fileName);
            T model = default(T);
            if (System.IO.File.Exists(filePath))
            {
                string dataAsJson = System.IO.File.ReadAllText(filePath);
                model = JsonConvert.DeserializeObject<T>(dataAsJson);

            }
            return model;
        }

        public void SaveModelAdminUser<T>(T model, string fileName)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath(adminLoginJsonFolder);
            string filePath = Path.Combine(path, fileName);
            //string dataAsJson = JsonUtility.ToJson(model);
            string dataAsJson = JsonConvert.SerializeObject(model);
            System.IO.File.WriteAllText(filePath, dataAsJson);

        }


        public dynamic LoadModelWebUser<T>(string fileName)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath(webuserLoginJsonFolder);
            string filePath = Path.Combine(path, fileName);
            T model = default(T);
            if (System.IO.File.Exists(filePath))
            {
                string dataAsJson = System.IO.File.ReadAllText(filePath);
                model = JsonConvert.DeserializeObject<T>(dataAsJson);

            }
            return model;
        }

        public void SaveModelWebUser<T>(T model, string fileName)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath(webuserLoginJsonFolder);
            string filePath = Path.Combine(path, fileName);
            //string dataAsJson = JsonUtility.ToJson(model);
            string dataAsJson = JsonConvert.SerializeObject(model);
            System.IO.File.WriteAllText(filePath, dataAsJson);

        }
    }
}