﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Api.Data;
using ShopOnline.Api.Entities;
using ShopOnline.Api.Extensions;
using ShopOnline.Api.Repositories.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IproductRepository productRepository;

        public ProductController(IproductRepository productRepository )
        {
            this.productRepository = productRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable< ProductDto>>> GetItems()
        {
            try
            {
                var products = await this.productRepository.GetItems();
                var productCategories = await this.productRepository.GetCategories();
                if (products ==null || productCategories == null)
                {
                    return NotFound();
                }
                else
                {
                    var productsDtos = products.ConvertToDo(productCategories);
                    return Ok(productsDtos);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetItem(int id)
        {
            try
            {
                var product = await this.productRepository.GetItem(id);
                
                if (product == null )
                {
                    return BadRequest();
                }
                else
                {
                   var productCategory= await this.productRepository.GetCategory(product.CategoryId);
                    var productDto= product.ConvertToDo(productCategory);
                    return Ok(productDto);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        //Create
        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
           return Ok(await productRepository.AddProduct(product));
        }

        //Update
        [HttpPut]
        public async Task<IActionResult> Put(Product product)
        {
            return Ok(await productRepository.UpdateProduct(product));
           
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(productRepository.DeleteProduct(id));

        }

        [HttpGet]
        [Route(nameof(GetProductCategories))]
        public async Task<ActionResult<IEnumerable<ProductCategoryDto>>> GetProductCategories()
        {
            try
            {
                var productcategories = await productRepository.GetCategories();
                
                var productsCategoryDtos=productcategories.ConvertToDto();

                return Ok(productsCategoryDtos);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet]
        [Route("{categoryId}/GetItemsByCategory")]
        public async Task <ActionResult<IEnumerable<ProductDto>>> GetItemsByCategory(int categoryId)
        {
            try
            {
                var products = await productRepository.GetItemsByCategory(categoryId);
                var productCategories = await productRepository.GetCategories();
                var productsDtos = products.ConvertToDo(productCategories);

                return Ok(productsDtos);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, 
                    "Error retrieving data from the database");
            }
        }


    }
}
