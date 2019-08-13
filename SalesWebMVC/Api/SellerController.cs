using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Dtos;
using SalesWebMVC.Models;

namespace SalesWebMVC.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {

        private readonly SalesWebMVCContext _context;

        public SellerController(SalesWebMVCContext context)
        {
            _context = context;
        }

        // GET: /api/sellers
        public IEnumerable<SellersDto> GetSellers()
        {
            return _context.Seller.ToList().Select(Mapper.Map<Seller, SellersDto>);
        }

        // GET: /api/sellers/1
        public IActionResult GetSeller(int id)
        {
            var seller = _context.Seller.SingleOrDefault(c => c.Id == id);

            if (seller == null)
            {
                return NotFound();
            }

            return new ObjectResult(seller);
        }


        // POST: /api/sellers/1
        [HttpPost]
        public IActionResult CreateSeller(SellersDto sellersDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var seller = Mapper.Map<SellersDto, Seller>(sellersDto);

            _context.Seller.Add(seller);
            _context.SaveChanges();

            sellersDto.Id = seller.Id;

            return Created(new Uri(Request.GetDisplayUrl() + "/" + seller.Id), sellersDto);

        }

    }
}