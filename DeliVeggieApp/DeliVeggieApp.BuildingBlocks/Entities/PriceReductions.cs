using MongoDB.Bson.Serialization.Attributes;

namespace DeliVeggieApp.BuildingBlocks.Entities
{
    [BsonIgnoreExtraElements]
    public class PriceReductions
    {
        public int DayOfWeek { get; set; }
        public double Reduction { get; set; }
    }
}
