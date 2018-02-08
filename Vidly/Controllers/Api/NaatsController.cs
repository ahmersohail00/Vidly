using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class NaatsController : ApiController
    {
        private ApplicationDbContext _context;

        public NaatsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET api/naats
        public IEnumerable<NaatDTO> GetNaats(string query=null)
        {
            var naatsQuery = _context.Naats
                .Include(n => n.Genre)
                .Where(n => n.NumberAvailable > 0);
            if (!string.IsNullOrWhiteSpace(query))
                naatsQuery = naatsQuery.Where(n => n.Name.Contains(query));
            return naatsQuery
                .ToList()
                .Select(Mapper.Map<Naat, NaatDTO>);
        }

        //GET api/naats/1
        public IHttpActionResult GetNaats(int id)
        {
            var naat = _context.Naats.SingleOrDefault(c => c.Id == id);
            if (naat == null)
                return NotFound();

            return Ok(Mapper.Map< Naat, NaatDTO > (naat));
        }

        //POST api/naats
        [HttpPost]
        public IHttpActionResult CreateNaat(NaatDTO naatdto)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var naat = Mapper.Map<NaatDTO, Naat>(naatdto);
            _context.Naats.Add(naat);
            _context.SaveChanges();
            naatdto.Id = naat.Id;
            return Created(new Uri(Request.RequestUri + "/" + naat.Id), naatdto);
        }

        //PUT api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateNaat(int id, NaatDTO naatdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var naatInDb = _context.Naats.SingleOrDefault(c => c.Id == id);

            if (naatInDb == null)
                return NotFound();

            Mapper.Map(naatdto, naatInDb);

            _context.SaveChanges();

            return Ok(Mapper.Map<NaatDTO, Naat>(naatdto));
        }

        //DELETE api/customers/1
        [HttpDelete]
        public void DeleteNaat(int id)
        {
            var naatInDb = _context.Naats.SingleOrDefault(n => n.Id == id);

            if (naatInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Naats.Remove(naatInDb);
            _context.SaveChanges();
        }
    }
}
