using CRUD.Models;
using CRUD.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace CRUD.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BooksController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Books
        public ActionResult Index()
        {
            var books = _context.Books.Include(m=>m.Category).ToList();
            return View(books);
        }
        public ActionResult Create()
        {
            var viewModel = new BookFormViewModel
            {
                Categories = _context.Categories.Where(m => m.IsActive).ToList(),
            };
            return View("BookForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(BookFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _context.Categories.Where(m => m.IsActive).ToList();
                return View("BookForm", model);
            }
            if (model.Id == 0) {
                var book = new Book
                {
                    Title = model.Title,
                    Author = model.Author,
                    CategoryId = model.CategoryId,
                    Discription = model.Discription

                };
                _context.Books.Add(book);
            }
            else
            {
                var book = _context.Books.Find(model.Id);
                if (book == null)
                    return HttpNotFound();
                book.Title = model.Title;
                book.Author = model.Author;
                book.CategoryId = model.CategoryId;
                book.Discription = model.Discription;

            }
           
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         
            var book = _context.Books.Include(m=>m.Category).SingleOrDefault(m=>m.Id==id);
            if (book == null)
                return HttpNotFound();
            return View(book);
        }
        public ActionResult Edit(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var book = _context.Books.Find(id);
            if (book == null)
                return HttpNotFound();

            var viewModel = new BookFormViewModel
            {
                Id=id,
                Title=book.Title,
                Author=book.Author,
                Discription=book.Discription,
                Categories = _context.Categories.Where(m => m.IsActive).ToList(),
                CategoryId =book.CategoryId,
            };
            return View("BookForm", viewModel);
        }
    }
}