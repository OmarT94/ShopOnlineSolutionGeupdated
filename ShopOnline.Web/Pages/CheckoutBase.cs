using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages
{
    public class CheckoutBase : ComponentBase
    {
        [Inject]
        public IJSRuntime Js { get; set; }
        protected IEnumerable <CartItemDto> ShoppingCartItems { get; set; }

        protected int TotalQty { get; set; }
        protected string PaymentDescription { get; set; }
        protected decimal PaymentAmount { get; set; }

        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }
        protected string DisplayButtons { get; set; } = "block";
        protected override async Task OnInitializedAsync()
        {
            try
            {
                ShoppingCartItems = await ShoppingCartService.GetItems(HardCode.UserId);
                if(ShoppingCartItems != null)
                {
                    Guid orderGuid = Guid.NewGuid();
                    PaymentAmount = ShoppingCartItems.Sum(x => x.TotalPrice);
                    TotalQty = ShoppingCartItems.Sum(p => p.Qty);
                    PaymentDescription = $"O_{HardCode.UserId}_{orderGuid}";

                }
                else
                {
                    DisplayButtons = "none";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (firstRender)
                {
                    await Js.InvokeVoidAsync("initPayPalButton"); 
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }

    }
}






















//https://www.paypal.com/merchantapps/appcenter/acceptpayments/checkout           Paypal Bezahl_Methode

//https://www.paypal.com/us/brc/article/how-to-open-a-paypal-business-account     Client UserId für Paypal