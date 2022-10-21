namespace ShopOnline.Api.Entities
{
    public class BestellDetailsProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
        public int ProductMenge { get; set; }


        public BestellDetails BestellDetails { get; set; }
        public int BestellDetailsId { get; set; }

    }
}
