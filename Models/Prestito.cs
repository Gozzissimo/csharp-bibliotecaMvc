using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace csharp_bibliotecaMvc.Models
{
    public class Prestito
    {
        public int PrestitoId { get; set; }
        public int UtenteId { get; set; }
        public string LibroId { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        //FK
        public virtual Utente Utente { get; set; }
        public virtual Libro Libro { get; set; }
    }
}
