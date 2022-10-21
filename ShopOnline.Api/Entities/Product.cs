﻿namespace ShopOnline.Api.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
         public string? ImageURL { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        //public BestellDetails BestellDetails { get; set; }
        public int? BestellDetailsId { get; set; }

        public string GetPreisAsString()
        {
            return string.Format($"{Price} $");
        }

        public ICollection<BestellDetailsProduct> BestellDetailsProduct { get; set; }
    }
}
