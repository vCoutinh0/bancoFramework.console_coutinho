using Domain.Model;

namespace Domain.Interfaces
{
    public interface IClienteService
    {
        void Sacar(Cliente cliente);
        void Depositar(Cliente cliente);
    }
}
