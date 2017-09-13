using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatLayer
{
    public class Dbconnection
    {
        public SqlConnection con = new SqlConnection("Data Source=10.10.10.46;Initial Catalog=STATS;User ID=luisma;Password=12345678");

        public SqlConnection getConn()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }


        public int ExeNonQuery(SqlCommand cmd)
        {
            cmd.Connection = getConn();
            int rowsaffected = -1;

            rowsaffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowsaffected;

        }
        public object ExeScalar(string insertString)
        {

            SqlCommand cmd = new SqlCommand(insertString, con);
            cmd.Connection = getConn();
            object obj = -1;
            obj = cmd.ExecuteScalar();
            con.Close();
            return obj;


        }



        public object ExeStoredProcedure(string storedProcedureName)
        {

            using (con)
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedureName, con))
                {
                    int rowsaffected = -1;




                    con.Open();
                    rowsaffected = cmd.ExecuteNonQuery();

                    return rowsaffected;
                }
            }

        }





        public DataTable ExeSPWithResults(string storedProcedureName)

        {

            using (con)
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedureName, con))
                {



                    con.Open();

                    SqlDataReader sdr;
                    DataTable dt = new DataTable();

                    sdr = cmd.ExecuteReader();
                    cmd.Connection = con;
                    dt.Load(sdr);
                    con.Close();
                    return dt;
                }
            }

        }

        public DataTable ExeSPWithResults(string storedProcedureName, IDictionary<string, string> parametersDictionary)

        {

            using (con)
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedureName, con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;


                    foreach (KeyValuePair<string, string> entry in parametersDictionary)
                    {
                        // do something with entry.Value or entry.Key
                        cmd.Parameters.AddWithValue(entry.Key, entry.Value);
                    }


                    con.Open();

                    SqlDataReader sdr;
                    DataTable dt = new DataTable();

                    sdr = cmd.ExecuteReader();
                    cmd.Connection = con;
                    dt.Load(sdr);
                    con.Close();
                    return dt;
                }
            }

        }




        public DataTable ExeReader(SqlCommand cmd)
        {
            cmd.Connection = getConn();
            SqlDataReader sdr;
            DataTable dt = new DataTable();

            sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            return dt;

        }





    }
}
