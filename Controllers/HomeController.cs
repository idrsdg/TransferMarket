using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TransferMarket.Data;
using TransferMarket.Models;
using TransferMarket.ViewModel;

namespace TransferMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
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
        public async Task<IActionResult> Search()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", "searchModel.CategoryId");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Search(SearchViewModel searchModel)
        {

            IQueryable<Player> players = _context.Players.AsQueryable();

            if (!String.IsNullOrWhiteSpace(searchModel.SearchText))
            {
                if (searchModel.SearchInDescription)
                {
                    players = players.Where(b => b.Name.Contains(searchModel.SearchText) || b.Position.Contains(searchModel.SearchText));
                }
                else
                {
                    players = players.Where(b => b.Name.Contains(searchModel.SearchText));
                }
            }

            if (searchModel.CategoryId.HasValue)
            {
                players = players.Where(b => b.CategoryId == searchModel.CategoryId.Value);
            }

            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", searchModel.CategoryId);
            searchModel.Results = await players.ToListAsync();
            return View(searchModel);
        }
    }
}
