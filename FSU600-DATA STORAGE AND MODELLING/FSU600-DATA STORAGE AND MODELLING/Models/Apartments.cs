using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FSU600_DATA_STORAGE_AND_MODELLING.Models
{
    public class Apartments
    {
        
        [BsonId] //Is annotated with[BsonId] to designate this property as the document's primary key.

       [BsonRepresentation(BsonType.ObjectId)] //to allow passing the parameter as type string instead of an ObjectId structure. 
                                               //Mongo handles the conversion from string to ObjectId.

        public string Id { get; set; } ////Is required for mapping the Common Language Runtime(CLR) object to the MongoDB collection.

        public string City { get; set; }

        public string Area { get; set; }

        public string Adress { get; set; }

        public int Floor { get; set; }

        public int WholeFloor { get; set; }

        public int Rent { get; set; }

    }
}
