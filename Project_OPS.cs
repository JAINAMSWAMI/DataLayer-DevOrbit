using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace DataLayer
{
    public class Project_OPS : Operations
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

    public class GetProject : Project_OPS
    {
        private int _Project_ID;
        public int Project_ID
        {
            get { return _Project_ID; }
            set { _Project_ID = value; }
        }
        private string _Project_Creeated_By;
        public string Project_Created_By
        {
            get { return _Project_Creeated_By; }
            set { _Project_Creeated_By = value; }
        }
        private DateTime _Project_Created_At;
        public DateTime Project_Created_At
        {
            get
            {
                return _Project_Created_At;
            }
            set
            {
                _Project_Created_At = value;
            }
        }

         public int GetProjectDB()
         {
        SqlParameter[] parameters = 
        {
            new SqlParameter("@Project_ID", Project_ID),
            new SqlParameter("@Project_Created_By", Project_Created_By),
            new SqlParameter("Project_Created_At",Project_Created_At)

        };
            int rowsAffected = ExecuteProcedureIUD("GetProject", parameters);
            return rowsAffected;
        }
    }

}
