using FSU600_DATA_STORAGE_AND_MODELLING.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FSU600_DATA_STORAGE_AND_MODELLING.Services
{
    public class ApplicantsService
    {
        private readonly IMongoCollection<Applicants> applicants;

        public ApplicantsService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("Apartment-Queuing"));
            IMongoDatabase database = client.GetDatabase("Apartment-Queuing");
            applicants = database.GetCollection<Applicants>("Applicants");
        }

        public List<Applicants> Get()
        {
            return applicants.Find(applicant => true).ToList();
        }

        public Applicants Get(string id)
        {
            return applicants.Find(applicant => applicant.Id == id).FirstOrDefault();
        }

        public Applicants Create(Applicants applicant)
        {
            applicants.InsertOne(applicant);
            return applicant;
        }

        public void Update(string id, Applicants applicantIn)
        {
            applicants.ReplaceOne(applicant => applicant.Id == id, applicantIn);
        }

        public void Remove(Applicants applicantIn)
        {
            applicants.DeleteOne(applicant => applicant.Id == applicantIn.Id);
        }

        public void Remove(string id)
        {
            applicants.DeleteOne(applicant => applicant.Id == id);
        }
    }
}
