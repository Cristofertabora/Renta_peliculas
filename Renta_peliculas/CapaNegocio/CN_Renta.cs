using Abp.Domain.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renta_peliculas.CapaNegocio
{
    internal class CN_Renta
    {
        private readonly IUnitOfWork _unitOfWork;

        public RentaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<Renta>> GetAll()
        {
            return await _unitOfWork.Rentas.GetAll().ToListAsync();
        }

        public async Task<Renta> GetOne(int rentaId)
        {
            return await _unitOfWork.Rentas.GetById(rentaId);
        }

        public async Task Update(Renta renta)
        {
            _unitOfWork.Rentas.Update(renta);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Add(Renta renta)
        {
            _unitOfWork.Rentas.Add(renta);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int rentaId)
        {
            var renta = await _unitOfWork.Rentas.GetById(rentaId);
            _unitOfWork.Rentas.Remove(renta);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Rent(int peliculaId, int clienteId, int cantidad, DateTime fechaRenta)
        {
            // Check if the Pelicula is available for rent
            var pelicula = await _unitOfWork.Peliculas.GetById(peliculaId);
            if (pelicula.Existencia < cantidad)
            {
                throw new Exception("La Pelicula no esta disponible en la cantidad solicitada");
            }

            // Create a new Renta object
            var renta = new Renta
            {
                FechaRenta = fechaRenta,
                FechaRetorno = fechaRenta.AddDays(pelicula.PrecioRenta * cantidad),
                Cantidad = cantidad,
                PrecioRenta = pelicula.PrecioRenta,
                Pelicula = pelicula,
                Cliente = await _unitOfWork.Clientes.GetById(clienteId)
            };

            // Deduct the rented quantity from the Pelicula
            pelicula.Existencia -= renta.Cantidad;
            _unitOfWork.Peliculas.Update(pelicula);

            // Add the new Renta object
            await _unitOfWork.Rentas.Add(renta);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Return(int rentaId)
        {
            // Retrieve the Renta object
            var renta = await _unitOfWork.Rentas.GetById(rentaId);

            // Add the returned quantity back to the Pelicula
            var pelicula = renta.Pelicula;
            pelicula.Existencia += renta.Cantidad;
            _unitOfWork.Peliculas.Update(pelicula);

            // Delete the Renta object
            _unitOfWork.Rentas.Remove(renta);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
}
