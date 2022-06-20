using API.Data;
using API.DTOs;
using API.entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class RapportController : BaseApiController
    {
        private readonly DataContext _context;
        public RapportController(DataContext context)
        {
            _context = context;

        }
        [HttpGet("All_Rapports")]
        public async Task<ActionResult<IEnumerable<Rapport>>> GetRapport()
        {
            return await _context.Rapports.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Rapport>> GetRapportById(int id)
        {
            return await _context.Rapports.FindAsync(id);
        }

        [HttpPost("Add_Rapport")]
        public async Task<ActionResult<RapportDto>> AddRapport(RapportDto rapportDto)
        {


            var Rapport = new Rapport
            {
                
                DateRapport=rapportDto.RapportDate,
                AdministratorId=rapportDto.AdministratorId,
                ServiceId=rapportDto.ServiceId
                
                
            };

            _context.Rapports.Add(Rapport);
            await _context.SaveChangesAsync();
            return Ok("Bravo ! Rapport bien ajouté ");


        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<IEnumerable<Rapport>>> RemoveRapport(int id)
        {
            var Rapport = await _context.Rapports.FindAsync(id);

            _context.Rapports.Remove(Rapport!);
            await _context.SaveChangesAsync();

            return await GetRapport();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Rapport>> UpdateRapport(int id, RapportDto rapportDto)
        {
            var Rapport = await _context.Rapports.FindAsync(id);

            Rapport.DateRapport = rapportDto.RapportDate;
            


            await _context.SaveChangesAsync();
            return await GetRapportById(id);
        }

    }
}

