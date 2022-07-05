using API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AdministratorController : BaseApiController
    {
        private readonly DataContext _context;

        public AdministratorController(DataContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "RequireAdminRole")] 
        [HttpGet("Admin")]
        public ActionResult GetUsersWithRoles()
        {
            return Ok("for admins");
        }
        
        [Authorize(Policy = "RequireChefEquipeRole")]
        [HttpGet("ChefEquipe")]
        public ActionResult GetUsersWithChefRoles()
        {
            return Ok("for chefEquipe");
        } 
        
        [Authorize(Policy = "RequireAssistantRole")]
        [HttpGet("AssistantRole")]
        public ActionResult GetUsersWithAssistantRoles()
        {
            return Ok("for assistant");
        }
    }
}
