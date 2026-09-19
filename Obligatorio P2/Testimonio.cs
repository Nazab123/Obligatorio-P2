using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio_P2
{
    internal class Testimonio : Evidencia
    {
        public string NombreTestigo { get; set; }
        public Credibilidad Credibilidad { get; set; }

        public Testimonio(
            DateTime fecha,
            string descripcion,
            string nombreTestigo,
            Credibilidad credibilidad
        ) : base(fecha, descripcion)
        {
            NombreTestigo = nombreTestigo;
            Credibilidad = credibilidad;
        }

        public override int CalcularPuntos()
        {
            //calulcar puntoss
        }
    }
}
