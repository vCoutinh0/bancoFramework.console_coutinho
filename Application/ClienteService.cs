using Application.Properties;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Model;

namespace Application
{
    public class ClienteService : IClienteService
    {
        private readonly ICalculo _calculo;
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(
            ICalculo calculo,
            IClienteRepository clienteRepository)
        {
            _calculo = calculo;
            _clienteRepository = clienteRepository;
        }

        public void Sacar(Cliente cliente, decimal valorSaque)
        {
            if (valorSaque < 0)
                throw new ArgumentException(Messages.ValorMaiorQueZero);

            var saldo = cliente.Saldo;
            
            if (valorSaque > saldo)
                throw new InvalidOperationException("Saldo insuficiente.");

            var balanco = _calculo.Subtracao(saldo, valorSaque);

            cliente.AtualizarSaldo(balanco);

            _clienteRepository.AtualizarSaldo(cliente);
        }

        public void Depositar(Cliente cliente, decimal valorDeposito)
        {
            if (valorDeposito < 0)
                throw new ArgumentException(Messages.ValorMaiorQueZero);

            var saldo = cliente.Saldo;
            var balanco = _calculo.Soma(saldo, valorDeposito);

            cliente.AtualizarSaldo(balanco);
            _clienteRepository.AtualizarSaldo(cliente);
        }

        public Cliente? ObterPorIdentificador(string identificador)
        {
            return _clienteRepository.ObterPorIdentificador(identificador);
        }
    }
}
