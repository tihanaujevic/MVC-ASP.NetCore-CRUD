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
    public class UtrkaController : Controller
    {
        private readonly sportContext _context;

        public UtrkaController(sportContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            List<Utrka> utrke = _context.Utrkas.ToList();
            return View(utrke);
        }

        public IActionResult Details (int Id)
        {
            Utrka utrka = _context.Utrkas.Where(u => u.IdUtrka == Id).FirstOrDefault();
            return View(utrka);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Utrka utrka = _context.Utrkas.Where(u => u.IdUtrka == Id).FirstOrDefault();
            return View(utrka);
        }

        [HttpPost]
        public IActionResult Edit(Utrka utrka)
        {
            _context.Attach(utrka);
            _context.Entry(utrka).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Utrka utrka = _context.Utrkas.Where(u => u.IdUtrka == Id).FirstOrDefault();
            return View(utrka);
        }

        [HttpPost]
        public IActionResult Delete(Utrka utrka)
        {
            _context.Attach(utrka);
            _context.Entry(utrka).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            Utrka utrka = new Utrka();
            return View(utrka);
        }

        [HttpPost]
        public IActionResult Create(Utrka utrka)
        {
            var utrkaid = _context.Utrkas.Max(utrId => utrId.IdUtrka);
            utrka.IdUtrka = utrkaid + 1;
            _context.Attach(utrka);
            _context.Entry(utrka).State = EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
