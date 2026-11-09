
using System;
using System.Collections.Generic;

namespace Obligatorio_P2
{
    public class Caso : IValidable
    {
        private static int UltimoId { get; set; } = 0;

        public int Id { get; private set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Cerrado { get; set; }
        public Sospechoso Sospechoso { get; set; }
        public Investigador Detective { get; set; }

        // Lista privada para respetar el encapsulamiento
        private List<Evidencia> _evidencias;

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

            // Inicializamos la lista de evidencias
            _evidencias = new List<Evidencia>();
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre del caso no puede estar vacío");
            }

            if (string.IsNullOrEmpty(Descripcion))
            {
                throw new Exception("La descripción del caso no puede estar vacía");
            }

            if (Sospechoso == null)
            {
                throw new Exception("El caso debe tener un sospechoso");
            }

            if (Detective == null)
            {
                throw new Exception("El caso debe tener un detective");
            }

            if (Detective.Rol != Rol.DETECTIVE)
            {
                throw new Exception("El investigador asignado debe tener rol DETECTIVE");
            }
        }

        // Agrega evidencias realizando las validaciones
        public void AgregarEvidencia(Evidencia e)
        {
            if (e == null)
            {
                throw new Exception("La evidencia no puede ser nula");
            }

            e.Validar();

            if (_evidencias.Contains(e))
            {
                throw new Exception("La evidencia ya está asociada al caso");
            }

            _evidencias.Add(e);
        }

        // Devuelve una copia de la lista de evidencias
        public List<Evidencia> ObtenerEvidencias()
        {
            return new List<Evidencia>(_evidencias);
        }

        public override string ToString()
        {
            return $"Id: {Id} - Nombre: {Nombre} - Descripción: {Descripcion} - Cerrado: {Cerrado}";
        }
    }
}
