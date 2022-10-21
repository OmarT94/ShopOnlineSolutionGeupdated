using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopOnline.Api.Entities
{
    public class BestellDetails
    {
        public int Id { get; set; }
        public int BestellNummer { get; set; }
        public bool? IstStorniert { get; set; }
        public int KundenID { get; set; }
        public DateTime BestelltAm { get; set; }
        public int ProductMenge { get; set; }
        
        [Column(TypeName = "decimal(10, 2)")]
        public decimal VersandKosten { get; set; }
        public decimal SummeOhneMwSt { get; set; }
        public decimal MwSt { get; set; }
        public decimal Summe { get; set; }
        public decimal GesamtSumme { get; set; }

        public ICollection<BestellDetailsProduct>? BestellDetailsProducts { get; set; }
    }
}
