using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace FSU600_DATA_STORAGE_AND_MODELLING.Models
{
    //public enum Sit
    //{
    //    First_Hand,
    //    Second_Hand
    //}
    public class Apartments
    {
        
        [BsonId] //Is annotated with[BsonId] to designate this property as the document's primary key.
        [BsonRepresentation(BsonType.ObjectId)] //to allow passing the parameter as type string instead of an ObjectId structure. 
                                              //Mongo handles the conversion from string to ObjectId.
        public string Id { get; set; } ////Is required for mapping the Common Language Runtime(CLR) object to the MongoDB collection.

        [BsonElement("Situation")]
        public String Situation { get; set; }

        [BsonElement("Street")]
        [Display(Name = "Street*")]
        [Required]
        public string Street { get; set; }

        [BsonElement("Area")]
        [Display(Name = "Zone")]
        public string Area { get; set; }

        [BsonElement("City")]
        [Display(Name = "City*")]
        [Required]
        public string City { get; set; }

        [BsonElement("Rooms")]
        [Display(Name = "Rooms*")]
        [Required]
        public int Rooms { get; set; }

        [BsonElement("SquareMeters")]
        [Display(Name = "Area(m²)*")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:#,0}")]
        public decimal SquareMeters { get; set; }

        [BsonElement("Rent")]
        [Display(Name = "Rent(SEK/month)*")]
        [Required]
        public int Rent { get; set; }

        [BsonElement("MoveInDate")]
        [Display(Name = "Move in Date*")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")] //To remove time from display
        public DateTime MoveInDate { get; set; }

        [BsonElement("Floor")]
        [Display(Name = "Floor*")]
        [Required]
        public int Floor { get; set; }

        [BsonElement("WholeFloor")]
        [Display(Name = "Whole Floor")]
        public int WholeFloor { get; set; }

        [BsonElement("PublishDate")]
        [Display(Name = "Publish Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")] //To remove time from display
        public DateTime PublishDate { get; set; } = DateTime.Now;

        [BsonElement("Pets")]
        public string Pets { get; set; }

        [BsonElement("Smoke")]
        public string Smoke { get; set; }

        [BsonElement("LandlordComments")]
        [Display(Name = "Landlord Comments")]
        public string LandlordComments { get; set; }

        [BsonElement("Properties")]
        public string Properties { get; set; }

        [BsonElement("RentInclude")]
        [Display(Name = "Rent Include")]
        public string RentInclude { get; set; }

        [BsonElement("ImageUrl")]
        [Display(Name = "Photo")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

    }
}
