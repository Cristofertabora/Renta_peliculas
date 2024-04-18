using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Core
{
    public interface  iUnitofWork
    {
        iRepository<T> Repository<T>() where T : class;

        int Guardar();
        void ComenzarTransaccion();
        void ReversarTransaccion();
        void ConfirmarTransaccion();
    }
}
