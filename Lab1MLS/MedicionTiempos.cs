using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace Lab1MLS
{
    public class MedicionTiempos
    {
        Stopwatch stopWatch = new Stopwatch();
        StreamWriter escritor;

        public MedicionTiempos()
        {
            string ruta = ("~/Log/");
            if (!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
            }

            escritor = new StreamWriter(ruta + "Log.txt");
        }
        public void EscribirLinea(string linea)
        {                        
            escritor.WriteLine(linea);
        }  

        public void DetenerEscritor()
        {
            escritor.Close();
        }
        
        public void EmpezarTiempo()
        {
            stopWatch.Start();            
        }              

        public string DetenerTiempo()
        {
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);

            return elapsedTime;        
        }
    }
}