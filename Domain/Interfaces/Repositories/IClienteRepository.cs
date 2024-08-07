using Domain.Model;

namespace Domain.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        Cliente? ObterPorIdentificador(string identificador);
        void AtualizarSaldo(Cliente cliente);
        void Inserir(Cliente cliente);
    }
}
