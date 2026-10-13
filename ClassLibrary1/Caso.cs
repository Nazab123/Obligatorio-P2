using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio_P2
{
    // Se declara la clase como public para que pueda ser utilizada
    // desde el proyecto de consola, ya que pertenece al proyecto de dominio.

    public class Caso : IValidable
    {//caso de compromete a usar el metood validar ()
        private static int UltimoId { get; set; } = 0;
        public int Id { get; private set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Boolean Cerrado { get; set; }
        public Sospechoso Sospechoso { get; set; }
        public Investigador Detective { get; set; }
        public List<Evidencia> Evidencias { get; private set; }
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

        //Cree la validar con sus validaciones segun la eltra
        public void Validar()
        {
           
            if (string.IsNullOrEmpty(Nombre)){
                throw new Exception("El nombre del caso no puede estar vacío");
            }

           
            if (string.IsNullOrEmpty(Descripcion)){
                throw new Exception("La descripción del caso no puede estar vacía");
            }

            
            if (Sospechoso == null){
                throw new Exception("El caso debe tener un sospechoso");
            }

            
            if (Detective == null){
                throw new Exception("El caso debe tener un detective");
            }

            
            if (Detective.Rol != Rol.DETECTIVE){
                throw new Exception("El investigador asignado debe tener rol DETECTIVE");
            }
        }



        public void AgregarEvidencia(Evidencia e)
        {
            if (e == null)
            {
                throw new Exception("La evidencia no puede ser nula");
            }

            e.Validar();

            if (Evidencias.Contains(e))
            {
                throw new Exception("La evidencia ya está asociada al caso");
            }

            Evidencias.Add(e);
        }


        public override string ToString()
        {
            return $"Id: {Id} - Nombre: {Nombre} - Descripción: {Descripcion} - Cerrado: {Cerrado}";
        }

    }
}
