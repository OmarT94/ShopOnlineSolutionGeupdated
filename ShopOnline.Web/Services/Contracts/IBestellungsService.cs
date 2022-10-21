using ShopOnline.Models.Dtos;
using System.Threading.Tasks;

namespace ShopOnline.Web.Services.Contracts
{
    public interface IBestellungsService
    {
        Task<IEnumerable<BestellDetailsDto>> GetAlleBestellungen();
        Task<BestellDetailsDto> GetBestelllung(int id);
       
    }
}
