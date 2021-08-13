using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using SchoolAdmin.AdoDotnetDemo.DTO;

namespace SchoolAdmin.AdoDotnetDemo.SqlDataService
{
    public class TeacherDataAdapterService
    {
        SqlConnection connection;
        SqlCommand selectCmd;
        SqlCommand updateCmd;
        SqlCommand insertCmd;
        SqlCommand deleteCmd;
        SqlDataAdapter adapter;
        public DataSet TeacherDataSet;

        public TeacherDataAdapterService()
        {
            connection = new SqlConnection("Data Source=.;Initial Catalog=SchoolAdminDB;Integrated Security=True;Pooling=False");
        }


        public void PopulateDataSet()
        {
            // Configure commands for SqlAdapter's SELECT operation
            selectCmd = new SqlCommand("SELECT * FROM Teachers", connection);

            // Create SqlAdapter object
            adapter = new SqlDataAdapter(selectCmd);

            // Create DataSet object
            TeacherDataSet = new DataSet();

            // Fill up DataSet using the SqlAdapter
            adapter.Fill(TeacherDataSet);
        }


        public void ManipulateDataSet()
        {
            #region UPDATE
            // Configure command for SqlAdapter's UPDATE operation
            updateCmd = new SqlCommand("UPDATE Teachers SET FirstName=@FirstName, MiddleName=@MiddleName, LastName=@LastName, Subject=@Subject WHERE StaffId=@StaffId", connection);
            adapter.UpdateCommand = updateCmd;

            // Add parameters to the update command
            adapter.UpdateCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50, "FirstName");
            adapter.UpdateCommand.Parameters.Add("@MiddleName", SqlDbType.NVarChar, 50, "MiddleName");
            adapter.UpdateCommand.Parameters.Add("@LastName", SqlDbType.NVarChar, 50, "LastName");
            adapter.UpdateCommand.Parameters.Add("@Subject", SqlDbType.NVarChar, 50, "Subject");
            adapter.UpdateCommand.Parameters.Add("@StaffId", SqlDbType.Int, 4, "StaffId");

            // Fetch the record to be updated (the record at index 2, in the first table contained in the data set)
            DataRow frankRecord = TeacherDataSet.Tables[0].Rows[3];

            // Assign a new value to the column to updated
            frankRecord["MiddleName"] = "Freeman";
            #endregion


            #region INSERT
            // Configure command for SqlAdapter's INSERT operation
            insertCmd = new SqlCommand("INSERT INTO Teachers (FirstName, MiddleName, LastName, Subject) VALUES(@FirstName, @MiddleName, @LastName, @Subject)", connection);
            adapter.InsertCommand = insertCmd;

            // Add parameters to the update command
            adapter.InsertCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50, "FirstName");
            adapter.InsertCommand.Parameters.Add("@MiddleName", SqlDbType.NVarChar, 50, "MiddleName");
            adapter.InsertCommand.Parameters.Add("@LastName", SqlDbType.NVarChar, 50, "LastName");
            adapter.InsertCommand.Parameters.Add("@Subject", SqlDbType.NVarChar, 50, "Subject");

            // Insert several new rows in the first table of the data set (the Teachers table)
            TeacherDataSet.Tables[0].Rows.Add(DBNull.Value, "Adeyemi", DBNull.Value, "Vincent", "System Administration");
            TeacherDataSet.Tables[0].Rows.Add(DBNull.Value, "Abimbola", DBNull.Value, "Fisher", "Human Capital Management");
            TeacherDataSet.Tables[0].Rows.Add(DBNull.Value, "Temilade", DBNull.Value, "Adelakun", "Program Management");
            #endregion


            #region DELETE
            // Configure command for SqlAdapter's DELETE operation
            deleteCmd = new SqlCommand("DELETE FROM Teachers WHERE StaffId > 20000", connection);
            adapter.DeleteCommand = deleteCmd;
            #endregion

            // Call the adapter's Update method to persist the changes to the database
            adapter.Update(TeacherDataSet);

            // Refresh the contents of the dataset using the Fill method
            adapter.Fill(TeacherDataSet);
        }
    }
}


/*
  TODOs:
  - Create SqlConnection object
  - Create SqlAdapter object
  - Configure commands for SqlAdapter's SELECT, INSERT, UPDATE and DELETE
  - Create DataSet object
  - Fill DataSet object with data records using the SqlAdapter object
  - Make changes to the DataSet (e.g., new record, modify record, remove record)
  - Persist the DataSet changes to the database
  - Verify that the changes in the DataSet were effected in the database
 */ 