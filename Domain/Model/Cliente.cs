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

        public void AtualizarSaldo(decimal valor)
        {
            if (valor < 0)
                throw new InvalidOperationException("O valor do saldo não pode ser negativo");

            saldo = valor;
        }
    }
}
