using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace FSU600_DATA_STORAGE_AND_MODELLING.Models
{
    public class Requests
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string ApartmentId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string ApplicantId { get; set; }
    }
}
