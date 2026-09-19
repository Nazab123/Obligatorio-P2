using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio_P2
{
    internal class Fisica : Evidencia
    {
        public bool Huellas { get; set; }

        public Fisica(DateTime fecha, string descripcion, bool huellas)
            : base(fecha, descripcion)
        {
            Huellas = huellas;
        }

        public override int CalcularPuntos()
        {
            //logica d puntosss
        }
    }
}