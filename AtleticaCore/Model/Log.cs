using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtleticaCore.Model
{
    public class Log
    {
        public int ID { get; set; }
        public string LOGIN { get; set; }
        public string ACTION { get; set; }
        public DateTime DATAHORA { get; set; }
    }
}
