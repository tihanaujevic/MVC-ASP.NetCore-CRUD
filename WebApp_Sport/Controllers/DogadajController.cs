using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp_Sport.Data;
using Microsoft.EntityFrameworkCore;
using WebApp_Sport.Models;

namespace WebApp_Sport.Controllers
{
    public class DogadajController : Controller
    {
        private readonly sportContext _context;

        public DogadajController(sportContext context)
        {
            _context = context;
        }
        public IActionResult Index(string searching)
        {
            
            var dogadajiList = _context.Dogadajs.Select(x => new Dogadaj
            {
                IdDogadaj = x.IdDogadaj,
                IdUtrka = x.IdUtrka,
                IdSport = x.IdSport,
                IdPobjednik = x.IdPobjednik,
                Datum = x.Datum,
                NazivSporta = x.IdSportNavigation.Naziv,
                NazivUtrke=x.IdUtrkaNavigation.Naziv,
                NazivPobjednika=x.IdPobjednikNavigation.Ime
            }).ToList();
            if (!String.IsNullOrEmpty(searching))
            {
                searching = searching.ToLower();
                dogadajiList = dogadajiList.Where(s => s.NazivPobjednika.ToLower().Contains(searching)
                                       || s.NazivUtrke.ToLower().Contains(searching)
                                       || s.NazivSporta.ToLower().Contains(searching)
                                       || s.Datum.ToString().Contains(searching)).ToList();
            }
            return View(dogadajiList);
        }

    }
}
