using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Controllers
{
    public class AuthorController : Controller
    {
        private readonly LibraryContext _context;
        public AuthorController(LibraryContext context)
        {
            _context=context;
        }
        
        public IActionResult Index()
        {
            var authors = _context.Authors
                .Where(x => x.IsDeleted==false)
                .ToList();
            return View(authors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            _context.Add(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
          public IActionResult Details(int id)
        {
            Author author = _context.Authors.Find(id);
            return View(author);
        }
        public IActionResult GetDeletedAuthors()
        {
            var authors = _context.Authors
                .Where(x => x.IsDeleted==true)
                .ToList();
            return View("Index",authors);
        }
        public IActionResult Delete(int id)
        {
            var author = _context.Authors.Find(id);
            return View(author);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var author = _context.Authors.Find(id);
            author.IsDeleted=true;
            _context.Authors.Update(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var author = _context.Authors.Find(id);
            return View(author);
        }

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}