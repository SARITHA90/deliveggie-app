using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace DeliVeggieApp.BuildingBlocks.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }
        public double Price { get; set; }
        public IEnumerable<PriceReduction> PriceReductions { get; set; }
    }
}
