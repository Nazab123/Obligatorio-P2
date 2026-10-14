using System;
using System.Collections.Generic;

namespace Obligatorio_P2
{

    public class Sistema
    {
        private static Sistema _instancia = new Sistema();

        private List<Caso> _casos;
        private List<Investigador> _investigadores;
        private List<Sospechoso> _sospechosos;

        private Sistema()
        {
            _casos = new List<Caso>();
            _investigadores = new List<Investigador>();
            _sospechosos = new List<Sospechoso>();
        }

        public static Sistema ObtenerInstancia()
        {
            return _instancia;
        }


        // ==========================================
        // METODOS AUXILIARES PARA LA PRECARGA
        // ==========================================

        private Investigador PrecargarInvestigador(string email, string contrasena, string nombre, Rol rol)
        {
            Investigador i = new Investigador(email, contrasena, nombre, rol);
            AltaInvestigador(i);
            return i;
        }

        private Sospechoso PrecargarSospechoso(string nombre, string cedula, DateTime fechaNacimiento, bool antecedentes)
        {
            Sospechoso s = new Sospechoso(nombre, cedula, fechaNacimiento, antecedentes);
            AltaSospechoso(s);
            return s;
        }

        private Caso PrecargarCaso(string nombre, string descripcion, bool cerrado, Sospechoso sospechoso, Investigador detective)
        {
            Caso c = new Caso(nombre, descripcion, cerrado, sospechoso, detective);
            AltaCaso(c);
            return c;
        }

        private void PrecargarFisica(Caso caso, int diasAtras, string descripcion, bool huellas)
        {
            Fisica e = new Fisica(DateTime.Today.AddDays(-diasAtras), DateTime.Today, descripcion, huellas);
            AgregarEvidenciaACaso(caso.Id, e);
        }

        private void PrecargarGrabacion(Caso caso, int diasAtras, string descripcion, int calidad, bool infraganti)
        {
            Grabacion e = new Grabacion(DateTime.Today.AddDays(-diasAtras), DateTime.Today, descripcion, calidad, infraganti);
            AgregarEvidenciaACaso(caso.Id, e);
        }

        private void PrecargarTestimonio(Caso caso, int diasAtras, string descripcion, string testigo, Credibilidad credibilidad)
        {
            Testimonio e = new Testimonio(DateTime.Today.AddDays(-diasAtras), DateTime.Today, descripcion, testigo, credibilidad);
            AgregarEvidenciaACaso(caso.Id, e);
        }


        // ==========================================
        // PRECARGA COMPLETA DEL SISTEMA
        // ==========================================

