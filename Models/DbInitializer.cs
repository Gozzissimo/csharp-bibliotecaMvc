using csharp_bibliotecaMvc.Models;
using System;
using System.Linq;

namespace csharp_bibliotecaMvc.Models
{
    public static class DbInitializer
    {
        public static void Initialize(BibliotecaContext context)
        {
            //E' il metodo di EF che crea il database SOLO se già non c'è
            context.Database.EnsureCreated();

            //-----INSERT AUTORI
            if (context.Autori.Any())
            {
                return;   // DB has been seeded
            }

            var autori = new Autore[]
            {
            new Autore{ Nome = "Alessandro", Cognome = "Manzoni" },
            new Autore{ Nome = "Ken", Cognome = "Follet" },
            new Autore{ Nome = "Conan", Cognome = "Doyle" },
            new Autore{ Nome = "Dan", Cognome = "Brown" },
            new Autore{ Nome = "Stephen", Cognome = "King" },
            new Autore{ Nome = "Ernest", Cognome = "Hamingway" },
            new Autore{ Nome = "Leonardo", Cognome = "Sciascia" }
            };
            foreach (Autore autore in autori)
            {
                context.Autori.Add(autore);
            }
            context.SaveChanges();

            var Manzoni = context.Autori.Where(item => item.Cognome == "Manzoni").First();
            var Sciascia = context.Autori.Where(item => item.Cognome == "Sciascia").First();
            var Follet = context.Autori.Where(item => item.Cognome == "Follet").First();
            var Doyle = context.Autori.Where(item => item.Cognome == "Doyle").First();
            var King = context.Autori.Where(item => item.Cognome == "King").First();
            var Hamingway = context.Autori.Where(item => item.Cognome == "Hamingway").First();
            var Brown = context.Autori.Where(item => item.Cognome == "Brown").First();

            ///--------------------------------
            //LIBRI

            var libri = new Libro[]
            {
                new Libro{LibroId="14647621746", Titolo = "I promessi sposi", Autori = new List<Autore>{Manzoni}, Scaffale = "S02", Stato= Stato.Disponibile},
                new Libro{LibroId="14787621746", Titolo = "Il Codice da Vinci", Autori = new List<Autore>{Brown}, Scaffale = "S03", Stato= Stato.Disponibile},
                new Libro{LibroId="14647625646", Titolo = "Sherlock Holmes", Autori = new List<Autore>{Hamingway}, Scaffale = "S02", Stato= Stato.Disponibile},
                new Libro{LibroId="14647636746", Titolo = "Il giorno della Civetta", Autori = new List<Autore>{Sciascia}, Scaffale = "S01", Stato= Stato.Disponibile},
                new Libro{LibroId="17847621746", Titolo = "Una collaborazione improponibile", Autori = new List<Autore>{Brown, Manzoni}, Scaffale = "S02", Stato= Stato.Disponibile},
                new Libro{LibroId="14648721746", Titolo = "Un libro per 3", Autori = new List<Autore>{Sciascia, Doyle, Brown}, Scaffale = "S04", Stato= Stato.InPrestito},
            };
            foreach (Libro libro in libri)
            {
                context.Libri.Add(libro);
            }
            context.SaveChanges();

            ///--------------------------------
            //UTENTI
            var utenti = new Utente[]
            {
            new Utente{Nome="Franco",Cognome="Rossi", Email = "FrancoRossi@gmail.com"},
            new Utente{Nome="Giulio",Cognome="Storti", Email = "GiulioStorti@gmail.com"},
            new Utente{Nome="Marco",Cognome="Bianchi", Email = "MarcoB@gmail.com"},
            };

            foreach (Utente c in utenti)
            {
                context.Utenti.Add(c);
            }
            context.SaveChanges();

            ///--------------------------------
            //PRESITI

            var prestiti = new Prestito[]
            {
            new Prestito{PrestitoId=1,UtenteId=1,LibroId="14647636746",Inizio=DateTime.Parse("2022-06-05"),Fine=DateTime.Parse("2022-08-05") }
            };

            foreach (Prestito c in prestiti)
            {
                context.Prestiti.Add(c);
            }
            context.SaveChanges();
        }
    }
}
