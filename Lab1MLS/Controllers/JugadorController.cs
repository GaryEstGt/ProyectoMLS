﻿using Lab1MLS.Models;
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
            return View(Data.instance.Jugadores);
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
                Data.instance.Jugadores.Add(new Jugador
                {
                    Id = Data.instance.Jugadores.Count + 1,
                    Name = collection["Name"],
                    LastName = collection["LastName"],
                    Position = collection["Position"],
                    SalarioBase = collection["SalarioBase"],
                    SalarioTotal = collection["SalarioTotal"],
                    Club = collection["Club"]
                });
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

                    int contLinea = 0;
                    string csvData = System.IO.File.ReadAllText(filePath);                    
                    foreach (string row in csvData.Split('\n'))
                    {
                        if (contLinea!= 0)
                        {
                            if (!string.IsNullOrEmpty(row))
                            {
                                Data.instance.Jugadores.Add(new Jugador
                                {
                                    Id = Data.instance.Jugadores.Count + 1,
                                    Club = row.Split(',')[0],
                                    LastName = row.Split(',')[1],
                                    Name = row.Split(',')[2],
                                    Position = row.Split(',')[3],
                                    SalarioBase = row.Split(',')[4],
                                    SalarioTotal = row.Split(',')[5]
                                });
                            }
                        }
                        contLinea++;
                    }
                }
                return RedirectToAction("Index");
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
