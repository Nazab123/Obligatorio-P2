using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio_P2
{
    public class Fisica : Evidencia
    {
        public bool Huellas { get; set; }


        public Fisica(DateTime fecha, DateTime fechaRegistro, string descripcion, bool huellas) : base(fecha, fechaRegistro, descripcion) {
            Huellas = huellas;
        }


        public override void Validar()
        {
            
            base.Validar();
        }

        public override int CalcularPuntos()
        {
            int puntos = base.CalcularPuntos();

            if (Huellas)
            {
                puntos += 40;
            }

            return puntos;
        }


        public override string ToString()
        {
            return $"{base.ToString()} - Huellas: {Huellas}";
        }


    }
}