using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio_P2
{
    internal class Grabacion : Evidencia
    {
        public int Calidad { get; set; }
        public bool Infraganti { get; set; }

        public Grabacion(DateTime fecha, string descripcion, int calidad, bool infraganti)
            : base(fecha, descripcion)
        {
            Calidad = calidad;
            Infraganti = infraganti;
        }

        public override int CalcularPuntos()
        {
            int puntos = base.CalcularPuntos();

            if (Infraganti)
            {
                puntos += 60;
            }

            if (Calidad >= 3)
            {
                puntos += 10;
            }

            return puntos;
        }
    }
}
