using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace JITEF.Common
{
    public class StoredProcedureHelper
    {
        private SqlConnection conn;

        public StoredProcedureHelper(string connectionName)
        {
            var constr = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;

            this.conn = new SqlConnection(constr);
        }

        public DataTable Exec(string sql, Dictionary<string, object> paramList)
        {
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (paramList != null && paramList.Keys.Count > 0)
                {
                    foreach (var key in paramList.Keys)
                    {
                        cmd.Parameters.Add(new SqlParameter(key, paramList[key]));
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable table = new DataTable();
                adapter.Fill(table);

                conn.Close();
                return table;
            }
        }


    }
}