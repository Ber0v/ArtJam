using ArtJamWebApp.Data;
using ArtJamWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ArtJamWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ArtJamDbContext _context;

        public HomeController(ILogger<HomeController> logger, ArtJamDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(string searchQuery)
        {
            // Създаваме нов HomeViewModel
            var viewModel = new HomeViewModel
            {
                GroupIds = new List<int>(),
                GroupNames = new List<string>(),
                MusicianIds = new List<int>(),
                MusicianUsernames = new List<string>(),
                EventIds = new List<int>(),
                EventNames = new List<string>(),
                EventDates = new List<DateTime>(),
                SearchQuery = searchQuery
            };

            // Попълване на групи
            var groups = await _context.Groups
                .Where(g => string.IsNullOrEmpty(searchQuery) || g.GroupName.Contains(searchQuery))
                .ToListAsync();

            foreach (var group in groups)
            {
                viewModel.GroupIds.Add(group.Id);
                viewModel.GroupNames.Add(group.GroupName);
            }

            // Попълване на музиканти
            var musicians = await _context.MusicianProfiles
                .Where(m => string.IsNullOrEmpty(searchQuery) || m.User.UserName.Contains(searchQuery))
                .ToListAsync();

            foreach (var musician in musicians)
            {
                viewModel.MusicianIds.Add(musician.Id);
                viewModel.MusicianUsernames.Add(musician.User.UserName);
            }

            // Попълване на събития
            var upcomingEvents = await _context.Events
                .Where(e => e.Date >= DateTime.Now)
                .OrderBy(e => e.Date)
                .ToListAsync();

            foreach (var eventItem in upcomingEvents)
            {
                viewModel.EventIds.Add(eventItem.Id);
                viewModel.EventNames.Add(eventItem.Title);
                viewModel.EventDates.Add(eventItem.Date);
            }

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
