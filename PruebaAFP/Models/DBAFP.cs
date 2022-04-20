using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PruebaAFP.Models
{
    public class DBAFP
    {
        public DataTable query(string sql, List<Param> parametros, bool force_varchar = true)
        {
            string strcnn = ConfigurationManager.ConnectionStrings["ConexionDB"].ToString();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDA;

            using (SqlConnection cnn = new SqlConnection(strcnn))
            {
                try
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    // cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    if (parametros != null)
                    {
                        foreach (Param p in parametros)
                        {
                            int v;
                            if (force_varchar)
                            {
                                cmd.Parameters.Add(p.name, SqlDbType.VarChar);
                            }
                            else
                            {
                                cmd.Parameters.Add(p.name, int.TryParse(p.value.ToString(), out v) ? SqlDbType.Int : SqlDbType.VarChar);
                            }

                            cmd.Parameters[p.name].Value = p.value;
                        }
                    }

                    // cmd.Parameters.Add("@ID", SqlDbType.Int);


                    sqlDA = new SqlDataAdapter(cmd);
                    sqlDA.Fill(dataTable);
                    cnn.Close();

                }
                catch (Exception)
                {
                    /*Handle error*/
                }
            }
            return dataTable;

        }
    }
}