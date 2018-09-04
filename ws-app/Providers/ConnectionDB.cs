using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft;
using Newtonsoft.Json;

namespace ws_app.Connection
{
    public class ConnectionDB
    {
        public static object executarProcedure(string v_Proc, string[,] Parametros, int v_Qtde, string v_TipoRetorno)
        {
            return executar(v_Proc, Parametros, v_Qtde, v_TipoRetorno);
        }
        
        private static object executar(string v_Proc, string[,] Parametros, int v_Qtde, string v_TipoRetorno)
        {
            string retorno = "";

            string connectionString = ConfigurationManager.ConnectionStrings["PET"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(v_Proc, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    for (var i = 0; i < v_Qtde; i++)
                    {
                        command.Parameters.AddWithValue("@" + Parametros[i, 0] + "", pegarValorTipo(Parametros[i, 1], Parametros[i, 2]));
                    }

                    connection.Open();
                    if(v_TipoRetorno == "string")
                    {
                        retorno = "1|" + (string)command.ExecuteScalar().ToString();
                    }
                    else
                    { 
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        var DataTable = new DataTable();
                        da.Fill(DataTable);
                        retorno = "1|" + dataTableToJson(DataTable);
                    }
                }
                catch (Exception e)
                {
                    retorno = "0|" + e.ToString();
                }
                finally
                {
                    connection.Close();
                }
            }

            return retorno;
        }

        public static string dataTableToJson(DataTable table)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(table, Formatting.Indented).ToString();
        }

        public static string formatSQLDate(DateTime d)
        {
            if (d.ToShortDateString() == "01/01/1900" || d.ToShortDateString() == "1/1/1900")
            {
                return string.Empty;
            }
            return d.Year + "-" + d.Month.ToString("00") + "-" + d.Day.ToString("00");
        }

        public static string formatSQLDate(string strData)
        {
            string strRetorno;

            if (strData == "")
                strRetorno = "";
            else
                strRetorno = formatSQLDate(Convert.ToDateTime(strData));

            return strRetorno;
        }

        public static object pegarValorTipo(string v_Valor, string v_Tipo)
        {
            if (v_Valor != "" && v_Valor != null)
            {
                if (v_Tipo == "string")
                {
                    return v_Valor;
                }
                else if (v_Tipo == "int")
                {
                    return Convert.ToInt16(v_Valor.Replace(",", ""));
                }
                else if (v_Tipo == "date")
                {
                    return formatSQLDate(v_Valor);
                }
                else if (v_Tipo == "double")
                {
                    return Convert.ToDecimal(v_Valor.Replace(",", "."));
                }
                else if (v_Tipo == "bit")
                {
                    return Convert.ToInt16(v_Valor == "0" ? "0" : "1");
                }
            }

            return Convert.DBNull;
        }
    }
    
}