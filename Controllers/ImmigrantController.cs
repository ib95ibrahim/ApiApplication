﻿using System.Security.Cryptography;
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
        public async Task<ActionResult<IEnumerable<Immigrant>>> GetImmigrants()
        {
            return await _context.Immigrants.ToListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Immigrant>> GetImmigrantById(int id)
        {
            return await _context.Immigrants.FindAsync(id);
        }

        [HttpPost("add_Immigrant")]
        public async Task<ActionResult<IEnumerable<Immigrant>>> AddImmigrant(ImmigrantsDto immigrantsDto)
        {
            
            var immigrant = new Immigrant
            {

                FirstName = immigrantsDto.FirstName,
                LastName = immigrantsDto.LastName,
                BirthDate = immigrantsDto.BirthDate,
                Gender = immigrantsDto.Gender,
                Nationality = immigrantsDto.Nationality,
                PhoneNumber = immigrantsDto.PhoneNumber,
                Email = immigrantsDto.Email,
                Vulnerability = immigrantsDto.Vulnerability,
                locationId=immigrantsDto.LocalId
                

            };
            _context.Immigrants.Add(immigrant);
            await _context.SaveChangesAsync();
            return await GetImmigrants();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<IEnumerable<Immigrant>>> UpdateImmigrant(int id, ImmigrantsDto immigrantsDto)
        {
            var OldImmgrant = await _context.Immigrants.FindAsync(id);

            OldImmgrant.FirstName = immigrantsDto.FirstName;
            OldImmgrant.LastName = immigrantsDto.LastName;
            OldImmgrant.BirthDate = immigrantsDto.BirthDate;
            OldImmgrant.Gender = immigrantsDto.Gender;
            OldImmgrant.Nationality = immigrantsDto.Nationality;
            OldImmgrant.PhoneNumber = immigrantsDto.PhoneNumber;
            OldImmgrant.Vulnerability = immigrantsDto.Vulnerability;
            OldImmgrant.Email = immigrantsDto.Email;

            await _context.SaveChangesAsync();
            return await GetImmigrants();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<IEnumerable<Immigrant>>> RemoveImmigrant(int id)
        {
            var Immigrant = await _context.Immigrants.FindAsync(id);

            _context.Immigrants.Remove(Immigrant);
            await _context.SaveChangesAsync();

            return await GetImmigrants();
        }
    }
}
