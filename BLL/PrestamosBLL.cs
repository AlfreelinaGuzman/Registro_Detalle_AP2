using System;
using System.Collections.Generic;
using System.Text;
using Registro_Detalle_AP2.DAL;
using Registro_Detalle_AP2.Models;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace Registro_Detalle_AP2.BLL{

    public class PrestamosBLL{

///-------------------------GUARDAR------------------------------------------
        public static bool Guardar(Prestamos prestamo){
           if(!Existe(prestamo.PrestamoId))
                return Insertar(prestamo);
           else
                return Modificar(prestamo);
        }
        
///-------------------------INSERTAR-----------------------------------------
        private static bool Insertar(Prestamos prestamo){

             bool paso = false;
             Contexto contexto = new Contexto();

            try{
                contexto.Prestamos.Add(prestamo);
                paso = contexto.SaveChanges()>0;
            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }
            return paso;

        }

////-------------------------------MODIFICAR------------------------------
        private static bool Modificar(Prestamos prestamo){

            bool paso = false;
            Contexto contexto = new Contexto();

            try{
   
                contexto.Entry(prestamo).State= EntityState.Modified;
                paso = contexto.SaveChanges()>0;
            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }

            return paso;
        }

//----------------------------------ELIMINAR-----------------------------------------
        public static bool Eliminar(int id){
            
            bool paso = false;
            Contexto contexto = new Contexto();

            try{
        
                var prestamo = contexto.Prestamos.Find(id);

                if(prestamo != null){
                    contexto.Prestamos.Remove(prestamo);
                    paso = contexto.SaveChanges() >0;
                }
            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }

            return paso;
        }

//-------------------------------------BUSCAR--------------------------------------
        public static Prestamos Buscar(int id){

            Contexto contexto = new Contexto();
            Prestamos prestamo = new Prestamos();

            try{
                prestamo =contexto.Prestamos.Find(id);

            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }

            return prestamo;

        }

//--------------------------------EXISTE--------------------------------------------
        public static bool Existe(int id){

            Contexto contexto = new Contexto();
            bool encontrado = false;

            try{
                encontrado = contexto.Prestamos.Any(e => e.PrestamoId ==id);
            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }

            return encontrado;
        }

//-----------------------------List-------------------------------------------
        public static List<Prestamos> GetList(Expression<Func<Prestamos, bool>> criterio){
            
            List<Prestamos> lista = new List<Prestamos>();
            Contexto contexto = new Contexto();

            try{
                
                lista = contexto.Prestamos.Where(criterio).ToList();

            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }
            return lista;
        }
    }
}