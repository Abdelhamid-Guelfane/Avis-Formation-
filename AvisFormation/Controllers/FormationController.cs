using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Controllers
{
    public class FormationController : Controller
    {
        public readonly DataContext _context;
        public FormationController(DataContext context)
        {
            _context = context;
        }

        //Action
        [Route("/listformations")]
        public IActionResult ToutesLesFormations()
        {
            var listformations = _context.Formation.ToList();
            return View(listformations);
        }

        //Action
        [Route("/formation/{nomSeo}")]
        public IActionResult Details(string nomSeo)
        {
            var formation = _context.Formation.Include(f => f.Avis).Where(f => f.NomSeo == nomSeo).First();
            DetailsFormationViewModel vm = new DetailsFormationViewModel();
            vm.Id = formation.Id;
            vm.Nom = formation.Nom;
            vm.Url = formation.Url;
            vm.Description = formation.Description;
            vm.Avis = formation.Avis;
            vm.NombreAvis = formation.Avis.Count;
            vm.note = Math.Round(formation.Avis.Average(a => a.Note),2);

            return View(vm);
        }

        // Action
        


    }
}
