using Domain.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Seja bem vindo ao banco Framework");
        Console.WriteLine("Por favor, identifique-se");
        Console.WriteLine("");
        var pessoa = Identificacao();
        ExibirMenu(pessoa.Nome);
    }

    static Pessoa Identificacao()
    {
        var pessoa = new Pessoa();

        Console.WriteLine("Seu número de identificação:");
        pessoa.Id = int.Parse(Console.ReadLine());

        Console.WriteLine("Seu nome:");
        pessoa.Nome = Console.ReadLine();

        Console.WriteLine("Seu CPF:");
        pessoa.Cpf = Console.ReadLine();
        Console.Clear();
        
        return pessoa;
    }
    private static void ExibirMenu(string nome)
    {
        Console.WriteLine($"Como posso ajudar {nome}?");
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
                Console.WriteLine($"Depósito");
                break;
            case '2':
                Console.WriteLine($"Saque");
                break;
            case '3':
                break;
            default:
                ExibirMenu(nome);
                break;
        }
    }
}
