using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FSU600_DATA_STORAGE_AND_MODELLING.Models
{
    public class Applicants
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("FirstName")]
        [Required]
        public string FirstName { get; set; }

        [BsonElement("LastName")]
        [Required]
        public string LastName { get; set; }

        [BsonElement("Socialsecuritynumber")]
        [Display(Name = "Social Security Number")]
        public string Socialsecuritynumber { get; set; }

        [BsonElement("BirthDate")]
        [Display(Name = "Birth Date")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")] //To remove time from display
        public DateTime BirthDate { get; set; }

        [BsonElement("PhoneNumber")]
        [Display(Name = "Phone Number")]
        [Required]
        public string PhoneNumber { get; set; }

        [BsonElement("EMail")]
        [Required]
        public string EMail { get; set; }

        [BsonElement("Pets")]
        public string Pets { get; set; }

        [BsonElement("Smoke")]
        public string Smoke { get; set; }

        [BsonElement("Street")]
        public string Street { get; set; }

        [BsonElement("PostalCode")]
        [Display(Name = "Postal Code")]
        public int PostalCode { get; set; }

        [BsonElement("City")]
        public string City { get; set; }

        [BsonElement("Country")]
        public string Country { get; set; }

        [BsonElement("Introduction")]
        public string Introduction { get; set; }

        [BsonElement("MainEmployment")]
        [Display(Name = "Main Employment")]
        public string MainEmployment { get; set; }

        [BsonElement("MainIncome")]
        [Display(Name = "Main Income")]
        public int MainIncome { get; set; }

        [BsonElement("MainEmployer")]
        [Display(Name = "Main Employer")]
        public string MainEmployer { get; set; }

        [BsonElement("EmployerPhone")]
        [Display(Name = "Employer Phone")]
        public string EmployerPhone { get; set; }

        [BsonElement("WorkMunicipality")]
        [Display(Name = "Work Municipality")]
        public string WorkMunicipality { get; set; }
    }
}
