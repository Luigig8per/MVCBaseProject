using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatLayer;
using System.Data;

namespace BusinesLayer
{
   public class clsBusinessProcess
    {

        public object ExeStoredProcedure(string storedProcedureName)
        {
            Dbconnection theConnection = new Dbconnection();

            return theConnection.ExeStoredProcedure(storedProcedureName);
        }

        public DataTable ExeSPWithResults(string storedProcedureName, IDictionary<string, string> parametersDictionary)
        {
            Dbconnection theConnection = new Dbconnection();

            return theConnection.ExeSPWithResults(storedProcedureName, parametersDictionary);
        }

        public DataTable ExeSPWithResults(string storedProcedureName)
        {
            Dbconnection theConnection = new Dbconnection();

            return theConnection.ExeSPWithResults(storedProcedureName);
        }

    }
}
