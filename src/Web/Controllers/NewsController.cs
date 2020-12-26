using Business.IServices;
using Contract.Dtos.News;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class NewsController : Controller
    {
        public INewsService newsService;
        public NewsController(INewsService _newsService)
        {
            newsService = _newsService;
        }
        // GET: NewsController
        public ActionResult Index()
        {
            return View(newsService.GetAll());
        }

        // GET: NewsController/Details/5
        public ActionResult Details(int id)
        {
            var news = newsService.Get(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        // GET: NewsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateNewsDto news)
        {
            try
            {
                newsService.Create(news);
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View(news);
            }
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = newsService.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GetNewsDto news)
        {
            if (id != news.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                newsService.Edit(news);
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        // GET: NewsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NewsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                newsService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
