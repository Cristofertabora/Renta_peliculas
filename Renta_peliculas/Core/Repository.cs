using CapaDatos.BasedeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Core
{
    public class Repository<T>: iRepository<T> where T:class
    {
        public RentaVideosContext dbcontext;
        public Repository()
        {
            this.dbcontext = new RentaVideosContext();
        }
        public void Agregar(T entidad)
        {
            dbcontext.Set<T>().Add(entidad);
        }
        public void AgregarRango(IEnumerable<T> entidades)
        {
            dbcontext.Set<T>().AddRange(entidades);
        }
        public void Buscar(T entidad)
        {
            throw new NotImplementedException();
        }
        public IQueryable<T> Consulta()
        {
            return dbcontext.Set<T>().AsQueryable();
        }
        public void Editar(T entidad)
        {
            dbcontext.Set<T>();
        }
        public void Eliminar(T entidad)
        {
            dbcontext.Set<T>().Remove(entidad);
        }
    }
}
