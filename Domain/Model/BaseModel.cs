using Domain.Extensions;

namespace Domain.Model
{
    public abstract class BaseModel
    {
        protected string ObterInputString(string NomeInput)
        {
            Console.WriteLine(NomeInput + ":");
            List<Validator> validators = new List<Validator> { IsNullOrEmpty, IsNullOrWhiteSpace };
            var input = Console.ReadLine();
            
            if (ValidatorModule.IsValid(input, validators))
                return input!;
            
            Console.WriteLine("Campo inválido. Informe-o novamente.");

            return ObterInputString(NomeInput);
        }

        protected int ObterInputInt(string NomeInput)
        {
            Console.WriteLine(NomeInput + ":");
            var input = Console.ReadLine();

            if (int.TryParse(input, out int result))
                return result;

            Console.WriteLine("Campo inválido. Informe-o novamente.");

            return ObterInputInt(NomeInput);
        }

        protected decimal ObterInputDecimal(string NomeInput)
        {
            decimal result;
            Console.WriteLine(NomeInput + ":");
            var input = Console.ReadLine();

            if (decimal.TryParse(input, out result))
                return result;

            Console.WriteLine("Campo inválido. Informe-o novamente.");

            return ObterInputDecimal(NomeInput);
        }

        protected string? ObterInputMensagemInvalido(string NomeInput)
        {
            Console.WriteLine(NomeInput + " inválido. Informe-o novamente:");
            return Console.ReadLine();
        }

        private static bool IsNullOrEmpty(string? input)
        {
            return string.IsNullOrEmpty(input);
        }

        private static bool IsNullOrWhiteSpace(string? input)
        {
            return string.IsNullOrWhiteSpace(input);
        }
    }
}
