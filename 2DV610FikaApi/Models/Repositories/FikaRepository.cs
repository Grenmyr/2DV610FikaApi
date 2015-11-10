using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Core;
using System.Threading.Tasks;

namespace _2DV610FikaApi.Models.Repositories
{
    public class FikaRepository : IFikaRepository
    {

        private IMongoCollection<Fika> _collection;
        private String _connection = "mongodb://localhost:27017";
        public FikaRepository() {
            var client = new MongoClient(_connection);
            var db = client.GetDatabase("Fika");
            _collection = db.GetCollection<Fika>("Baking");

            // Try to add default fika.
            //_collection.InsertOneAsync(new Fika { Name = "Kladdkaka" });
            
        }

        public async Task<Fika> GetFika(int id) 
        {
            var response = await _collection.Find(fika => fika.Id == id).ToListAsync();
            return new Fika { Id = response.First().Id, Name = response.First().Name };
        }

        public async Task<Fika> GetFika() 
        {
            var response = await _collection.Find(fika => fika.Name == "Cheese Cake").ToListAsync();
            return new Fika { Id = response.First().Id, Name = response.First().Name };
        }

        public async Task<Fika> AddFika(Fika fika)
        {
           //fika.Id = int.Parse(ObjectId.GenerateNewId().ToString());
            fika.Id = 1;
           await _collection.InsertOneAsync(fika);
           return fika;
        }
    }
}