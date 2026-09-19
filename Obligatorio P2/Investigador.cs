using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio_P2
{
    internal class Investigador
    {
        public static int UltimoId { get; set; } = 0;

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public Rol Rol { get; set; }

        public Investigador (string email, string password, string nombre, Rol rol)
        {
            UltimoId++;
            Id = UltimoId;

            Email = email;
            Password = password;
            Nombre = nombre;
            Rol = rol;
        }

        //El sistema registra investigadores de los cuales se conoce un email que debe ser único entre los investigadores
        //Equals
        //to string para poider mostrar el objeto facilmente


    }
}
