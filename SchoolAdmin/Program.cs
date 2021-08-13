using SchoolAdmin.Facilities;
using SchoolAdmin.Learning;
using SchoolAdmin.LookUp;
using SchoolAdmin.Teaching;
using System;
using System.Collections.Generic;
using SchoolAdmin.MongoDbDemo;
using MongoDB.Bson;
using SchoolAdmin.AdoDotnetDemo;
using SchoolAdmin.AdoDotnetDemo.DTO;
using SchoolAdmin.AdoDotnetDemo.SqlDataService;
using System.Data;

namespace SchoolAdmin
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the TeacherDataAdapterService class
            TeacherDataAdapterService teacherADPService = new TeacherDataAdapterService();
            teacherADPService.PopulateDataSet();
            teacherADPService.ManipulateDataSet();
                       
            DataSet teacherDS = teacherADPService.TeacherDataSet;
        }
    }
}
