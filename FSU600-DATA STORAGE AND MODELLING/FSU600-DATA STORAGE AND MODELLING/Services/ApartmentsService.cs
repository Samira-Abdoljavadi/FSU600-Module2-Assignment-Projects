using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FSU600_DATA_STORAGE_AND_MODELLING.Models;

namespace FSU600_DATA_STORAGE_AND_MODELLING.Services
{
    public class ApartmentsService
    {
        private readonly IMongoCollection<Apartments> _apartment;

        public ApartmentsService(IApartmentQueuingSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _apartment = database.GetCollection<Apartments>(settings.ApartmentsCollectionName);
        }

        public List<Apartments> Get() =>
            _apartment.Find(apartment => true).ToList();

        public Apartments Get(string id) =>
            _apartment.Find<Apartments>(apartment => apartment.Id == id).FirstOrDefault();

        public Apartments Create(Apartments apartment)
        {
            _apartment.InsertOne(apartment);
            return apartment;
        }

        public void Update(string id, Apartments apartmentIn) =>
            _apartment.ReplaceOne(apartment => apartment.Id == id, apartmentIn);

        public void Remove(Apartments apartmentIn) =>
            _apartment.DeleteOne(apartment => apartment.Id == apartmentIn.Id);

        public void Remove(string id) =>
            _apartment.DeleteOne(apartment => apartment.Id == id);
    }
}
