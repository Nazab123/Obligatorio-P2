using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio_P2
{
    public class Grabacion : Evidencia
    {
        public int Calidad { get; set; }
        public bool Infraganti { get; set; }


        public Grabacion(DateTime fecha, DateTime fechaRegistro, string descripcion, int calidad, bool infraganti) : base(fecha, fechaRegistro, descripcion){
            Calidad = calidad;
            Infraganti = infraganti;
        }


        public override void Validar()
        {
            base.Validar();

            if (Calidad < 1 || Calidad > 5)
            {
                throw new Exception("La calidad de la grabación debe estar entre 1 y 5");
            }
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
