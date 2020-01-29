using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtleticaCore.Model
{
    public class Usuario
    {
        public int ID { get; set; }
        public string NOME { get; set; }
        public string CPF { get; set; }
        public string EMAIL { get; set; }
        public bool APROVADO { get; set; }
    }
}
