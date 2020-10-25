using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FSU600_DATA_STORAGE_AND_MODELLING.Models
{
    public class Requests
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("ApartmentId")]
        [Display(Name = "Apartment Id")]
        [Required]

        public string ApartmentId { get; set; }

        [BsonElement("ApplicantId")]
        [Display(Name = "Applicant Id")]
        [Required]
        public string ApplicantId { get; set; }
    }
}
