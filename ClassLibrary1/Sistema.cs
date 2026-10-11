using System;
using System.Collections.Generic;

namespace Obligatorio_P2
{
    public class Sistema
    {
        
        private List<Caso> _casos;
        private List<Investigador> _investigadores;

        private List<Sospechoso> _sospechosos;

        public Sistema(){
            _casos = new List<Caso>();
            _investigadores = new List<Investigador>();
            _sospechosos = new List<Sospechoso>();
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
            

        }


    }
