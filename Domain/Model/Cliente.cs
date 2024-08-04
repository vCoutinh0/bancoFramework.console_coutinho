using Domain.Interfaces;

namespace Domain.Model
{
    public class Cliente : Pessoa
    {
        private decimal saldo;

        public decimal Saldo
        {
            get { return saldo; }
        }

        public Cliente() : base()
        {
            var inputSaldo = ObterInputDecimal("Saldo");
            
            if (inputSaldo < 0)
                throw new InvalidOperationException("O valor do saldo não pode ser negativo");
            
            saldo = inputSaldo;
        }

        public decimal ObterInputSaque()
        {
            return ObterInputDecimal("Valor de saque");
        }

        public decimal ObterInputDeposito()
        {
            return ObterInputDecimal("Valor de depósito");
        }

        public void AtualizarSaldo(decimal valor)
        {
            if (valor < 0)
                throw new InvalidOperationException("O valor do saldo não pode ser negativo");

            saldo = valor;
        }
    }
}
