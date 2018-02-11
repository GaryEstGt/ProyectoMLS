using Lab1MLS.Models;
using ListaBiblioteca;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab1MLS.Controllers
{
    public class JugadorController : Controller
    {
        // GET: Jugador
        public ActionResult Index()
        {
            return View(new List<Jugador> { new Jugador { Id = 1, Name = "Gary", LastName = "Moran", Club = "Chicago Fire", Position = "D", SalarioBase = "100000", SalarioTotal = "12341234" },
            new Jugador { Id = 1, Name = "Gary", LastName = "Moran", Club = "Chicago Fire", Position = "D", SalarioBase = "100000", SalarioTotal = "12341234" }});
        }

        // GET: Jugador/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Jugador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jugador/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CrearPorArchivo()
        {
            return View();
        }

        // POST: Jugador/Create
        [HttpPost]
        public ActionResult CrearPorArchivo(HttpPostedFileBase postedFile)
        {
            try
            {
                Data.Instance
                string filePath = string.Empty;
                if (postedFile != null)
                {
                    string path = Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    filePath = path + Path.GetFileName(postedFile.FileName);
                    string extension = Path.GetExtension(postedFile.FileName);
                    postedFile.SaveAs(filePath);

                    string csvData = System.IO.File.ReadAllText(filePath);                    
                    foreach (string row in csvData.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(row))
                        {
                            customers.Add(new Jugador
                            {
                                Id = Convert.ToInt32(row.Split(',')[0]),
                                Name = row.Split(',')[1],
                                Pais = row.Split(',')[2]
                            });
                        }
                    }
                }
                return View(customers);
            }
            catch
            {
                return View();
            }
        }

        // GET: Jugador/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Jugador/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Jugador/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Jugador/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
