using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using p2_ap1_wilkins_20170289.DAL;
using p2_ap1_wilkins_20170289.Entidades;

namespace p2_ap1_wilkins_20170289.BLL
{
    public class TareasBLL
    {
        //GETLIST
        public static List<Tareas> GetList(Expression<Func<Tareas, bool>> criterio)
        {
            List<Tareas> lista = new List<Tareas>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Tareas.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
    }
}
