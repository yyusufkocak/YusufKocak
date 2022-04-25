using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryContext _context;
        public BookController(LibraryContext context)
        {
            _context=context;
        }

        public IActionResult Index()
        {
            var books = _context.Books
                .Where(x => x.IsDeleted==false)
                .ToList();
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            _context.Add(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
         public IActionResult Details(int id)
        {
            Book book = _context.Books
                        .Include(k => k.Category)
                        .Include(k => k.Publisher)
                        .Include(k => k.Author)
                        .First(s => s.BookId == id);
            return View(book);
        }
        public IActionResult GetDeletedPublishers()
        {
            var books = _context.Books
                .Where(x => x.IsDeleted==true)
                .ToList();
            return View("Index",books);
        }
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);
            return View(book);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _context.Books.Find(id);
            book.IsDeleted=true;
            _context.Books.Update(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var book = _context.Books.Find(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}