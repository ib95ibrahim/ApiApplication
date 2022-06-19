using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace API.Controllers
{

    public class ImmigrantController : BaseApiController
    {

        private readonly DataContext _context;

        public ImmigrantController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("AllImmigrants")]
        public async Task<ActionResult<IEnumerable<Immigrant>>> GetImmigrant()
        {
            return await _context.Immigrants.ToListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Immigrant>> GetOneImmigrant(int id)
        {
            return await _context.Immigrants.FindAsync(id);
        }

        [HttpPost("add_Immigrant")]
        public async Task<ActionResult<Employer>> AddImmigrant(ImmigrantsDto immigrantsDto)
        {

            var immigrant = new Immigrant
            {

                FirstName = immigrantsDto.FirstName,
                LastName = immigrantsDto.LastName,
                BirthDate = immigrantsDto.BirthDate,
                Gender = immigrantsDto.Gender,
                Nationality = immigrantsDto.Nationality,
                PhoneNumber = immigrantsDto.PhoneNumber,
                Vulnerability = immigrantsDto.Vulnerability,
                

            };
            _context.Immigrants.Add(immigrant);
            await _context.SaveChangesAsync();
            return Ok("Bravo ! Beneficiaire bien ajouté ");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<IEnumerable<Immigrant>>> GetOneImmigrant(int id, ImmigrantsDto immigrantsDto)
        {
            var OldImmgrant = await _context.Immigrants.FindAsync(id);

            OldImmgrant.FirstName = immigrantsDto.FirstName;
            OldImmgrant.LastName = immigrantsDto.LastName;
            OldImmgrant.BirthDate = immigrantsDto.BirthDate;
            OldImmgrant.Gender = immigrantsDto.Gender;
            OldImmgrant.Nationality = immigrantsDto.Nationality;
            OldImmgrant.PhoneNumber = immigrantsDto.PhoneNumber;
            OldImmgrant.Vulnerability = immigrantsDto.Vulnerability;

            await _context.SaveChangesAsync();
            return await GetImmigrant();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<IEnumerable<Immigrant>>> RemoveImmigrant(int id)
        {
            var Immigrant = await _context.Immigrants.FindAsync(id);

            _context.Immigrants.Remove(Immigrant);
            await _context.SaveChangesAsync();

            return await GetImmigrant();
        }
    }
}
