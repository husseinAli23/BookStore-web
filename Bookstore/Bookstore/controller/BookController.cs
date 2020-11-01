using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Model;
using Bookstore.Model.Repository;
using Bookstore.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.controller
{
    public class BookController : Controller
    {
        private readonly IBookstoreRepository<Book> bookRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public IBookstoreRepository<Auther> AutherRepository { get; }


        public BookController(IBookstoreRepository<Book> bookRepository, IBookstoreRepository<Auther> autherRepository, IWebHostEnvironment webHostEnvironment)
        {
            this.bookRepository = bookRepository;
            AutherRepository = autherRepository;
            this.webHostEnvironment = webHostEnvironment;
        }

        // GET: BookController
        public ActionResult Index()
        {
            var book = bookRepository.List();

            return View(book);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var book = bookRepository.Find(id);
            return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {

            var model = new BookAutherViewModel
            {
                Authers = FullListAuthers()
            };

            return View(model);
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookAutherViewModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    string filename = UploadFile(model.File) ?? String.Empty;

                    if (model.autherID == -1)
                    {
                        ViewBag.Message = "please select an auther from the list";

                        return View(fillList());
                    }
                    Book book = new Book
                    {
                        Title = model.Title,
                        description = model.Description,
                        Auther = AutherRepository.Find(model.autherID),
                        ImageURL = model.File.FileName

                    };
                    bookRepository.add(book);


                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }

            ModelState.AddModelError("", "You have to fill all the required fields");

            return View(fillList());
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var book = bookRepository.Find(id);
            var viewModel = new BookAutherViewModel
            {
                bookID = book.ID,
                Title = book.Title,
                Description = book.description,
                autherID = book.Auther.id,
                Authers = AutherRepository.List().ToList(),
                ImageURL = book.ImageURL
            };

            return View(viewModel);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookAutherViewModel model)
        {
            try
            {
                string filename = UploadFile(model.File,model.ImageURL);
 
                Book book = new Book
                {
                    ID = model.bookID,
                    Title = model.Title,
                    description = model.Description,
                    Auther = AutherRepository.Find(model.autherID),
                    ImageURL = filename

                };
                bookRepository.update(model.bookID, book);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var book = bookRepository.Find(id);
            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Book book)
        {
            try
            {
                bookRepository.delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult search(String term)
        {
            var result = bookRepository.Search(term);

            return View("Index",result);
        }

        List<Auther> FullListAuthers()
        {
            var authers = AutherRepository.List().ToList();
            authers.Insert(0, new Auther { id = -1, Fullname = "--- please select an auther ---" });
            return authers;

        }

        BookAutherViewModel fillList()
        {
            var vmodel = new BookAutherViewModel
            {
                Authers = FullListAuthers()
            };

            return vmodel;
        }
        String UploadFile(IFormFile file)
        {
            if (file != null)
            {
                String uploads = Path.Combine(webHostEnvironment.WebRootPath, "uploads");
                String FullPath = Path.Combine(uploads, file.FileName);
                file.CopyTo(new FileStream(FullPath, FileMode.Create));

                return file.FileName;
            }
            return null;
        }

        String UploadFile(IFormFile file, String ImageURL)
        {
            if (file != null)
            {
                String uploads = Path.Combine(webHostEnvironment.WebRootPath, "uploads");
                String newPath = Path.Combine(uploads, file.FileName);
                String oldPath = Path.Combine(uploads, ImageURL);

                if (newPath != oldPath)
                {
                    System.IO.File.Delete(oldPath);
                    file.CopyTo(new FileStream(newPath, FileMode.Create));
                    return file.FileName;
                }
            }
            return ImageURL;
        }
    }
}
