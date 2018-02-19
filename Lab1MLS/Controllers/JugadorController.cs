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
        public ActionResult ElegirLista()
        {
            return View();
        }

        // POST: Jugador/ElegirLista
        [HttpPost]
        public ActionResult ElegirLista(string submitButton)
        {
            try
            {
                ArchivoLog.EmpezarLog();
                switch (submitButton)
                {
                    case "Lista Genérica":
                        Data.instance.tipoDeLista = 0;
                        break;
                    case "Lista Propia":
                        Data.instance.tipoDeLista = 1;
                        break;
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Jugador
        public ActionResult Index()
        {
            if (Data.instance.tipoDeLista == 0)
            {
                return View(Data.instance.Jugadores);
            }
            else
            {
                return View(Data.instance.JugadoresLA.GenerarLista());
            }                     
        }

        // GET: Jugador/Details/5
        public ActionResult Details(int id)
        {
            if (Data.instance.tipoDeLista == 0)
            {
                Data.instance.Tiempos.EmpezarTiempo();
                Jugador j2 = null;
                foreach (var j1 in Data.instance.Jugadores)
                {
                    if (j1.Id == id)
                    {
                        j2 = j1;
                        break;
                    }
                }

                ArchivoLog.EscribirLinea("Detalles de " + j2.Name + ": " + Data.instance.Tiempos.DetenerTiempo());
                
                return View(j2);
            }
            else
            {
                Data.instance.Tiempos.EmpezarTiempo();
                Jugador j2 = Data.instance.JugadoresLA.findWhere(Jugador => Jugador.Id == id);
                ArchivoLog.EscribirLinea("Detalles de " + j2.Name + ": " + Data.instance.Tiempos.DetenerTiempo());
                return View(j2);
            }

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
                if (Data.instance.tipoDeLista == 0)
                {
                    Data.instance.Tiempos.EmpezarTiempo();
                    Data.instance.Jugadores.AddLast(new Jugador
                    {
                        Id = Data.instance.Jugadores.Count + 1,
                        Name = collection["Name"],
                        LastName = collection["LastName"],
                        Position = collection["Position"],
                        SalarioBase = collection["SalarioBase"],
                        SalarioTotal = collection["SalarioTotal"],
                        Club = collection["Club"]
                    });
                    ArchivoLog.EscribirLinea("Crear nuevo jugador: " + Data.instance.Tiempos.DetenerTiempo());
                    return RedirectToAction("Index");
                }
                else
                {
                    Data.instance.Tiempos.EmpezarTiempo();
                    Data.instance.JugadoresLA.InsertarFinal(new Jugador
                    {
                        Id = Data.instance.Jugadores.Count + 1,
                        Name = collection["Name"],
                        LastName = collection["LastName"],
                        Position = collection["Position"],
                        SalarioBase = collection["SalarioBase"],
                        SalarioTotal = collection["SalarioTotal"],
                        Club = collection["Club"]
                    });
                    ArchivoLog.EscribirLinea("Crear nuevo jugador: " + Data.instance.Tiempos.DetenerTiempo());
                    return RedirectToAction("Index");
                }
                
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
                Data.instance.Tiempos.EmpezarTiempo();
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
                            if (Data.instance.tipoDeLista == 0)
                            {
                                if (!string.IsNullOrEmpty(row))
                                {
                                    Data.instance.Jugadores.AddLast(new Jugador
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
                            else
                            {
                                if (!string.IsNullOrEmpty(row))
                                {
                                    Data.instance.JugadoresLA.InsertarFinal(new Jugador
                                    {
                                        Id = Data.instance.JugadoresLA.GetCantidad() + 1,
                                        Club = row.Split(',')[0],
                                        LastName = row.Split(',')[1],
                                        Name = row.Split(',')[2],
                                        Position = row.Split(',')[3],
                                        SalarioBase = row.Split(',')[4],
                                        SalarioTotal = row.Split(',')[5]
                                    });
                                }
                            }                            
                        }
                        contLinea++;
                    }
                }
                ArchivoLog.EscribirLinea("Crear por archivo: " + Data.instance.Tiempos.DetenerTiempo());
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
                Data.instance.Tiempos.EmpezarTiempo();
                // TODO: Add update logic here
                Jugador j1 = new Jugador
                {
                    Id = id,
                    SalarioTotal = collection["SalarioTotal"],
                    Club = collection["Club"]
                };

                if (Data.instance.tipoDeLista == 0)
                {
                    foreach (var j2 in Data.instance.Jugadores)
                    {
                        if (j2.Id == id)
                        {
                            LinkedListNode<Jugador> j3 = Data.instance.Jugadores.Find(j2);
                            j1.Name = j2.Name;
                            j1.LastName = j2.LastName;
                            j1.Position = j2.Position;
                            j1.SalarioBase = j2.SalarioBase;
                            Data.instance.Jugadores.AddBefore(j3, j1);
                            Data.instance.Jugadores.Remove(j2);
                            break;
                        }
                    }
                }
                else
                {
                    Jugador j2 = Data.instance.JugadoresLA.findWhere(Jugador => Jugador.Id == id);
                    j1.Name = j2.Name;
                    j1.LastName = j2.LastName;
                    j1.Position = j2.Position;
                    j1.SalarioBase = j2.SalarioBase;
                    Data.instance.JugadoresLA.EditarEspecifico(j1, j2);
                }
                ArchivoLog.EscribirLinea("Editar Jugador: " + Data.instance.Tiempos.DetenerTiempo());
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
            if (Data.instance.tipoDeLista == 0)
            {
                Data.instance.Tiempos.EmpezarTiempo();
                Jugador j2 = null;
                foreach (var j1 in Data.instance.Jugadores)
                {
                    if (j1.Id == id)
                    {
                        j2 = j1;
                        break;
                    }
                }
                ArchivoLog.EscribirLinea("Confirmar eliminación: " + Data.instance.Tiempos.DetenerTiempo());
                return View(j2);
            }
            else
            {
                Data.instance.Tiempos.EmpezarTiempo();
                Jugador j2 = Data.instance.JugadoresLA.findWhere(Jugador => Jugador.Id == id);
                ArchivoLog.EscribirLinea("Confirmar eliminación: " + Data.instance.Tiempos.DetenerTiempo());
                return View(j2);
            }
            
        }
       

        // POST: Jugador/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                if (Data.instance.tipoDeLista == 0)
                {
                    Data.instance.Tiempos.EmpezarTiempo();
                    foreach (var j2 in Data.instance.Jugadores)
                    {
                        if (j2.Id == id)
                        {
                            Data.instance.Jugadores.Remove(j2);

                            break;
                        }
                    }
                    ArchivoLog.EscribirLinea("Eliminar Jugador: " + Data.instance.Tiempos.DetenerTiempo());
                    return RedirectToAction("Index");
                }
                else
                {
                    Data.instance.Tiempos.EmpezarTiempo();
                    Jugador j2 = Data.instance.JugadoresLA.findWhere(Jugador => Jugador.Id == id);
                    Data.instance.JugadoresLA.Eliminar_especifico(j2);
                    ArchivoLog.EscribirLinea("Eliminar Jugador: " + Data.instance.Tiempos.DetenerTiempo());
                    return RedirectToAction("Index");
                }
                
            }
            catch
            {
                return View();
            }
        }
        public ActionResult EliminarPorArchivo()
        {
            return View();
        }
        // POST: Jugador/Create
        [HttpPost]
        public ActionResult EliminarPorArchivo(HttpPostedFileBase postedFile)
        {
            try
            {
                Data.instance.Tiempos.EmpezarTiempo();
                LinkedList<Jugador> JugadoresEliminados = new LinkedList<Jugador>();
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
                        if (contLinea != 0)
                        {
                            if (!string.IsNullOrEmpty(row))
                            {
                                JugadoresEliminados.AddLast(new Jugador
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

                if (Data.instance.tipoDeLista == 0)
                {
                    foreach (var j1 in JugadoresEliminados)
                    {
                        foreach (var j2 in Data.instance.Jugadores)
                        {
                            if (j1.Name.Equals(j2.Name) && j1.LastName.Equals(j2.LastName))
                            {
                                Data.instance.Jugadores.Remove(j2);
                                break;
                            }
                        }
                    }
                    ArchivoLog.EscribirLinea("Eliminar Jugadores por archivo: " + Data.instance.Tiempos.DetenerTiempo());
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var j1 in JugadoresEliminados)
                    {
                        Jugador j2 = Data.instance.JugadoresLA.findWhere(Jugador => ((Jugador.Name == j1.Name) && (Jugador.LastName == j1.LastName)));
                        Data.instance.JugadoresLA.Eliminar_especifico(j2);                                                
                    }
                    ArchivoLog.EscribirLinea("Eliminar Jugadores por archivo: " + Data.instance.Tiempos.DetenerTiempo());
                    return RedirectToAction("Index");
                }
                
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Busqueda()
        {
            if (Data.instance.contadorbuscar == 0)
            {
                if (Data.instance.tipoDeLista == 0)
                {
                    return View(Data.instance.Jugadores);
                }
                else
                {
                    return View(Data.instance.JugadoresLA.GenerarLista());
                }
              
            }
            else
            {
                return View(Data.instance.retornar);
            }
            
        }

        // POST: Jugador/ElegirLista
        [HttpPost]
        public ActionResult Busqueda(string tipobuscar,FormCollection collection)
        {
            try
            {
                Data.instance.Tiempos.EmpezarTiempo();
                if (Data.instance.tipoDeLista == 0)
                {
                    var filterValue = collection["filter"];
                    switch (tipobuscar)
                    {
                        case "Nombre":
                            Data.instance.retornar = Data.instance.Jugadores.Where(x => x.Name == filterValue);
                            Data.instance.contadorbuscar++;
                            break;
                        case "Apellido":
                            Data.instance.retornar = Data.instance.Jugadores.Where(x => x.LastName == filterValue);
                            Data.instance.contadorbuscar++;
                            break;
                        case "Posicion":
                            Data.instance.retornar = Data.instance.Jugadores.Where(x => x.Position == filterValue);
                            Data.instance.contadorbuscar++;
                            break;
                        case "Salario Mayor":
                            Data.instance.retornar = Data.instance.Jugadores.Where(x => Convert.ToDouble(x.SalarioBase) >= Convert.ToDouble(filterValue));
                            Data.instance.contadorbuscar++;
                            break;
                        case "Salario Menor":
                            Data.instance.retornar = Data.instance.Jugadores.Where(x => Convert.ToDouble(x.SalarioBase) < Convert.ToDouble(filterValue));
                            Data.instance.contadorbuscar++;
                            break;
                        case "Salario Igual":
                            Data.instance.retornar = Data.instance.Jugadores.Where(x => x.SalarioBase ==filterValue);
                            Data.instance.contadorbuscar++;
                            break;
                        case "Club":
                            Data.instance.retornar = Data.instance.Jugadores.Where(x => x.Club == filterValue);
                            Data.instance.contadorbuscar++;
                            break;
                        case "Buscar De nuevo":
                            Data.instance.contadorbuscar = 0;
                            break;
                        default:
                            Data.instance.contadorbuscar = 0;
                            break;
                    }                    
                }
                else
                {
                    var filterValue = collection["filter"];
                    switch (tipobuscar)
                    {
                        case "Nombre":
                            Data.instance.retornar = Data.instance.JugadoresLA.where(x => x.Name == filterValue);
                            Data.instance.contadorbuscar++;
                            break;
                        case "Apellido":
                            Data.instance.retornar = Data.instance.JugadoresLA.where(x => x.LastName == filterValue);
                            Data.instance.contadorbuscar++;
                            break;
                        case "Posicion":
                            Data.instance.retornar = Data.instance.JugadoresLA.where(x => x.Position == filterValue);
                            Data.instance.contadorbuscar++;
                            break;
                        case "Salario Mayor":
                            Data.instance.retornar = Data.instance.JugadoresLA.where(x => Convert.ToDouble(x.SalarioBase) > Convert.ToDouble(filterValue));
                            Data.instance.contadorbuscar++;
                            break;
                        case "Salario Menor":
                            Data.instance.retornar = Data.instance.JugadoresLA.where(x => Convert.ToDouble(x.SalarioBase) < Convert.ToDouble(filterValue));
                            Data.instance.contadorbuscar++;
                            break;
                        case "Salario Igual":
                            Data.instance.retornar = Data.instance.JugadoresLA.where(x => x.SalarioBase == filterValue);
                            Data.instance.contadorbuscar++;
                            break;
                        case "Club":
                            Data.instance.retornar = Data.instance.JugadoresLA.where(x => x.Club == filterValue);
                            Data.instance.contadorbuscar++;
                            break;
                        case "Buscar De nuevo":
                            Data.instance.contadorbuscar = 0;
                            break;
                        default:
                            Data.instance.contadorbuscar = 0;
                            break;
                    }
                }

                ArchivoLog.EscribirLinea("Busqueda de Jugadores: " + Data.instance.Tiempos.DetenerTiempo());
                return RedirectToAction("Busqueda");
            }
            catch
            {
                return View();
            }
        }        
    }
}
