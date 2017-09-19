using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer
{
    public class clsGeneric
    {
        public Object transferPropertiesToAnotherClass(Object a, Object b)
        {
            Type typeB = b.GetType();
            foreach (PropertyInfo property in a.GetType().GetProperties())
            {
                if (!property.CanRead || (property.GetIndexParameters().Length > 0))
                    continue;

                PropertyInfo other = typeB.GetProperty(property.Name);
                if ((other != null) && (other.CanWrite))
                    other.SetValue(b, property.GetValue(a, null), null);
            }
            return b;
        }

        public string dateUrl(DateTime day)
        {

            string datePage = "";



            datePage = String.Format("{0:yyyyMMdd}", day);

            return datePage;

            //http://www.espn.com/mlb/probables/_/date/20170824
        }
    }



  


}
