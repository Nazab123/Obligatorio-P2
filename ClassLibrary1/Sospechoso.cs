using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio_P2
{
    public class Sospechoso : IValidable
    {
        private static int UltimoId { get; set; } = 0;
        public int Id { get; private set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public DateTime Nacimiento { get; set; }
        public Boolean Antecedentes { get; set; }

        public Sospechoso (string nombre, string cedula, DateTime nacimiento, Boolean antecedentes)
        {
            UltimoId++;
            Id = UltimoId;

            Nombre = nombre;
            Cedula = cedula;
            Nacimiento = nacimiento;
            Antecedentes = antecedentes;
        }


        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre del sospechoso no puede estar vacío");
            }

            if (string.IsNullOrEmpty(Cedula))
            {
                throw new Exception("La cédula del sospechoso no puede estar vacía");
            }

            if (Nacimiento > DateTime.Today)
            {
                throw new Exception("La fecha de nacimiento no puede ser futura");
            }
        }



        //metodos

        public override bool Equals(object obj)
        {
            // Intento convertir el objeto recibido a un Sospechoso.
            // Si el objeto no es de tipo Sospechoso, el resultado va a ser null.
            var sospechoso = obj as Sospechoso;

            // Primero verifico que la conversión haya salido bien,
            // o sea, que realmente me hayan pasado un Sospechoso.
            // Después comparo solamente la cédula,
            // porque la cédula es el dato único del sospechoso.
            return sospechoso != null &&
                   Cedula == sospechoso.Cedula;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre} - Cédula: {Cedula} - Fecha de nacimiento: {Nacimiento.ToShortDateString()} - Antecedentes: {Antecedentes}";
        }

    }
}
