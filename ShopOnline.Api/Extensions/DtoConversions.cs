 using ShopOnline.Api.Entities;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<ProductCategoryDto> ConvertToDto(this IEnumerable<ProductCategory> productCategories)
        {
            return (from productCategory in productCategories
                    select new ProductCategoryDto
                    {
                        Id=productCategory.Id,
                        Name=productCategory.Name,
                        IconCSS=productCategory.IconCSS,
                    }).ToList();
        }
        public static IEnumerable<ProductDto> ConvertToDo(this IEnumerable<Product> products,
                                                          IEnumerable<ProductCategory> productCategories)
        {
            return (from product in products
                    join productCategory in productCategories
                    on product.CategoryId equals productCategory.Id
                    select new ProductDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        ImageURL = product.ImageURL,
                        Price = product.Price,
                        Qty = product.Qty,
                        CategoryId = product.CategoryId,
                        CategoryName = productCategory.Name

                    }).ToList();
        }

        public static ProductDto ConvertToDo(this Product product,
                                                         ProductCategory productCategory)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImageURL = product.ImageURL,
                Price = product.Price,
                Qty = product.Qty,
                CategoryId = product.CategoryId,
                CategoryName = productCategory.Name

            };
        }



        public static IEnumerable<CartItemDto> ConvertToDto(this IEnumerable<CartItem> cartItems,
                                                            IEnumerable<Product> products)
        {
            return (from cartItem in cartItems
                    join product in products
                    on cartItem.ProductId equals product.Id
                    select new CartItemDto
                    {
                        Id = cartItem.Id,
                        ProductId = cartItem.ProductId,
                        CategoryName= product.CategoryName,
                        ProductName = product.Name,
                        ProductDescription = product.Description,
                        productImageURL = product.ImageURL,
                        Price = product.Price,
                        CartId = cartItem.CartId,
                        Qty = cartItem.Qty,
                        TotalPrice = product.Price * cartItem.Qty

                    }).ToList();
        }
        public static CartItemDto ConvertToDto(this CartItem cartItem,
                                                            Product product)
        {
            return new CartItemDto
            {
                Id = cartItem.Id,
                ProductId = cartItem.ProductId,
                CategoryName=product.CategoryName,
                ProductName = product.Name,
                ProductDescription = product.Description,
                productImageURL = product.ImageURL,
                Price = product.Price,
                CartId = cartItem.CartId,
                Qty = cartItem.Qty,
                TotalPrice = product.Price * cartItem.Qty

            };
        }


        //public static IEnumerable<BestellDetailsDto> ConvertToDo(this IEnumerable<BestellDetails> bestellDetails, IEnumerable<User> users)
        //{
        //    return( from bestellung in bestellDetails
        //            //join prod in product
        //            join user in users
        //            on bestellung.BestellNummer equals user.KundenNummer
        //            select new BestellDetailsDto
        //            { 

        //                BestellNummer = bestellung.BestellNummer,
        //                IstStorniert = bestellung.IstStorniert,
        //                BestelltAm = bestellung.BestelltAm,
        //                ProductMenge = bestellung.ProductMenge,
        //                VersandKosten = bestellung.VersandKosten,
        //                SummeOhneMwSt = bestellung.SummeOhneMwSt,
        //                MwSt = bestellung.MwSt,
        //                Summe = bestellung.Summe,
        //                GesamtSumme = bestellung.GesamtSumme

        //            }).ToList();
        //}


        public static IEnumerable<BestellDetailsDto> ConvertToDo(this IEnumerable<BestellDetails> bestellDetails)
        {
            return (from bestellung in bestellDetails
                    select new BestellDetailsDto
                    {

                        BestellNummer = bestellung.BestellNummer,
                        IstStorniert = bestellung.IstStorniert,
                        BestelltAm = bestellung.BestelltAm,
                        ProductMenge = bestellung.ProductMenge,
                        VersandKosten = bestellung.VersandKosten,
                        SummeOhneMwSt = bestellung.SummeOhneMwSt,
                        MwSt = bestellung.MwSt,
                        Summe = bestellung.Summe,
                        GesamtSumme = bestellung.GesamtSumme

                    }).ToList();
        }

        public static BestellDetailsDto ConvertToDo(BestellDetails bestellDetails)
        {
            
                    return new BestellDetailsDto
                    {

                        BestellNummer = bestellDetails.BestellNummer,
                        IstStorniert = bestellDetails.IstStorniert,
                        BestelltAm = bestellDetails.BestelltAm,
                        ProductMenge = bestellDetails.ProductMenge,
                        VersandKosten = bestellDetails.VersandKosten,
                        SummeOhneMwSt = bestellDetails.SummeOhneMwSt,
                        MwSt = bestellDetails.MwSt,
                        Summe = bestellDetails.Summe,
                        GesamtSumme = bestellDetails.GesamtSumme

                    };
        }
    }
}