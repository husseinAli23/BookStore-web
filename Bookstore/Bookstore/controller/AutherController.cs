using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Model;
using Bookstore.Model.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.controller
{
    public class AutherController : Controller
    {
        private readonly IBookstoreRepository<Auther> autherRepository;

        public AutherController(IBookstoreRepository<Auther> AutherRepository)
        {
            autherRepository = AutherRepository;
        }



        // GET: AutherController
        public ActionResult Index()
        {
            var auther = autherRepository.List();

            return View(auther);
        }

        // GET: AutherController/Details/5
        public ActionResult Details(int id)
        {
            var Auther = autherRepository.Find(id);
            return View(Auther);
        }

        // GET: AutherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Auther auther)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    autherRepository.add(auther);

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }

            
            return View();
          
        }

        // GET: AutherController/Edit/5
        public ActionResult Edit(int id)
        {
            var auther = autherRepository.Find(id);
            return View(auther);
        }

        // POST: AutherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Auther auther)
        {
            try
            {

                autherRepository.update(id, auther);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AutherController/Delete/5
        public ActionResult Delete(int id)
        {
            var auther = autherRepository.Find(id);

            return View(auther);
        }

        // POST: AutherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Auther auther)
        {
            try
            {
                autherRepository.delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
