using API.Data;
using API.DTOs;
using API.entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class ServiceController : BaseApiController
{
    private readonly DataContext _context;
    public ServiceController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("all_services")]
    public async Task<ActionResult<IEnumerable<Service>>> GetServices()
    {
        return await _context.Services.ToListAsync();
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Service>> GetOneService(int id)
    {
        return await _context.Services.FindAsync(id);
    }
    
    
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<IEnumerable<Service>>> RemoveService(int id)
    {
        var service = await _context.Services.FindAsync(id);
         _context.Services.Remove(service!);
         await _context.SaveChangesAsync();
        return await GetServices();
    }
    
    [HttpPost("add_service")]
    public async Task<ActionResult<IEnumerable<Service>>> AddService(ServiceDto serviceDto)
    {
        var service = new Service
        {
           NameService = serviceDto.NameService,
        };
        _context.Services.Add(service!);
        await _context.SaveChangesAsync();
        return await GetServices();
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult<IEnumerable<Service>>> UpdateService(int id,ServiceDto serviceDto)
    {
        var OldService = await _context.Services.FindAsync(id);
        OldService!.NameService = serviceDto.NameService;
        
        await _context.SaveChangesAsync();
        return await GetServices();
    }
}