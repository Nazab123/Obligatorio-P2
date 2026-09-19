using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio_P2
{
    internal class Caso
    {
        public static int UltimoId { get; set; } = 0;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Boolean Cerrado { get; set; }
        public Sospechoso Sospechoso { get; set; }
        public Investigador Detective { get; set; }
        public List<Evidencia> Evidencias { get; set; }



    }
}
