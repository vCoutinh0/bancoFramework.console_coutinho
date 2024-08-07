using Application;
using Domain.Model;
using Microsoft.Extensions.DependencyInjection;
using Application.Properties;
using Domain.Interfaces.Services;
using Domain.Extensions;
using Domain.Interfaces.Repositories;
using Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;
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
            .AddScoped<IClienteRepository, ClienteRepository>()
            .AddScoped<ICalculo, Calculo>()
            .AddTransient<Program>()
            .BuildServiceProvider();

        var program = serviceProvider.GetService<Program>();

        if(program is not null)
            program.Run();  
    }

    public void Run()
    {
        ImprimeMensagemBoasVindas();
        var cliente = ObterDadosCliente();
        FluxoMenu(cliente);
    }

    private Cliente ObterDadosCliente()
    {
        do
        {
            string? inputId, inputNome, inputCpf, inputSaldo;

            var erros = new HashSet<InputError>();

            inputId = ObterInput("Identificador");

            ValidatorModule.ValidarInputIdentificador(inputId, ref erros);

            if (erros.Any())
                ImprimirErros(erros);

            var cliente = _clienteService.ObterPorIdentificador(inputId);

            if (cliente is not null)
                return cliente;

            inputNome = ObterInput("Nome");
            inputCpf = ObterInput("CPF");
            inputSaldo = ObterInput("Saldo");

            ValidatorModule.ValidarInputNome(inputCpf, ref erros);
            ValidatorModule.ValidarInputCpf(inputCpf, ref erros);
            ValidatorModule.ValidarInputSaldo(inputSaldo, ref erros);

            if (!erros.Any())
            {
                cliente = new Cliente
                {
                    Id = int.Parse(inputId!),
                    Nome = inputNome!,
                    Cpf = inputCpf!
                };

                cliente.AtualizarSaldo(decimal.Parse(inputSaldo!));
                SalvarDadosCliente(cliente);

                return cliente;
            }

            ImprimirErros(erros);

        } while (true);
    }
    private void SalvarDadosCliente(Cliente cliente)
    {
        _clienteService.Inserir(cliente);
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
            decimal saque; string erro;
            var inputSaque = ObterInput("Digite o valor para saque");
            ValidatorModule.ValidarInputSaque(inputSaque, out saque, out erro);

            if (erro != string.Empty)
                throw new ArgumentException(erro);

            _clienteService.Sacar(cliente, saque);

            Console.Clear();
            Console.WriteLine(string.Format(Messages.OperacaoConcluida, cliente.Saldo.ToString("C", new CultureInfo("pt-BR"))));
            Thread.Sleep(3000);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(string.Concat(ex.Message, " ", Messages.AperteQualquerTecla));
            Console.ReadKey();
            OperacaoSaque(cliente);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine($"\nSeu saldo atual é: {cliente.Saldo.ToString("C", new CultureInfo("pt-BR"))}.");
            Console.WriteLine(Messages.AperteQualquerTeclaMenu);
            Console.ReadKey();
        }
        catch (Exception)
        {
            Console.WriteLine(Messages.ErroInesperado);
            Console.WriteLine(Messages.AperteQualquerTeclaMenu);
            Console.ReadKey();
        }
        finally
        {
            FluxoMenu(cliente);
        }

    }
    private void OperacaoDeposito(Cliente cliente)
    {
        Console.Clear();

        try
        {
            decimal deposito; string erro;
            var inputDeposito = ObterInput("Digite o valor para deposito");
            ValidatorModule.ValidarInputDeposito(inputDeposito, out deposito, out erro);

            if (erro != string.Empty) 
                throw new ArgumentException(erro);

            _clienteService.Depositar(cliente, deposito);

            Console.Clear();
            Console.WriteLine(string.Format(Messages.OperacaoConcluida, cliente.Saldo.ToString("C", new CultureInfo("pt-BR"))));
            Thread.Sleep(3000);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(string.Concat(ex.Message, " ", Messages.AperteQualquerTecla));
            Console.ReadKey();
            OperacaoDeposito(cliente);
        }
        catch (Exception)
        {
            Console.WriteLine(Messages.ErroInesperado);
            Console.WriteLine(Messages.AperteQualquerTeclaMenu);
            Console.ReadKey();
        }
        finally
        {
            FluxoMenu(cliente);
        }

    }
    private void ImprimirErros(IEnumerable<InputError> erros)
    {
        Console.Clear();
        Console.WriteLine(string.Join("\n", erros));
        Console.WriteLine("\n");
        Console.WriteLine(Messages.AperteQualquerTecla);
        Console.ReadKey();
        Console.Clear();
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
    private string? ObterInput(string nomeInput)
    {
        Console.WriteLine(nomeInput + ":");
        var input = Console.ReadLine();
        return input;
    }
}
