using ShopOnline.Api.Entities;

namespace ShopOnline.Api.Repositories.Contracts
{
    public interface IBstellDetailsRepository
    {
        Task<IEnumerable<BestellDetails>> GetAlleBestellungen();
        Task<BestellDetails> GetBestelllung(int id);
        Task<BestellDetails> AddBestellung(BestellDetails bestellDetails);
        Task<BestellDetails> UpdateBestellung(BestellDetails bestellDetails);
        Task<BestellDetails> DeleteBestellung(int id);
    }
}
