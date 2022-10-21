using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Models.Dtos
{
    public class BestellDetailsDto
    {
        public int Id { get; set; }
        public int BestellNummer { get; set; }
        public bool? IstStorniert { get; set; }
        public int KundenID { get; set; }
        public DateTime BestelltAm { get; set; }
        public int ProductMenge { get; set; }
        public decimal VersandKosten { get; set; }
        public decimal SummeOhneMwSt { get; set; }
        public decimal MwSt { get; set; }
        public decimal Summe { get; set; }
        public decimal GesamtSumme { get; set; }

        public string GetVersandKostenAsString()
        {
            return string.Format($"{VersandKosten} $");
        }

        public string GetSummeOhneMwStAsString()
        {
            return string.Format($"{SummeOhneMwSt} $");
        }

        public string GetMwStAsString()
        {
            return string.Format($"{MwSt} $");
        }

        public string GetSummeAsString()
        {
            return string.Format($"{Summe} $");
        }

        public string GetGesamtSummeAsString()
        {
            return string.Format($"{GesamtSumme} $");
        }

    }
}
