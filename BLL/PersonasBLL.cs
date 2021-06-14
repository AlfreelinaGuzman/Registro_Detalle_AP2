using System;
using System.Linq;
using Registro_Detalle_AP2.DAL;
using Registro_Detalle_AP2.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Registro_Detalle_AP2.BLL
{
    public class PersonasBLL
    {
        public static bool Guardar(Personas persona)
        {
            if (!Existe(persona.PersonaId))
                return Insertar(persona);
            else
                return Modificar(persona);
        }

        private static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Personas.Any(d => d.PersonaId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        private static bool Insertar(Personas persona)
        {
            Contexto contexto = new Contexto();
            bool insertado = false;

            try
            {
                contexto.Personas.Add(persona);
                insertado = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return insertado;
        }

        private static bool Modificar(Personas persona)
        {
            Contexto contexto = new Contexto();
            bool modificado = false;

            try
            {
                contexto.Entry(persona).State = EntityState.Modified;
                modificado = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return modificado;
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool eliminado = false;

            try
            {
                var buscando = contexto.Personas.Find(id);
                contexto.Entry(buscando).State = EntityState.Deleted;
                eliminado = (contexto.SaveChanges() > 0);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return eliminado;
        }

        public static Personas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Personas persona = new Personas();

            try
            {
                persona = contexto.Personas.Find(id);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return persona;
        }


        public static List<Personas> GetList(Expression<Func<Personas, bool>> persona)
        {
            Contexto contexto = new Contexto();
            List<Personas> listado = new List<Personas>();

            try
            {
                listado = contexto.Personas.Where(persona).ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return listado;
        }

        public static void incremento(int id, decimal monto )
        {
            Personas personas= Buscar(id);
            personas.Balance += monto;
            Modificar(personas);
        }

        public static void decremento(int id, decimal monto )
        {
            Personas personas= Buscar(id);
            personas.Balance -= monto;
            Modificar(personas);
        }
    }
}