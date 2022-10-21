using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages
{
    public class BestellungsDetailsBase:ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IBestellungsService BestellungsService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public BestellDetailsDto BestellDetailsDto { get; set; }
        public string ErrorMessage { get; set; }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                BestellDetailsDto = await BestellungsService.GetBestelllung(Id);

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;

            }
        }

    }
}
