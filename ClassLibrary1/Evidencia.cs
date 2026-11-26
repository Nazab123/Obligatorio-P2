using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio_P2
{ //Agrego : IValidable para que la clase sea validable
    public abstract class Evidencia : IValidable
    {
        private static int UltimoId { get; set; } = 0;
        public int Id { get; private set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Descripcion { get; set; }



    public Evidencia (DateTime fecha, DateTime fechaRegistro, String descripcion)
        {
            UltimoId++;

            Id = UltimoId;
            Fecha = fecha;
            FechaRegistro = fechaRegistro;
            Descripcion = descripcion;

        }
        //Agrego validaciones segun la letra 



        public virtual void Validar()
        {
            if (string.IsNullOrEmpty(Descripcion))
            {
                throw new Exception("La descripción de la evidencia no puede estar vacía");
            }

            if (Fecha > FechaRegistro)
            {
                throw new Exception("La fecha de recolección no puede ser posterior a la fecha de registro");
            }

            if (FechaRegistro > DateTime.Today)
            {
                throw new Exception("La fecha de registro no puede ser futura");
            }
        }

        public virtual int CalcularPuntos()
        {
            int puntos = 0;

            int meses = (DateTime.Today.Year - Fecha.Year) * 12
                      + (DateTime.Today.Month - Fecha.Month);

            if (meses < 6 || (meses == 6 && Fecha.Day > DateTime.Today.Day))
            {
                puntos = 5;
            }
            else
            {
                puntos = 3;
            }

            return puntos;
        }


        public override string ToString()
        {
            return $"ID: {Id} - Descripción: {Descripcion}";
        }

    }
}
