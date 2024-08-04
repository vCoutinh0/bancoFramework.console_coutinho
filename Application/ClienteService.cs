using Application.Properties;
using Domain.Interfaces;
using Domain.Model;

namespace Application
{
    public class ClienteService : IClienteService
    {
        private readonly ICalculo _calculo;
        public ClienteService(ICalculo calculo)
        {
            _calculo = calculo;
        }

        public void Sacar(Cliente cliente)
        {
            Console.WriteLine($"Digite o valor para saque:");
            var valorSaque = cliente.ObterInputSaque();
            var saldo = cliente.Saldo;

            if (valorSaque < 0)
                throw new ArgumentException(Messages.ValorMaiorQueZero);

            if (valorSaque > saldo)
                throw new InvalidOperationException("Saldo insuficiente.");

            var balanco = _calculo.Subtracao(saldo, valorSaque);

            cliente.AtualizarSaldo(balanco);
        }

        public void Depositar(Cliente cliente)
        {
            Console.WriteLine($"Digite o valor para deposito:");
            var valorDeposito = cliente.ObterInputDeposito();
            var saldo = cliente.Saldo;

            if (valorDeposito < 0)
                throw new ArgumentException(Messages.ValorMaiorQueZero);

            var balanco = _calculo.Soma(saldo, valorDeposito);

            cliente.AtualizarSaldo(balanco);
        }
    }
}
