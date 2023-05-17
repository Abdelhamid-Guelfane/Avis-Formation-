using Core.Entities;

namespace Web.Models
{
    public class DetailsFormationViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Url { get; set; }
        public string NomSeo { get; set; }
        public string Description { get; set; }
        public List<Avis> Avis { get; set; }
        public int NombreAvis { get; set; }
        public double note { get; set; }
    }
}
