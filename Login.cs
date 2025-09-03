using System.Data;
using Microsoft.Data.SqlClient;

namespace DataLayer
{
    public class Login : Operations
    {
        private string _User_Email;
        public string User_Email
        {
            get => _User_Email;
            set => _User_Email = value;
        }

        private string _User_Assigned_Pass;
        public string User_Assigned_Pass
        {
            get => _User_Assigned_Pass;
            set => _User_Assigned_Pass = value;
        }

        private string _User_Role;
        public string User_Role
        {
            get => _User_Role;
            set => _User_Role = value;
        }

        public bool Check_User_Exist()
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@User_Email", User_Email),
                new SqlParameter("@User_Assigned_Pass", User_Assigned_Pass)
            };

            try
            {
                DataTable dt = ExecuteProcedureSelect("Check_User", parameters);

                if (dt.Rows.Count > 0)
                {
                    User_Role = dt.Rows[0]["User_Role"].ToString();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UserLogin()
        {
            return Check_User_Exist();
        }

        public Login FetchUserData(string email)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@Email", email)
            };

            try
            {
                DataTable dt = ExecuteProcedureSelect("Get_User_Data", parameters);

                if (dt.Rows.Count > 0)
                {
                    var row = dt.Rows[0];
                    return new Login
                    {
                        User_Email = row["User_Email"].ToString(),
                        User_Assigned_Pass = row["User_Assigned_Pass"].ToString(),
                        User_Role = row["User_Role"].ToString()
                    };
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
