using FormularioCompleto.DAL;
using FormularioCompleto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormularioCompleto.Controllers
{
    public class PersonasController
    {
        public static bool Guardar(Personas Persona)
        {
            bool paso = false;
            Contexto Database = new Contexto();
            try
            {
                if (Persona.ID == 0)
                {
                    paso = Insertar(Persona);
                }
                else
                {
                    paso = Modificar(Persona);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Database.Dispose();
            }
            return paso;
        }
        public static bool Insertar(Personas Persona)
        {
            Contexto Database = new Contexto();
            bool paso = false;

            try
            {
                Database.Personas.Add(Persona);
                paso = Database.SaveChanges() > 0;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Database.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Personas Persona)
        {
            Contexto Database = new Contexto();
            bool paso = false;
            try
            {
                Database.Entry(Persona).State = EntityState.Modified;
                paso = Database.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Database.Dispose();
            }

            return paso;

        }

        public static Personas Buscar(int Id)
        {
            Personas Persona;
            Contexto Database = new Contexto();

            try
            {
                Persona = Database.Personas.Where(A => A.ID == Id).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Database.Dispose();
            }

            return Persona;
        }

        public static bool Eliminar(int Id)
        {
            bool paso = false;

            Contexto Database = new Contexto();

            try
            {
                Personas Persona = Database.Personas.Find(Id);

                if (Persona != null)
                {
                    Database.Personas.Remove(Persona);
                    paso = Database.SaveChanges() > 0;
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Database.Dispose();
            }

            return paso;

        }

    }
}

