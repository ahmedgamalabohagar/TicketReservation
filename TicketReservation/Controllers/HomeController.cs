using AutoMapper;
using BLL.Repositories;
using DAL.Context;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TicketReservation.Models;

namespace TicketReservation.Controllers
{

    public class HomeController : Controller
    {
        private readonly EventRepository _eventRepo;
        private readonly TicketRepository _ticRepo;
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly UserVM user = new UserVM { Id = 10, FirstName = "Hazem", LastName = "Khalifa", Phone = "01554532035" };

        public HomeController(ILogger<HomeController> logger, AppDbContext appDbContext, IMapper mapper, UserManager<AppUser> userManager, EventRepository eventRepo, TicketRepository ticRepo)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _eventRepo = eventRepo;
            _ticRepo = ticRepo;
            //user = _mapper.Map<UserVM>(_userManager.GetUserAsync(User).Result);
        }

        public IActionResult Index()
        {
            return View(_mapper.Map<IEnumerable<EventVM>>(_eventRepo.GetAll()));
        }

        public IActionResult Booking(int id)
        {
            ViewBag.AppUserVM = user;
            return View(_mapper.Map<EventVM>(_eventRepo.GetbyId(id)));
        }
        [HttpPost]
        public IActionResult Booking(int id, string userId, int numOfTicket)
        {
            _ticRepo.Book(id, userId, numOfTicket);
            return Redirect(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
