
using System;

namespace Obligatorio_P2
{
    internal class Program
    {
        static Sistema sistema = Sistema.ObtenerInstancia();


        static void Main(string[] args)
        {
            sistema.Precargar();

            string opcion = "";

            while (opcion != "0")
            {
                Console.WriteLine("===== SISTEMA FISCALIA =====");
                Console.WriteLine("1 - Listar casos y evidencias");
                Console.WriteLine("2 - Buscar casos por investigador");
                Console.WriteLine("3 - Alta de sospechoso");
                Console.WriteLine("4 - Listar sospechosos con antecedentes");
                Console.WriteLine("0 - Salir");

                Console.WriteLine("Ingrese una opcion:");
                opcion = Console.ReadLine();

                if (opcion == "1")
                {
                    ListarCasos();
                }
                else if (opcion == "2")
                {
                    BuscarCasosInvestigador();
                }
                else if (opcion == "3")
                {
                    AltaSospechoso();
                }
                else if (opcion == "4")
                {
                    ListarSospechososAntecedentes();
                }
                else if (opcion == "0")
                {
                    Console.WriteLine("Saliendo del sistema...");
                }
                else
                {
                    Console.WriteLine("Opcion incorrecta");
                }

                if (opcion != "0")
                {
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }


        static void ListarCasos()
        {
            List<Caso> casos = sistema.ListarCasos();

            if (casos.Count == 0)
            {
                Console.WriteLine("No hay casos registrados");
            }
            else
            {
                foreach (Caso c in casos)
                {
                    Console.WriteLine(c.ToString());

                    if (c.Evidencias.Count == 0)
                    {
                        Console.WriteLine("Este caso no tiene evidencias");
                    }
                    else
                    {

                        foreach (Evidencia e in c.Evidencias)
                        {
                            Console.WriteLine($"ID: {e.Id} - Descripción: {e.Descripcion}");
                        }

                    }
                }
            }
        }



        static void BuscarCasosInvestigador()
        {
            Console.WriteLine("Ingrese el email del investigador:");
            string email = Console.ReadLine();

            List<Caso> casos = sistema.BuscarCasosPorInvestigador(email);

            if (casos.Count == 0)
            {
                Console.WriteLine("No se encontraron casos para ese investigador");
            }
            else
            {
                foreach (Caso c in casos)
                {
                    Console.WriteLine($"ID: {c.Id} - Caso: {c.Nombre} - Investigador: {c.Detective.Nombre}");
                }
            }
        }



        static void AltaSospechoso()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre del sospechoso:");
                string nombre = Console.ReadLine();

                Console.WriteLine("Ingrese la cedula:");
                string cedula = Console.ReadLine();

                Console.WriteLine("Ingrese la fecha de nacimiento (dd/mm/aaaa):");
                DateTime fechaNacimiento = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Tiene antecedentes? (S/N):");
                string respuesta = Console.ReadLine();

                bool antecedentes = false;

                if (respuesta == "S")
                {
                    antecedentes = true;
                }
                else if (respuesta != "N")
                {
                    Console.WriteLine("Debe ingresar S o N");
                    return;
                }

                Sospechoso s = new Sospechoso(nombre, cedula, fechaNacimiento, antecedentes);

                sistema.AltaSospechoso(s);

                Console.WriteLine("Sospechoso registrado correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ListarSospechososAntecedentes()
        {
            List<Sospechoso> sospechosos = sistema.ListarSospechososConAntecedentes();

            if (sospechosos.Count == 0)
            {
                Console.WriteLine("No hay sospechosos con antecedentes");
            }
            else
            {
                foreach (Sospechoso s in sospechosos)
                {
                    Console.WriteLine($"Nombre: {s.Nombre}");
                    Console.WriteLine($"Cedula: {s.Cedula}");
                    Console.WriteLine($"Fecha de nacimiento: {s.Nacimiento.ToShortDateString()}");
                    Console.WriteLine($"Antecedentes: {s.Antecedentes}");
                    Console.WriteLine("-------------------------");
                }
            }
        }

    }
}
