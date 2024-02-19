using Application;
using Domain.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Seja bem vindo ao banco Framework");
        Console.WriteLine("Por favor, identifique-se");
        Console.WriteLine("");
        var cliente = Identificacao();
        ExibirMenu(cliente);
    }

    private static Cliente Identificacao()
    {
        string id, nome, cpf, saldo;
        string? input;

        Console.WriteLine("Seu número de identificação:");
        input = Console.ReadLine();
        id = string.IsNullOrEmpty(input) ? ObterInputValido("Número de identificação") : input;

        Console.WriteLine("Seu nome:");
        input = Console.ReadLine();
        nome = string.IsNullOrEmpty(input) ? ObterInputValido("Nome") : input;

        Console.WriteLine("Seu CPF:");
        input = Console.ReadLine();
        cpf = string.IsNullOrEmpty(input) ? ObterInputValido("CPF") : input;

        Console.WriteLine("Seu saldo:");
        input = Console.ReadLine();
        saldo = string.IsNullOrEmpty(input) ? ObterInputValido("Saldo") : input;

        Console.Clear();

        var cliente = new Cliente()
        {
            Id = int.Parse(id),
            Nome = nome,
            Cpf = cpf,
            Saldo = float.Parse(saldo)
        };

        return cliente;
    }

    private static void ExibirMenu(Cliente cliente)
    {
        Console.WriteLine($"Como posso ajudar {cliente.Nome}?");
        Console.WriteLine($"1 - Depósito");
        Console.WriteLine($"2 - Saque");
        Console.WriteLine($"3 - Sair");
        Console.WriteLine($"----------");
        Console.WriteLine($"Selecione uma opção:");
        var selecao = Console.ReadKey();
        Console.WriteLine();

        switch (selecao.KeyChar)
        {
            case '1':
                Console.Clear();
                Depositar(cliente);
                Console.Clear();
                Console.WriteLine($"Saldo atual é: {cliente.Saldo}");
                ExibirMenu(cliente);
                break;
            case '2':
                Console.Clear();
                Sacar(cliente);
                Console.Clear();
                Console.WriteLine($"Saldo atual é: {cliente.Saldo}");
                ExibirMenu(cliente);
                break;
            case '3':
                break;
            default:
                ExibirMenu(cliente);
                break;
        }
    }

    private static void Sacar(Cliente cliente)
    {
        Console.WriteLine($"Digite o valor:");
        string? input = Console.ReadLine();
        float valorSaque = float.Parse(string.IsNullOrEmpty(input) ? ObterInputValido("Valor de saque") : input);
        cliente.Saldo = Calculo.Subtracao(cliente.Saldo, valorSaque);
    }

    private static void Depositar(Cliente cliente)
    {
        Console.WriteLine($"Digite o valor:");
        string? input = Console.ReadLine();
        float valorDeposito = float.Parse(string.IsNullOrEmpty(input) ? ObterInputValido("Valor de depósito") : input);
        cliente.Saldo = Calculo.Soma(cliente.Saldo, valorDeposito);
    }
    
    private static string ObterInputValido(string NomeDoDadoAObter)
    {
        string? input;

        do
        {
            Console.WriteLine(NomeDoDadoAObter + " inválido. Informe-o corretamente:");
            input = Console.ReadLine();
        } while (string.IsNullOrEmpty(input));

        return input;
    }
}
