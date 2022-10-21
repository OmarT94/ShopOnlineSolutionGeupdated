using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Data;
using ShopOnline.Api.Entities;
using ShopOnline.Api.Repositories.Contracts;

namespace ShopOnline.Api.Repositories
{
    public class BestellDetailsRepository: IBstellDetailsRepository
    {
        private readonly ShopOnlineDbContext shopOnlineDbContext;

        public BestellDetailsRepository (ShopOnlineDbContext shopOnlineDbContext)
        {
            this.shopOnlineDbContext = shopOnlineDbContext;
        }

        public async Task<IEnumerable<BestellDetails>> GetAlleBestellungen()
        {
            var bestellung = await this.shopOnlineDbContext.BestellDetails.ToListAsync();
            return bestellung;
        }

        public async Task<BestellDetails> GetBestelllung(int id)
        {
            var bestellung = await this.shopOnlineDbContext.BestellDetails.FindAsync(id);
            return bestellung;
        }
        public async Task<BestellDetails> AddBestellung(BestellDetails bestellDetails)
        {
            bestellDetails.BestellDetailsProducts = null;

            shopOnlineDbContext.Add(bestellDetails);
            await shopOnlineDbContext.SaveChangesAsync();
            return bestellDetails;
        }

        public  async Task<BestellDetails> DeleteBestellung(int id)
        {
            var bestellung = new BestellDetails { Id = id };
            shopOnlineDbContext.Remove(bestellung);
            await shopOnlineDbContext.SaveChangesAsync();
            return NoContent();
        }

        public async Task<BestellDetails> UpdateBestellung(BestellDetails bestellDetails)
        {
            shopOnlineDbContext.Entry(bestellDetails).State = EntityState.Modified;
            await shopOnlineDbContext.SaveChangesAsync();
            return NoContent();
        }

        private BestellDetails NoContent()
        {
            throw new NotImplementedException();
        }

    }
}
