using Application;
using Domain.Interfaces;
using Domain.Model;
using Microsoft.Extensions.DependencyInjection;
using Application.Properties;
internal class Program
{
    private readonly IClienteService _clienteService;

    public Program(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    private static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddScoped<IClienteService, ClienteService>()
            .AddScoped<ICalculo, Calculo>()
            .AddTransient<Program>()
            .BuildServiceProvider();

        var program = serviceProvider.GetService<Program>();
        program.Run();
    }

    public void Run()
    {
        ImprimeMensagemBoasVindas();
        FluxoMenu(new Cliente());
    }

    private void FluxoMenu(Cliente cliente)
    {
        ImprimeMenu(cliente.Nome);

        var selecao = Console.ReadKey();

        switch (selecao.KeyChar)
        {
            case '1':
                OperacaoDeposito(cliente);
                break;
            case '2':
                OperacaoSaque(cliente);
                break;
            case '3':
                break;
            default:
                FluxoMenu(cliente);
                break;
        }
    }

    private void OperacaoSaque(Cliente cliente)
    {
        Console.Clear();

        try
        {
            _clienteService.Sacar(cliente);
            Console.Clear();
            Console.WriteLine(string.Format(Messages.OperacaoConcluida, cliente.Saldo));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message + " Tente novamente.");
            Thread.Sleep(1500);
            OperacaoSaque(cliente);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine($"Saldo atual: {cliente.Saldo}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(Messages.ErroInesperado);
        }
        finally
        {
            Thread.Sleep(2000);
            FluxoMenu(cliente);
        }

    }

    private void OperacaoDeposito(Cliente cliente)
    {
        Console.Clear();

        try
        {
            _clienteService.Depositar(cliente);
            Console.Clear();
            Console.WriteLine(string.Format(Messages.OperacaoConcluida, cliente.Saldo));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message + " Tente novamente.");
            Thread.Sleep(1500);
            OperacaoSaque(cliente);
        }
        catch (Exception ex)
        {
            Console.WriteLine(Messages.ErroInesperado);
        }
        finally
        {
            Thread.Sleep(1500);
            FluxoMenu(cliente);
        }

    }

    private void ImprimeMensagemBoasVindas()
    {
        Console.Clear();
        Console.WriteLine("Seja bem vindo ao banco Framework!");
        Console.WriteLine("Por favor, preencha as informações pedidas abaixo. \n");
    }
    private void ImprimeMenu(string nomeCliente)
    {
        Console.Clear();
        Console.WriteLine($"Como posso ajudar {nomeCliente}?");
        Console.WriteLine($"1 - Depósito");
        Console.WriteLine($"2 - Saque");
        Console.WriteLine($"3 - Sair");
        Console.WriteLine($"----------");
        Console.WriteLine($"Selecione uma opção:\t");
    }
}
