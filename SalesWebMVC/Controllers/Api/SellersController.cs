using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : ControllerBase
    {
        private readonly SalesWebMVCContext _context;

        public SellersController(SalesWebMVCContext context)
        {
            _context = context;
        }

        //GET: /api/sellers/
        public IEnumerable<Seller> GetSellers()
        {
            return _context.Seller.ToList();
        }

        //GET: /api/sellers/1
        [HttpGet]
        public Seller GetSeller(int id)
        {
            var seller = _context.Seller.SingleOrDefault(x => x.Id == id);

            if (seller == null)
                throw new NotImplementedException(); //not found

            return seller;
        }

        //POST: /api/sellers/1
        [HttpPost]
        public Seller CreateSeller(Seller seller)
        {
            if (!ModelState.IsValid)
                throw new NotImplementedException(); //bad request

            _context.Seller.Add(seller);
            _context.SaveChanges();

            return seller;
        }

        //PUT: /api/sellers/1
        [HttpPut]
        public Seller UpdateSeller(Seller seller, int id)
        {
            if (!ModelState.IsValid)
                throw new NotImplementedException(); //bad request

            var sellerInDb = _context.Seller.SingleOrDefault(x => x.Id == id);

            if (sellerInDb == null)
                throw new NotImplementedException(); //not found

            sellerInDb.Name = seller.Name;
            sellerInDb.BaseSalary = seller.BaseSalary;
            sellerInDb.BirthDate = seller.BirthDate;
            sellerInDb.DepartmentId = seller.DepartmentId;
            sellerInDb.Email = seller.Email;

            _context.SaveChanges();

            return seller;
        }

        //DELETE: /api/sellers/1
        [HttpDelete]
        public Seller DeleteSeller(int id)
        {
            var seller = _context.Seller.SingleOrDefault(x => x.Id == id);

            if (seller == null)
                throw new NotImplementedException(); //not found

            _context.Remove(seller);
            _context.SaveChanges();

            return seller;
        }

    }
}