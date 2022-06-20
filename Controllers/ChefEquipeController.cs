using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class ChefEquipeController : BaseApiController
{
    private readonly DataContext _context;
    public ChefEquipeController(DataContext context)
    {
        _context = context;
    }
    [HttpGet("all_chefs")]
    public async Task<ActionResult<IEnumerable<ChefEquipe>>> GetChefEquips()
    {
        return await _context.ChefEquipes.ToListAsync();
    }
    [HttpPost("add_chef")]
    public async Task<ActionResult<IEnumerable<ChefEquipe>>> AddChefEquipe(ChefEquipeDto chefEquipeDto)
    {
        using var hmac = new HMACSHA512();
        var chef = new ChefEquipe
        {
            EmployerType = chefEquipeDto.TypeEquipe,
            FirstName = chefEquipeDto.FirstName,
            LastName = chefEquipeDto.LastName,
            Email = chefEquipeDto.Email,
            Gender = chefEquipeDto.Gender,
            PhoneNumber = chefEquipeDto.PhoneNumber,
            UserName = chefEquipeDto.UserName,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(chefEquipeDto.Password)),
            PasswordSalt = hmac.Key
        };
        _context.ChefEquipes.Add(chef);
        await _context.SaveChangesAsync();
        return await _context.ChefEquipes.ToListAsync();
    }
}