        public void Precargar()
        {
            // Evitamos repetir la precarga
            if (_investigadores.Count > 0 || _sospechosos.Count > 0 || _casos.Count > 0)
            {
                return;
            }

            // =====================================
            // INVESTIGADORES - 5 DETECTIVES
            // =====================================

            Investigador d1 = PrecargarInvestigador("detective1@fiscalia.com", "Clave123", "Lucia Perez", Rol.DETECTIVE);
            Investigador d2 = PrecargarInvestigador("detective2@fiscalia.com", "Clave123", "Martin Rodriguez", Rol.DETECTIVE);
            Investigador d3 = PrecargarInvestigador("detective3@fiscalia.com", "Clave123", "Sofia Gonzalez", Rol.DETECTIVE);
            Investigador d4 = PrecargarInvestigador("detective4@fiscalia.com", "Clave123", "Diego Fernandez", Rol.DETECTIVE);
            Investigador d5 = PrecargarInvestigador("detective5@fiscalia.com", "Clave123", "Valentina Silva", Rol.DETECTIVE);

            // =====================================
            // INVESTIGADORES - 5 FISCALES
            // =====================================

            PrecargarInvestigador("fiscal1@fiscalia.com", "Clave123", "Andres Lopez", Rol.FISCAL);
            PrecargarInvestigador("fiscal2@fiscalia.com", "Clave123", "Camila Torres", Rol.FISCAL);
            PrecargarInvestigador("fiscal3@fiscalia.com", "Clave123", "Federico Castro", Rol.FISCAL);
            PrecargarInvestigador("fiscal4@fiscalia.com", "Clave123", "Paula Martinez", Rol.FISCAL);
            PrecargarInvestigador("fiscal5@fiscalia.com", "Clave123", "Joaquin Ramirez", Rol.FISCAL);

            // =====================================
            // SOSPECHOSOS - 15
            // =====================================

            Sospechoso s1 = PrecargarSospechoso("Carlos Mendez", "30001008", new DateTime(1985, 3, 15), true);
            Sospechoso s2 = PrecargarSospechoso("Ana Pereira", "30001014", new DateTime(1992, 7, 20), false);
            Sospechoso s3 = PrecargarSospechoso("Juan Gomez", "30001020", new DateTime(1978, 11, 5), true);
            Sospechoso s4 = PrecargarSospechoso("Maria Lopez", "30001036", new DateTime(1995, 2, 12), false);
            Sospechoso s5 = PrecargarSospechoso("Pedro Silva", "30001042", new DateTime(1988, 9, 28), true);
            Sospechoso s6 = PrecargarSospechoso("Luciana Castro", "30001058", new DateTime(2000, 6, 14), false);
            Sospechoso s7 = PrecargarSospechoso("Roberto Diaz", "30001064", new DateTime(1982, 4, 3), true);
            Sospechoso s8 = PrecargarSospechoso("Florencia Ruiz", "30001070", new DateTime(1997, 12, 19), false);
            Sospechoso s9 = PrecargarSospechoso("Miguel Torres", "30001086", new DateTime(1975, 8, 10), true);
            Sospechoso s10 = PrecargarSospechoso("Carolina Sosa", "30001092", new DateTime(1990, 5, 25), false);

            PrecargarSospechoso("Fernando Acosta", "30001105", new DateTime(1984, 1, 8), true);
            PrecargarSospechoso("Daniela Romero", "30001111", new DateTime(1999, 10, 17), false);
            PrecargarSospechoso("Gustavo Ramos", "30001127", new DateTime(1980, 3, 22), true);
            PrecargarSospechoso("Natalia Suarez", "30001133", new DateTime(1994, 7, 9), false);
            PrecargarSospechoso("Sebastian Vega", "30001149", new DateTime(1987, 11, 30), true);

            // =====================================
            // CASOS - 10
            // =====================================

            Caso c1 = PrecargarCaso("Robo en joyeria", "Robo de joyas en Montevideo", false, s1, d1);
            Caso c2 = PrecargarCaso("Fraude bancario", "Transferencias bancarias fraudulentas", false, s2, d2);
            Caso c3 = PrecargarCaso("Hurto de vehiculo", "Robo de un automovil particular", true, s3, d3);
            Caso c4 = PrecargarCaso("Estafa comercial", "Estafa en una compraventa", false, s4, d4);
            Caso c5 = PrecargarCaso("Robo a supermercado", "Robo durante horario comercial", true, s5, d5);
            Caso c6 = PrecargarCaso("Falsificacion documental", "Documentos personales falsificados", false, s6, d1);
            Caso c7 = PrecargarCaso("Robo de vivienda", "Ingreso ilegal a una propiedad", false, s7, d2);
            Caso c8 = PrecargarCaso("Estafa informatica", "Suplantacion de identidad digital", true, s8, d3);
            Caso c9 = PrecargarCaso("Hurto de mercaderia", "Robo de productos en un deposito", false, s9, d4);
            Caso c10 = PrecargarCaso("Fraude empresarial", "Alteracion de registros contables", false, s10, d5);

            // =====================================
            // EVIDENCIAS CASO 1
            // =====================================

            PrecargarFisica(c1, 20, "Huellas encontradas en la vitrina", true);
            PrecargarGrabacion(c1, 25, "Camara de seguridad de la joyeria", 5, true);
            PrecargarTestimonio(c1, 30, "Declaracion del guardia de seguridad", "Luis Garcia", Credibilidad.ALTO);
            PrecargarTestimonio(c1, 210, "Declaracion de un cliente", "Pedro Suarez", Credibilidad.MEDIO);

            // =====================================
            // EVIDENCIAS CASO 2
            // =====================================

            PrecargarFisica(c2, 40, "Documentos bancarios encontrados", false);
            PrecargarGrabacion(c2, 50, "Grabacion de cajero automatico", 3, false);
            PrecargarTestimonio(c2, 60, "Declaracion del gerente del banco", "Maria Silva", Credibilidad.ALTO);
            PrecargarTestimonio(c2, 230, "Declaracion de un empleado", "Juan Lopez", Credibilidad.BAJO);

            // =====================================
            // EVIDENCIAS CASO 3
            // =====================================

            PrecargarFisica(c3, 15, "Huellas encontradas en el vehiculo", true);
            PrecargarGrabacion(c3, 20, "Camara del estacionamiento", 4, true);
            PrecargarTestimonio(c3, 25, "Declaracion del propietario del vehiculo", "Carlos Diaz", Credibilidad.ALTO);
            PrecargarTestimonio(c3, 200, "Declaracion de un vecino", "Ana Perez", Credibilidad.MEDIO);

            // =====================================
            // EVIDENCIAS CASO 4
            // =====================================

            PrecargarFisica(c4, 80, "Contrato de compraventa", false);
            PrecargarGrabacion(c4, 90, "Grabacion de la reunion comercial", 2, false);
            PrecargarTestimonio(c4, 95, "Declaracion del comprador", "Lucia Ramos", Credibilidad.ALTO);
            PrecargarTestimonio(c4, 250, "Declaracion del vendedor", "Mario Vega", Credibilidad.BAJO);

            // =====================================
            // EVIDENCIAS CASO 5
            // =====================================

            PrecargarFisica(c5, 10, "Huellas en la caja registradora", true);
            PrecargarGrabacion(c5, 12, "Camara del supermercado", 5, true);
            PrecargarTestimonio(c5, 15, "Declaracion del cajero", "Pablo Castro", Credibilidad.ALTO);
            PrecargarTestimonio(c5, 20, "Declaracion del encargado", "Sofia Diaz", Credibilidad.ALTO);

            // =====================================
            // EVIDENCIAS CASO 6
            // =====================================

            PrecargarFisica(c6, 45, "Documentos falsificados encontrados", true);
            PrecargarGrabacion(c6, 50, "Grabacion de la oficina", 3, false);
            PrecargarTestimonio(c6, 65, "Declaracion del funcionario", "Diego Lopez", Credibilidad.MEDIO);
            PrecargarTestimonio(c6, 220, "Declaracion de otro testigo", "Carla Perez", Credibilidad.BAJO);

            // =====================================
            // EVIDENCIAS CASO 7
            // =====================================

            PrecargarFisica(c7, 30, "Huellas encontradas en una ventana", true);
            PrecargarGrabacion(c7, 40, "Camara de seguridad de la vivienda", 4, true);
            PrecargarTestimonio(c7, 45, "Declaracion del propietario", "Laura Gomez", Credibilidad.ALTO);
            PrecargarTestimonio(c7, 190, "Declaracion de un vecino", "Martin Silva", Credibilidad.MEDIO);

            // =====================================
            // EVIDENCIAS CASO 8
            // =====================================

            PrecargarFisica(c8, 70, "Equipo informatico incautado", false);
            PrecargarGrabacion(c8, 75, "Grabacion de acceso al sistema", 4, false);
            PrecargarTestimonio(c8, 80, "Declaracion de la victima", "Natalia Lopez", Credibilidad.ALTO);
            PrecargarTestimonio(c8, 240, "Declaracion de otro usuario", "Javier Diaz", Credibilidad.BAJO);

            // =====================================
            // EVIDENCIAS CASO 9
            // =====================================

            PrecargarFisica(c9, 35, "Embalajes con huellas digitales", true);
            PrecargarGrabacion(c9, 38, "Camara del deposito", 3, false);
            PrecargarTestimonio(c9, 45, "Declaracion del supervisor", "Daniel Castro", Credibilidad.MEDIO);
            PrecargarTestimonio(c9, 200, "Declaracion de un empleado", "Paula Lopez", Credibilidad.ALTO);

            // =====================================
            // EVIDENCIAS CASO 10
            // =====================================

            PrecargarFisica(c10, 100, "Documentos contables alterados", false);
            PrecargarGrabacion(c10, 110, "Grabacion de reunion empresarial", 2, false);
            PrecargarTestimonio(c10, 120, "Declaracion del contador", "Federico Silva", Credibilidad.ALTO);
            PrecargarTestimonio(c10, 300, "Declaracion del gerente", "Camila Perez", Credibilidad.MEDIO);
        }



