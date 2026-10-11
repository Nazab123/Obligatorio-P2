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
            if (string.IsNullOrEmpty(NombreTestigo)){

                throw new Exception("El nombre del testigo no puede estar vacío");
            }
        }


        public override int CalcularPuntos()
        {
            //calulcar puntoss
        }
    }
}
