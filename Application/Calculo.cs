using Domain.Interfaces;

namespace Application
{
    public class Calculo : ICalculo
    {
        public decimal Soma(decimal valor1, decimal valor2)
        {
            return valor1 + valor2;
        }

        public decimal Subtracao(decimal valor1, decimal valor2)
        {
            return valor1 - valor2;
        }
    }
}