        public void AltaCaso(Caso c){
            if (c == null){
                throw new Exception("El caso no puede ser nulo");
            }

            c.Validar();

            if (!_investigadores.Contains(c.Detective)){
                throw new Exception("El detective no está registrado en el sistema");
            }

            if (!_sospechosos.Contains(c.Sospechoso)){
                throw new Exception("El sospechoso no está registrado en el sistema");
            }

            foreach (Caso caso in _casos)
            {
                if (caso.Id == c.Id){
                    throw new Exception("Ya existe un caso con ese ID");
                }
            }

            _casos.Add(c);
        }



        public void AltaInvestigador(Investigador i)
        {
            if (i == null){
                throw new Exception("El investigador no puede ser nulo");
            }

            i.Validar();

            if (_investigadores.Contains(i)){
                throw new Exception("Ya existe un investigador con ese email");
            }

            
            _investigadores.Add(i);
        }

        public void AltaSospechoso(Sospechoso s)
        {
            if (s == null){
                throw new Exception("El sospechoso no puede ser nulo");
            }

            s.Validar();
            if (_sospechosos.Contains(s)){
                throw new Exception("Ya existe un sospechoso con esa cédula");
            }

            _sospechosos.Add(s);
        }


        public Caso BuscarCasoPorId(int id)
        {
            
            foreach (Caso c in _casos){
                
                if (c.Id == id)
                {
                    return c;
                }
            }

            
            return null;
        }

        public void AgregarEvidenciaACaso(int idCaso, Evidencia e)
        {
            
            Caso c = BuscarCasoPorId(idCaso);
            if (c == null){
                throw new Exception("No existe un caso con ese ID");
            }

            if (e == null){
                throw new Exception("La evidencia no puede ser nula");
            }
            e.Validar();
            c.AgregarEvidencia(e);
        }


        public List<Caso> ListarCasos()
        {
            return new List<Caso>(_casos);
        }


        public List<Caso> BuscarCasosPorInvestigador(string email)
        {
            List<Caso> casosInvestigador = new List<Caso>();

            foreach (Caso c in _casos)
            {
                if (c.Detective.Email == email)
                {
                    casosInvestigador.Add(c);
                }
            }

            return casosInvestigador;
        }


        public List<Sospechoso> ListarSospechososConAntecedentes()
        {
            List<Sospechoso> sospechososConAntecedentes = new List<Sospechoso>();

            foreach (Sospechoso s in _sospechosos)
            {
                if (s.Antecedentes == true)
                {
                    sospechososConAntecedentes.Add(s);
                }
            }

            return sospechososConAntecedentes;
        }





    }


}
