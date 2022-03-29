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
    public class SportController : Controller
    {
        private readonly sportContext _context;

        public SportController(sportContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Sport> sportovi = _context.Sports.ToList();
            return View(sportovi);
        }

        public IActionResult Details (int Id)
        {
            Sport sport = _context.Sports.Where(s => s.IdSport == Id).FirstOrDefault();
            return View(sport);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Sport sport = _context.Sports.Where(u => u.IdSport == Id).FirstOrDefault();
            return View(sport);
        }

        [HttpPost]
        public IActionResult Edit(Sport sport)
        {
            _context.Attach(sport);
            _context.Entry(sport).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Sport sport = _context.Sports.Where(u => u.IdSport == Id).FirstOrDefault();
            return View(sport);
        }

        [HttpPost]
        public IActionResult Delete(Sport sport)
        {
            _context.Attach(sport);
            _context.Entry(sport).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            Sport sport = new Sport();
            return View(sport);
        }

        [HttpPost]
        public IActionResult Create(Sport sport)
        {
            var sportid = _context.Sports.Max(sId => sId.IdSport);

            sport.IdSport = sportid + 1;
            _context.Attach(sport);
            _context.Entry(sport).State = EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
