using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio_P2
{
    internal abstract class Evidencia
    {
        public static int UltimoId { get; set; } = 0;

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }



    public Evidencia (DateTime fecha, String descripcion)
        {
            UltimoId++;

            Id = UltimoId;
            Fecha = fecha;
            Descripcion = descripcion;

        }

        public virtual int CalcularPuntos()
        {
            int puntos = 0;

            if (Fecha > DateTime.Today.AddMonths(-6))
            {
                puntos = 5;
            }
            else
            {
                puntos = 3;
            }

            return puntos;
        }
    }
}
