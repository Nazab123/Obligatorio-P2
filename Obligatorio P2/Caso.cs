using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio_P2
{
    internal class Caso
    {
        public static int UltimoId { get; set; } = 0;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Boolean Cerrado { get; set; }
        public Sospechoso Sospechoso { get; set; }
        public Investigador Detective { get; set; }
        public List<Evidencia> Evidencias { get; set; }

        public Caso(string nombre, string descripcion, bool cerrado,
            Sospechoso sospechoso, Investigador detective)
        {
            UltimoId++;
            Id = UltimoId;

            Nombre = nombre;
            Descripcion = descripcion;
            Cerrado = cerrado;
            Sospechoso = sospechoso;
            Detective = detective;

            // Inicializo la lista para que el caso pueda almacenar evidencias
            Evidencias = new List<Evidencia>();
        }

        public override string ToString()
        {
            return $"Id: {Id} - Nombre: {Nombre} - Descripción: {Descripcion} - Cerrado: {Cerrado}";
        }

    }
}
