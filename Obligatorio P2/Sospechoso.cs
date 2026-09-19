using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio_P2
{
    internal class Sospechoso
    {
        public static int UltimoId { get; set; } = 0;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public DateTime Nacimiento { get; set; }
        public Boolean Antecedentes { get; set; }

    }
}
