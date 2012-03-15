using System;
using System.Collections.Generic;
using System.Text;

namespace QX.DataAcess
{
    public class DBOperator
    {
        // Methods
        public static IDBOperator GetInstance()
        {
            string assemblyName = System.Configuration.ConfigurationSettings.AppSettings["assemblyName"];
            string typeName = System.Configuration.ConfigurationSettings.AppSettings["typeName"];
            return (IDBOperator)System.Reflection.Assembly.Load(assemblyName).CreateInstance(typeName);
        }
    } 

}
