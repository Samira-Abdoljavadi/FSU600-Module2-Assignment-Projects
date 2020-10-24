using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FSU600_DATA_STORAGE_AND_MODELLING.Models;
using Microsoft.Extensions.Configuration;

namespace FSU600_DATA_STORAGE_AND_MODELLING.Services
{
    public class ApartmentsService
    {
        private readonly IMongoCollection<Apartments> apartments;

        public ApartmentsService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("Apartment-Queuing"));
            IMongoDatabase database = client.GetDatabase("Apartment-Queuing");
            apartments = database.GetCollection<Apartments>("Apartments");
        }

        public List<Apartments> Get()
        {
            return apartments.Find(apartment => true).ToList();
        }

        public Apartments Get(string id)
        {
            return apartments.Find(apartment => apartment.Id == id).FirstOrDefault();
        }

        public Apartments Create(Apartments apartment)
        {
            apartments.InsertOne(apartment);
            return apartment;
        }

        public void Update(string id, Apartments apartmentIn)
        {
            apartments.ReplaceOne(apartment => apartment.Id == id, apartmentIn);
        }

        public void Remove(Apartments apartmentIn)
        {
            apartments.DeleteOne(apartment => apartment.Id == apartmentIn.Id);
        }

        public void Remove(string id)
        {
            apartments.DeleteOne(apartment => apartment.Id == id);
        }

    }
}
