using Domain.Model;

namespace Domain.Interfaces.Services
{
    public interface IClienteService
    {
        Cliente? ObterPorIdentificador(string identificador);
        void Sacar(Cliente cliente, decimal valorSaque);
        void Depositar(Cliente cliente, decimal valorDeposito);
    }
}
