using BackAppPFE.Context;
using Microsoft.AspNetCore.Mvc;

namespace BackAppPFE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : Controller
    {
        private readonly AppDbContext _authContext;
        public TicketController(AppDbContext appDbContext)
        {
            _authContext = appDbContext;
        }
        [HttpGet]
        public IActionResult GetTicket()
        {
            return Ok(_authContext.Tickets.ToList());

        }
    }
}
