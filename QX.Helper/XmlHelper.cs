using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;
namespace QX.Helper
{
    public class XmlHelper
    {
        public static void UpdateConfig(string p_strKey, string p_strValue)
        {
            try
            {
                string m_strFullPath = "";
                // Assembly Asm = Assembly.GetExecutingAssembly();
                XmlDocument xmlDoc = new XmlDocument();
                m_strFullPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\" + "deviceconfig.xml";
                xmlDoc.Load(m_strFullPath);
                XmlNodeList nodeList = xmlDoc.SelectSingleNode("/configuration/config").ChildNodes;
                foreach (XmlNode xn in nodeList)
                {
                    XmlElement xe = (XmlElement)xn;

                    if (xe.GetAttribute("key").IndexOf(p_strKey) != -1)
                    {
                        xe.SetAttribute("value", p_strValue);
                    }
                }
                xmlDoc.Save(m_strFullPath);
            }
            catch (System.NullReferenceException NullEx)
            {
                throw NullEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetConfig(string p_strKey)
        {
            try
            {
                string m_strFullPath = "";
                string result;
                // Assembly Asm = Assembly.GetExecutingAssembly();
                XmlDocument xmlDoc = new XmlDocument();
                m_strFullPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\" + "deviceconfig.xml";
                xmlDoc.Load(m_strFullPath);
                XmlNode xn = xmlDoc.SelectSingleNode("/configuration/config/"+p_strKey);

                XmlElement xe = (XmlElement)xn;

                result = xe.GetAttribute("value");

                return result;

            }
            catch (System.NullReferenceException NullEx)
            {
                throw NullEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
