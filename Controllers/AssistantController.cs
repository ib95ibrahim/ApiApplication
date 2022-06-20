using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class AssistantController : BaseApiController
{

    private readonly DataContext _context;
    public AssistantController(DataContext context)
    {
        _context = context;
    }
    
    [HttpGet("all_assistants")]
    public async Task<ActionResult<IEnumerable<Assistant>>> GetAssistants()
    {
        return await _context.Assistants.ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Assistant>> GetOneAssistant(int id)
    {
        return await _context.Assistants.FindAsync(id);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<IEnumerable<Assistant>>> RemoveAssistant(int id)
    {
        var assistant = await _context.Assistants.FindAsync(id);
          _context.Assistants.Remove(assistant!);
        await  _context.SaveChangesAsync();
        return await GetAssistants();

    }

    [HttpPost("add_assistant")]
    public async Task<ActionResult<IEnumerable<Assistant>>> AddAssistant(AssistantDto assistantDto)
    {
        using var hmac = new HMACSHA512();
        var assistant = new Assistant
        {
            TypeEquipe = assistantDto.TypeEquipe,
            FirstName = assistantDto.FirstName,
            LastName = assistantDto.LastName,
            Email = assistantDto.Email,
            Gender = assistantDto.Gender,
            PhoneNumber = assistantDto.PhoneNumber,
            UserName = assistantDto.UserName,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(assistantDto.Password)),
            PasswordSalt = hmac.Key
        };
        _context.Assistants.Add(assistant);
        await _context.SaveChangesAsync();
        return await GetAssistants();
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult<IEnumerable<Assistant>>> UpdateAssistant(int id,AssistantDto assistantDto)
    {  
        var oldAssistant = await _context.Assistants.FindAsync(id);
        
        oldAssistant!.TypeEquipe = assistantDto.TypeEquipe;
        oldAssistant.FirstName = assistantDto.FirstName;
        oldAssistant.LastName = assistantDto.LastName;
        oldAssistant.Email = assistantDto.Email;
        oldAssistant.Gender = assistantDto.Gender;
        oldAssistant.PhoneNumber = assistantDto.PhoneNumber;
        oldAssistant.UserName = assistantDto.UserName;
        //pass?
        await _context.SaveChangesAsync();
        return await GetAssistants();
    }
}