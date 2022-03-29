using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp_Sport.Data;
using WebApp_Sport.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApp_Sport.Controllers
{
    public class PobjednikController : Controller
    {
        private readonly sportContext _context;

        public PobjednikController(sportContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Pobjednik> pobjednici = _context.Pobjedniks.ToList();

            return View(pobjednici);
        }

        public IActionResult Details (int Id)
        {
            Pobjednik pobjednik = _context.Pobjedniks.Where(p =>
              p.IdPobjednik == Id).FirstOrDefault();
            return View(pobjednik);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Pobjednik pobjednik = _context.Pobjedniks.Where(p =>
              p.IdPobjednik == Id).FirstOrDefault();
            return View(pobjednik);
        }

        [HttpPost]
        public IActionResult Edit(Pobjednik pobjednik)
        {
            _context.Attach(pobjednik);
            _context.Entry(pobjednik).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Pobjednik pobjednik = _context.Pobjedniks.Where(p =>
              p.IdPobjednik == Id).FirstOrDefault();
            return View(pobjednik);
        }

        [HttpPost]
        public IActionResult Delete(Pobjednik pobjednik)
        {
            _context.Attach(pobjednik);
            _context.Entry(pobjednik).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            Pobjednik pobjednik = new Pobjednik();
            return View(pobjednik);
        }

        [HttpPost]
        public IActionResult Create( Pobjednik pobjednik)
        {
            var pobjednikid = _context.Pobjedniks.Max(pobId => pobId.IdPobjednik);

            pobjednik.IdPobjednik = pobjednikid+1;
            _context.Attach(pobjednik);
            _context.Entry(pobjednik).State = EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
