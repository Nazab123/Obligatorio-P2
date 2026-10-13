using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio_P2
{
    public class Testimonio : Evidencia
    {
        public string NombreTestigo { get; set; }
        public Credibilidad Credibilidad { get; set; }
        //Abusaste 

        public Testimonio(DateTime fecha,DateTime fechaRegistro,string descripcion,string nombreTestigo,Credibilidad credibilidad) : base (fecha, fechaRegistro, descripcion){
            NombreTestigo = nombreTestigo;
            Credibilidad = credibilidad;
        }



        public override void Validar()
        {
            base.Validar();

            if (string.IsNullOrEmpty(NombreTestigo))
            {
                throw new Exception("El nombre del testigo no puede estar vacío");
            }

            if (Credibilidad != Obligatorio_P2.Credibilidad.BAJO &&
                Credibilidad != Obligatorio_P2.Credibilidad.MEDIO &&
                Credibilidad != Obligatorio_P2.Credibilidad.ALTO)
            {
                throw new Exception("La credibilidad no es válida");
            }
        }


        public override int CalcularPuntos()
        {
            int puntos = base.CalcularPuntos();

            if (Credibilidad == Obligatorio_P2.Credibilidad.MEDIO ||
                Credibilidad == Obligatorio_P2.Credibilidad.ALTO)
            {
                puntos += 10;
            }

            return puntos;
        }

        public override string ToString()
        {
            return $"{base.ToString()} - Testigo: {NombreTestigo} - Credibilidad: {Credibilidad}";
        }

    }
}
