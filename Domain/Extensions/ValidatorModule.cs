using CpfCnpjLibrary;
using Domain.Model;
using Domain.Properties;

namespace Domain.Extensions
{
    public delegate bool Validator(string? data);

    public class ValidatorModule
    {
        public static bool IsValid(string? data, List<Validator> validators)
        {
            foreach (var validator in validators)
            {
                if (validator(data))
                {
                    return false;
                }
            }
            return true;
        }

        public static void ValidarInputIdentificador(string? input, ref HashSet<InputError> erros)
        {
            if (!int.TryParse(input, out int identificador))
               erros.Add(new InputError() { Message = Resources.IdentificadorInvalido });
        }

        public static void ValidarInputCpf(string? input, ref HashSet<InputError> erros)
        {
            if (!Cpf.Validar(input))
                erros.Add(new InputError() { Message = Resources.CpfInvalido });
        }

        public static void ValidarInputSaldo(string? input, ref HashSet<InputError> erros)
        {
            if (!decimal.TryParse(input, out decimal saldo) || saldo < 0)
                erros.Add(new InputError() { Message = Resources.SaldoInvalido });
        }

        public static void ValidarInputNome(string? input, ref HashSet<InputError> erros)
        {
            List<Validator> validators = new List<Validator> { IsNullOrEmpty, IsNullOrWhiteSpace };

            if (!ValidatorModule.IsValid(input, validators))
                erros.Add(new InputError() { Message = Resources.NomeInvalido });
        }

        public static void ValidarInputDeposito(string? input, out decimal deposito, out string erro)
        {
            erro = Resources.DepositoInvalido;
            deposito = -1;
            
            if (decimal.TryParse(input, out decimal valor) & valor > 0)
            {
                deposito = valor;
                erro = string.Empty;
            }
        }

        public static void ValidarInputSaque(string? input, out decimal deposito, out string erro)
        {
            erro = Resources.SaldoInvalido;
            deposito = -1;

            if (decimal.TryParse(input, out decimal valor) & valor > 0)
            {
                deposito = valor;
                erro = string.Empty;
            }
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
