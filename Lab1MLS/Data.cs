using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1MLS
{
    public class Data
    {
        private static Data instance = null;        

        private Data()
        {

        }

        public static Data Instance()
        {
            if (instance == null)
            {
                if (instance == null)
                    instance = new Data();                
            }

            return instance;
        }
    }
}