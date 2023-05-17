using Core.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers
{
    [Authorize(Roles ="Client,Admin")]
    public class AvisController : Controller
    {
        public readonly DataContext _context;
        public AvisController(DataContext context)
        {
            _context = context;
        }

        [Route("/VotreAvis/{nomSeo}")]
        public IActionResult AjouterUnAvis(string nomSeo)
        {
            var formation = _context.Formation.First(f=> f.NomSeo==nomSeo);
            var avis = new Avis();
            if(formation != null)
            {
                avis.FormationId = formation.Id;
            }
            else
            {
                return RedirectToAction("ToutesLesFormations", "Formation");
            }
            return View(avis);
        }

        [HttpPost]
        public IActionResult AjouterUnAvis(Avis avis)
        {
            avis.DateAvis = DateTime.Now;
            _context.Avis.Add(avis);
            _context.SaveChanges();
            var formation = _context.Formation.First(f => f.Id == avis.FormationId);
            return RedirectToAction("Details", "Formation", new {nomSeo=formation.NomSeo});
        }

    }
}
