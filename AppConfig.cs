using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Windows.Forms;
namespace FO_Telekurs_Feed_Editer
{
    public class AppConfig
    {
        public static string getAppConfig(string key, string node)
        {
            try
            {
                XElement element = XElement.Load(Application.StartupPath + @"\app.config");

                foreach (XElement x in element.Elements(node))
                {
                    if (x.Value.ToUpper().Equals(key.ToUpper()))
                    {
                        return x.FirstAttribute.Value;
                    }
                }
                throw new Exception("Item Not Found!");
            }
            catch (Exception err)
            {
                //Console.WriteLine(err.Message,"get node");
                throw(err);
            }
            
        }
        public static bool setAppConfig(string key, string value, string node)
        {
            try
            {
                XElement element = XElement.Load(Application.StartupPath + @"\app.config");
                foreach (XElement x in element.Elements(node))
                {
                    if (x.Value.ToUpper().Equals(key.ToUpper()))
                        x.SetAttributeValue("value", value);
                }
                element.Save(Application.StartupPath + @"\app.config");
                return true;
            }
            catch (Exception err)
            {
                //Console.WriteLine(err.Message,"set node");
                return false;
            }
        }
        public static bool addAppConfig(string key, string value, string node)
        {
            try
            {
                XElement element = XElement.Load(Application.StartupPath + @"\app.config");
                element.Add(new XElement(node, new XAttribute("value", value)).Value=key);
                element.Save(Application.StartupPath + @"\app.config");
                return true;
            }
            catch (Exception err)
            {
                //Console.WriteLine(err.Message,"add node");
                return false;
            }
        }
        public static bool removeAppConfig(string key, string node)
        {
            try
            {
                XElement element = XElement.Load(Application.StartupPath + @"\app.config");
                foreach (XElement x in element.Elements(node))
                {
                    if (x.Value.ToUpper().Equals(key.ToUpper()))
                    {
                        x.Remove();
                        break;
                    }
                }
                element.Save(Application.StartupPath + @"\app.config");
                return true;
            }
            catch (Exception err)
            {
                //Console.WriteLine(err.Message,"delete node");
                return false;
            }
        }

    }
}
