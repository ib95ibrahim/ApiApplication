using API.Data;
using API.DTOs;
using API.entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class LocationController : BaseApiController
    {
        private readonly DataContext _context;
        public LocationController(DataContext context)
        {
            _context = context;
           
        }
        [HttpGet("All_Locations")]
        public async Task<ActionResult<IEnumerable<Location>>> Getlocations()
        {
            return await _context.Locations.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Location>> GetLocationById(int id)
        {
            return await _context.Locations.FindAsync(id);
        }

        [HttpPost("Add_Location")]
        public async Task<ActionResult<IEnumerable<Location>>> AddLocation(LocationsDto LocationDto)
        {


            var location = new Location
            {

                LocationCity = LocationDto.LocationCity,
                LocationName = LocationDto.locationName
            };

            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return await Getlocations();


        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<IEnumerable<Location>>> RemoveLocation(int id)
        {
            var location = await _context.Locations.FindAsync(id);

            _context.Locations.Remove(location!);
            await _context.SaveChangesAsync();

            return await Getlocations();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Location>> UpdateLocation(int id, LocationsDto locationsDto)
        {
            var location = await _context.Locations.FindAsync(id);

            location.LocationName = locationsDto.locationName;
            location.LocationCity = locationsDto.LocationCity;
            

            await _context.SaveChangesAsync();
            return await GetLocationById(id);
        }

    }
}
