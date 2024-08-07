using Dapper;
using Domain.Interfaces.Repositories;
using Domain.Model;
using System.Data;

namespace Repository
{
    public class ClienteRepository : BaseSqlServerRepository<Cliente>, IClienteRepository
    {
        public void AtualizarSaldo(Cliente cliente)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@identificador", cliente.Id, DbType.Int32);
            parametros.Add("@saldo", cliente.Saldo, DbType.Decimal);

            Execute(Scripts.AtualizarSaldo, parametros);
        }

        public Cliente? ObterPorIdentificador(string identificador)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@identificador", identificador, DbType.Int32);

            return QuerySingleOrDefault(Scripts.ObterPorIdentificador, parametros);
        }
    }
}
