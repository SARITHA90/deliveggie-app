using System;

namespace DeliVeggieApp.Infrastructure.BuildingBlocks.Models.Responses
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }
        public double CurrentPrice { get; set; }
    }
}
