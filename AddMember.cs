using System;
using Microsoft.Data.SqlClient;

namespace DataLayer
{
    public class AddUser : Operations
    {
        private string _User_FullName;
        public string User_FullName
        {
            get { return _User_FullName; }
            set { _User_FullName = value; }
        }

        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private string _User_Email;
        public string User_Email
        {
            get { return _User_Email; }
            set { _User_Email = value; }
        }

        private string _User_Assigned_Pass;
        public string User_Assigned_Pass
        {
            get { return _User_Assigned_Pass; }
            set { _User_Assigned_Pass = value; }
        }

        private string _User_Role;
        public string User_Role
        {
            get { return _User_Role; }
            set { _User_Role = value; }
        }

        private long _User_Phone_No;
        public long User_Phone_No
        {
            get { return _User_Phone_No; }
            set { _User_Phone_No = value; }
        }

        private string _User_Designation;
        public string User_Designation
        {
            get { return _User_Designation; }
            set { _User_Designation = value; }
        }

        private string _User_Department;
        public string User_Department
        {
            get { return _User_Department; }
            set { _User_Department = value; }
        }

        private DateTime _User_LastLogin;
        public DateTime User_LastLogin
        {
            get { return _User_LastLogin; }
            set { _User_LastLogin = value; }
        }

        public int NewUser()
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@User_FullName", _User_FullName),
                new SqlParameter("@UserName", _UserName),
                new SqlParameter("@User_Email", _User_Email),
                new SqlParameter("@User_Assigned_Pass", _User_Assigned_Pass),
                new SqlParameter("@User_Role", _User_Role),
                new SqlParameter("@User_Phone_No",_User_Phone_No),
                new SqlParameter("@User_Designation", _User_Designation),
                new SqlParameter("@User_Department", _User_Department),
                new SqlParameter("@User_LastLogin", _User_LastLogin)
            };

            int rowsAffected = ExecuteProcedureIUD("InsertUsers", parameters); 
            return rowsAffected;
        }
    }
}
