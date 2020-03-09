using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BugZapper
{
    public class Database
    {
        //This application is using a MongoDB Database.       
        //This is where all the CRUD Methods go. 

        public class MongoCRUD
        {
            private IMongoDatabase db;

            //This connects to the database
            public MongoCRUD(string database)
            {
                var client = new MongoClient();
                db = client.GetDatabase(database);
            }

            //This can insert data into the database.
            public void InsertRecord<T>(string table, T record)
            {
                var collection = db.GetCollection<T>(table);
                collection.InsertOne(record);
            }

            //This can read data from the database. 
            public List<T> ReadRecords<T>(string table)
            {
                var collection = db.GetCollection<T>(table);
                return collection.Find(new BsonDocument()).ToList();
            }

            //This method will select a record from the databse based off the users input on the webpage.

            public T FindLoginRecord<T>(string username, string password)
            {
                var collection = db.GetCollection<T>("Users");

                var builder = Builders<T>.Filter;
                var filter = builder.And(builder.Eq("Username", username), builder.Eq("Password", password));


                return collection.Find(filter).First();
            }

            public T LoadRecordById<T>(string table, Guid id)
            {
                var collection = db.GetCollection<T>(table);
                var filter = Builders<T>.Filter.Eq("Id", id);

                return collection.Find(filter).First();
            }

            //This can replace a record with a new updated version or create a new one if one cannot be found.
            public void UpsertRecord<T>(string table, Guid id, T record)
            {
                var collection = db.GetCollection<T>(table);
                var result = collection.ReplaceOne(
                    new BsonDocument("_id", id),
                    record,
                    new ReplaceOptions { IsUpsert = true });
            }

            //Deletes a Record
            public void DeleteRecord<T>(string table, Guid id)
            {
                var collection = db.GetCollection<T>(table);
                var filter = Builders<T>.Filter.Eq("Id",id);
                collection.DeleteOne(filter);
            }
        }// end of MongoCRUD Class
    }// end of Database Class
}
