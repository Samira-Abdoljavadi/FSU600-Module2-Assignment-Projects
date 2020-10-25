using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FSU600_DATA_STORAGE_AND_MODELLING.Models;

namespace FSU600_DATA_STORAGE_AND_MODELLING.Services
{
    public class RequestsService
    {
        private readonly IMongoCollection<Requests> requests;

        public RequestsService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("Apartment-Queuing"));
            IMongoDatabase database = client.GetDatabase("Apartment-Queuing");
            requests = database.GetCollection<Requests>("Requests");
        }

        public List<Requests> Get()
        {
            return requests.Find(request => true).ToList();
        }

        public Requests Get(string id)
        {
            return requests.Find(request => request.Id == id).FirstOrDefault();
        }

        public Requests Create(Requests request)
        {
            requests.InsertOne(request);
            return request;
        }

        public void Update(string id, Requests requestIn)
        {
            requests.ReplaceOne(request => request.Id == id, requestIn);
        }

        public void Remove(Requests requestIn)
        {
            requests.DeleteOne(request => request.Id == requestIn.Id);
        }

        public void Remove(string id)
        {
            requests.DeleteOne(request => request.Id == id);
        }

    }
}
