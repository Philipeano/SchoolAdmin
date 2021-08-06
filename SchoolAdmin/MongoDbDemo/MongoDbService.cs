using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace SchoolAdmin.MongoDbDemo
{
    public class MongoDbService
    {
        MongoClient mongo;
        IMongoDatabase database; 
        IMongoCollection<BsonDocument> teachersCollection, studentsCollection;

        public MongoDbService()
        {
            mongo = new MongoClient("mongodb://localhost:27017/school_admin_db");
            database = mongo.GetDatabase("school_admin_db");
            teachersCollection = database.GetCollection<BsonDocument>("teachers");
            studentsCollection = database.GetCollection<BsonDocument>("students");
        }

        public void Insert(string collectionName, BsonDocument dataToInsert)
        {
            switch (collectionName)
            {
                case "teachers":
                    teachersCollection.InsertOne(dataToInsert);
                    break;
                case "students":
                    studentsCollection.InsertOne(dataToInsert);
                    break;
                default:
                    Console.WriteLine("Invalid collection! Only 'teachers' and 'students' are allowed."); 
                    break;
            }
        }

        public List<BsonDocument> FetchAll(string collectionName)
        {
            List<BsonDocument> result;
            switch (collectionName)
            {
                case "teachers":
                    result = teachersCollection.Find(new BsonDocument()).ToList();
                    break;
                case "students":
                    result = studentsCollection.Find(new BsonDocument()).ToList();
                    break;
                default:
                    result = null;
                    Console.WriteLine("Invalid collection! Only 'teachers' and 'students' are allowed.");
                    break;
            }
            return result;
        }


        public List<BsonDocument> FetchWithFilter(string collectionName, KeyValuePair<string, object> filterPair, string comparer)
        {
            List<BsonDocument> result;
            FilterDefinition<BsonDocument> filter;

            switch (comparer)
            {
                case "<":
                    filter = Builders<BsonDocument>.Filter.Lt(filterPair.Key, filterPair.Value);
                    break;
                case "<=":
                    filter = Builders<BsonDocument>.Filter.Lte(filterPair.Key, filterPair.Value);
                    break;
                case ">":
                    filter = Builders<BsonDocument>.Filter.Gt(filterPair.Key, filterPair.Value);
                    break;
                case ">=":
                    filter = Builders<BsonDocument>.Filter.Gte(filterPair.Key, filterPair.Value);
                    break;
                default:
                    filter = Builders<BsonDocument>.Filter.Eq(filterPair.Key, filterPair.Value);
                    break;
            }

            switch (collectionName)
            {
                case "teachers":
                    result = teachersCollection.Find(filter).ToList();
                    break;
                case "students":
                    result = studentsCollection.Find(filter).ToList();
                    break;
                default:
                    result = null;
                    Console.WriteLine("Invalid collection! Only 'teachers' and 'students' are allowed.");
                    break;
            }
            return result;
        }



        public void TestConnection() {

            // Display a list of databases on this server
            var dbList = mongo.ListDatabases().ToList();
            Console.WriteLine("The list of databases on this server is: ");
            foreach (var db in dbList)
            {
                Console.WriteLine(db);
            }
        }
    }
}
