using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using EAT.DAL.Interfaces;
using EAT.Models;
using Microsoft.EntityFrameworkCore;

namespace EAT.DAL.Repository
{
    public class Repositorio<T> : IRepositorio<T> where T : class, IIdentity, new()
    {
        public virtual List<T> GetAll()
        {
            try
            {
                using (var context = new EatContext())
                {
                    return context.Set<T>().ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Falha na conexão com o Servidor: {ex} ");
                return null;
            }
        }
        public virtual T Get(int entityid)
        {
            try
            {
                using (var context = new EatContext())
                {
                    return context.Set<T>().First(f => f.Id == entityid);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Falha na conexão com o Servidor: {ex} ");
                return null;
            }
        }
        public void Save(T entity)
        {
            try
            {
                using (var context = new EatContext())
                {
                    context.Set<T>().Add(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Falha na conexão com o Servidor: {ex} ");
            }
        }

        public void Update(T entity)
        {
            try
            {
                using (var context = new EatContext())
                {
                    context.Entry(entity).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Falha na conexão com o Servidor: {ex} ");
            }
        }

        public void Remove(int entityid)
        {
            try
            {
                using (var context = new EatContext())
                {
                    var entity = context.Set<T>().First(f => f.Id == entityid);
                    context.Set<T>().Remove(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Falha na conexão com o Servidor: {ex} ");
            }
        }
        public virtual bool CanRemove(int entityid) => throw new NotImplementedException();
    }
}
