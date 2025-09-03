using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace DataLayer
{
    public class AddProject : Operations
    {
        private string _Project_Name;
        public string Project_Name
        {
            get { return _Project_Name; }
            set { _Project_Name = value; }
        }

        private string _Project_Description;
        public string Project_Description
        {
            get { return _Project_Description; }
            set { _Project_Description = value; }
        }
        private string _Project_Version;
        public string Project_Version
        {
            get { return _Project_Version; }
            set { _Project_Version = value; }
        }
        private string _Project_Created_By;
        public string Project_Created_By
        {
            get
            {
                return _Project_Created_By;
            }
            set
            {
                _Project_Created_By = value;
            }
        }

        private string _Project_Status;
        public string Project_Status
        {
            get { return _Project_Status; }
            set { _Project_Status = value; }
        }

        

        public int AddNewProject()
        {
            SqlParameter[] parameters =
                {
                new SqlParameter("@Project_Name", Project_Name),
                new SqlParameter("@Project_Description", Project_Description),
                new SqlParameter("@Project_Version", Project_Version),
                new SqlParameter("@Project_Created_By", Project_Created_By),
                new SqlParameter("@Project_Status", Project_Status)
            };
            int rowsAffected = ExecuteProcedureIUD("InsertNewProject", parameters);
            return rowsAffected;
        }
    }
}
