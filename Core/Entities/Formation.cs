using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{

    public class Formation
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Url { get; set; }
        public string NomSeo { get; set; }
        public string Description { get; set; }
        public List<Avis> Avis { get; set; }
    }
}
