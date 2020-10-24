using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace FSU600_DATA_STORAGE_AND_MODELLING.Models
{
    public class Apartments
    {
        
        [BsonId] //Is annotated with[BsonId] to designate this property as the document's primary key.
        [BsonRepresentation(BsonType.ObjectId)] //to allow passing the parameter as type string instead of an ObjectId structure. 
                                              //Mongo handles the conversion from string to ObjectId.
        public string Id { get; set; } ////Is required for mapping the Common Language Runtime(CLR) object to the MongoDB collection.

        [BsonElement("Situation")]
        public string Situation { get; set; }

        [BsonElement("Street")]
        [Required]
        [Display(Name = "Street*")]
        public string Street { get; set; }

        [BsonElement("Area")]
        public string Area { get; set; }

        [BsonElement("City")]
        [Required]
        [Display(Name = "City*")]
        public string City { get; set; }

        [BsonElement("Rooms")]
        [Required]
        [Display(Name = "Rooms*")]
        public int Rooms { get; set; }

        [BsonElement("SquareMeters")]
        [Required]
        [Display(Name = "SquareMeters(m²)*")]
        [DisplayFormat(DataFormatString = "{0:#,0}")]
        public decimal SquareMeters { get; set; }

        [BsonElement("Rent")]
        [Required]
        [Display(Name = "Rent(SEK/month)*")]
        public int Rent { get; set; }

        [BsonElement("MoveInDate")]
        [Required]
        [Display(Name = "Move In Date*")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")] //To remove time from display
        public DateTime MoveInDate { get; set; }

        [BsonElement("Floor")]
        [Required]
        [Display(Name = "Floor*")]
        public int Floor { get; set; }

        [BsonElement("WholeFloor")]
        [Display(Name = "Whole Floor")]
        public int WholeFloor { get; set; }

        [BsonElement("PublishDate")]
        [Required]
        [Display(Name = "Publish Date*")]
        public DateTime PublishDate { get; set; } = DateTime.Now;

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
