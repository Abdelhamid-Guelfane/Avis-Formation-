using AvisFormation.Models;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Web.Models;

namespace AvisFormation.Controllers
{
    public class HomeController : Controller
    {
        public readonly DataContext _context;
        private readonly ILogger<HomeController> _logger;
        public HomeController(DataContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }


        public IActionResult Index()
        {
            var listformations = _context.Formation.Include(f => f.Avis).OrderBy(x => Guid.NewGuid()).Take(4).ToList();
            //var listformations = _context.Formation.Include(f => f.Avis).Take(4).ToList();
            var listVm = new List<DetailsFormationViewModel>();
            foreach (var formation in listformations)
            {
                DetailsFormationViewModel vm = new DetailsFormationViewModel();
                vm.Id = formation.Id;
                vm.Nom = formation.Nom;
                vm.Url = formation.Url;
                vm.Description = formation.Description;
                vm.Avis = formation.Avis;
                if(formation.Avis.Count == 0)
                {
                    vm.NombreAvis = 0;
                    vm.note = 0;
                }
                else
                {
                    vm.NombreAvis = formation.Avis.Count;
                    vm.note = Math.Round(formation.Avis.Average(a => a.Note),2);
                }
                listVm.Add(vm);
            }
            return View(listVm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
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