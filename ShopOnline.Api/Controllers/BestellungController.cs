using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Api.Entities;
using ShopOnline.Api.Repositories;
using ShopOnline.Api.Repositories.Contracts;
using ShopOnline.Models.Dtos;
using System.Runtime.InteropServices;

namespace ShopOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BestellungController : ControllerBase
    {
        private readonly IBstellDetailsRepository bstellDetailsRepository;

        public BestellungController(IBstellDetailsRepository bstellDetailsRepository)
        {
            this.bstellDetailsRepository = bstellDetailsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BestellDetailsDto>>> GetAllBestellungen()
        {
            try
            {
                var bestellung = await this.bstellDetailsRepository.GetAlleBestellungen();
                    if(bestellung == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(bestellung);
                }

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriveng data from database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task <ActionResult<BestellDetailsDto>>GetBestellungPerId(int id)
        {
            try
            {
                var bestellung = await this.bstellDetailsRepository.GetBestelllung(id);
                if (bestellung == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(bestellung);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriveng data from database");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(BestellDetails bestellDetails)
        {
            return Ok(await bstellDetailsRepository.AddBestellung(bestellDetails));
        }

        [HttpPut]
        public async Task <IActionResult> Put(BestellDetails bestellDetails)
        {
            return Ok(await bstellDetailsRepository.UpdateBestellung(bestellDetails));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await bstellDetailsRepository.DeleteBestellung(id));
        }
    }
}
