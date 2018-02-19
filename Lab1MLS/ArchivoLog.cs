using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Lab1MLS
{
    public class ArchivoLog
    {
        static string filename;
        public static void EmpezarLog()
        {
            filename = "Log.txt";            
        }
        public static void EscribirLinea(string Log)
        {            
            StreamWriter w = File.AppendText(HttpContext.Current.Server.MapPath(path: @"~\Log\" + filename));
            w.WriteLine(Log);            
            w.Close();
        }
    }
}