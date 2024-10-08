using AutoMapper;
using BLL.Repositories;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using TicketReservation.Models;

namespace TicketReservation.Controllers
{

    public class HomeController : Controller
    {
        private readonly EventRepository _eventRepo;
        private readonly TicketRepository _ticketRepo;
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(EventRepository eventRepository, ILogger<HomeController> logger, IMapper mapper, UserManager<AppUser> userManager)
        {
            _eventRepo = eventRepository;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            return View(_mapper.Map<IEnumerable<EventVM>>(_eventRepo.GetAll()));
        }

        public IActionResult Booking(int id)
        {
            return View(_mapper.Map<EventVM>(_eventRepo.GetbyId(id)));
        }
        [HttpPost]
        public IActionResult Booking(int id, int numOfTicket)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _ticketRepo.Book(id, userId, numOfTicket);
            return Redirect(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
