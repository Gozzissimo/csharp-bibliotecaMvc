using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace csharp_bibliotecaMvc.Models
{
    public enum Stato {Disponibile,InPrestito}
    public class Libro
    {
        [Key]
        public string LibroId { get; set; }
        public string Titolo { get; set; }
        public string Scaffale { get; set; }
        public Stato Stato { get; set; }
        //FK
        public virtual ICollection<Prestito> Prestiti { get; set; }
        public virtual ICollection<Autore> Autori { get; set; }
    }
}
