using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Project_DSiIS
{
    namespace Project_DSiIS
    {
        public class OracleSQLHandle
        {
            public static class SP
            {
                public const string GetAllUsers = "sp_get_all_users";
                public const string GetUserByUsername = "sp_get_user_by_username";
                public const string CreateUser = "sp_create_user";
                public const string DropUser = "sp_drop_user";
                public const string EditUserPassword = "sp_update_user_password";
                public const string GetAllRoles = "sp_get_all_role";
                public const string GetRoleByRoleName = "sp_get_role_by_rolename";
                public const string CreateRole = "sp_create_role";
                public const string DropRole = "sp_drop_role";
                public const string GetUserPrivileges = "sp_get_user_privileges";
                public const string GetRolePrivileges = "sp_get_role_privileges";
                public const string GrantPremissionToUser = "sp_grant_permission_to_user";
                public const string RevokePremissionFromUser = "sp_revoke_permission_from_user";
            }

            private OracleConnection _conn;

            public OracleSQLHandle(OracleConnection conn)
            {
                _conn = conn;
            }

            public DataTable GetUserData(string queryString)
            {
                OracleDataAdapter adapter = new OracleDataAdapter(queryString, _conn);
                DataTable datatable = new DataTable();
                try
                {
                    adapter.Fill(datatable);
                }
                catch (OracleException ex)
                {
                    MessageBox.Show($"Có lỗi khi truy suất: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return datatable;
            }

            public DataTable GetUserDataFromProcedure(string procedureName, List<OracleParameter> parameters)
            {
                DataTable datatable = new DataTable();
                try
                {
                    using (OracleCommand command = new OracleCommand(procedureName, _conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        if (parameters != null)
                        {
                            foreach (OracleParameter param in parameters)
                            {
                                command.Parameters.Add(param);
                            }
                        }

                        OracleParameter cursorParam = new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
                        command.Parameters.Add(cursorParam);

                        using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                        {
                            adapter.Fill(datatable);
                        }
                    }
                }
                catch (OracleException ex)
                {
                    MessageBox.Show($"Có lỗi khi truy suất: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return datatable;
            }

            public void ExecuteProcedureWithNoQuery(string procedureName, Dictionary<string, object> parameterDict)
            {
                List<OracleParameter> parameters = new List<OracleParameter>();
                foreach (var entry in parameterDict)
                {
                    parameters.Add(new OracleParameter(entry.Key, OracleDbType.Varchar2, ParameterDirection.Input) { Value = entry.Value });
                }

                using (OracleCommand cmd = new OracleCommand(procedureName, _conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }

                    cmd.ExecuteNonQuery();
                }
            }

            public DataTable ExecuteProcedureWithQuery(string procedureName, Dictionary<string, object> parameterDict)
            {
                DataTable datatable = new DataTable();
                try
                {
                    using (OracleCommand command = new OracleCommand(procedureName, _conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        if (parameterDict != null)
                        {
                            foreach (var entry in parameterDict)
                            {
                                OracleParameter param = new OracleParameter(entry.Key, OracleDbType.Varchar2, ParameterDirection.Input) { Value = entry.Value };
                                command.Parameters.Add(param);
                            }
                        }

                        OracleParameter cursorParam = new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
                        command.Parameters.Add(cursorParam);

                        using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                        {
                            adapter.Fill(datatable);
                        }
                    }
                }
                catch (OracleException ex)
                {
                    MessageBox.Show($"Có lỗi khi truy suất: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return datatable;
            }

            public void GetUserandRole(string procedureName, DataGridView dataGridViewName, string searchString = null)
            {
                List<OracleParameter> parameters = null;
                if (searchString != null)
                {
                    parameters = new List<OracleParameter>
                {
                    new OracleParameter("p_username", OracleDbType.Varchar2, ParameterDirection.Input)
                    { Value = searchString }
                };
                }
                DataTable datatable = GetUserDataFromProcedure(procedureName, parameters);
                dataGridViewName.DataSource = datatable;
            }
        }
    }
}
