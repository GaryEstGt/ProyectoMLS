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
        Stopwatch stopWatch;        

        public MedicionTiempos()
        {            
            stopWatch = new Stopwatch();
        }
        public void EscribirLinea(string linea)
        {
            Data.instance.Log += linea + "\n";            
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