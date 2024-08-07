namespace Domain.Interfaces.Services
{
    public interface ICalculo
    {
        decimal Soma(decimal valor1, decimal valor2);
        decimal Subtracao(decimal valor1, decimal valor2);
    }
}
