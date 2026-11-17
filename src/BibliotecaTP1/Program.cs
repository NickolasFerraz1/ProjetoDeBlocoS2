using System.Globalization;
namespace BibliotecaTP1;

public class Program
{
    const int PrazoDeDevolucaoDias = 14;
    const int LimiteEmprestimosAtivos = 3;
    const decimal MultaPorDia = 2m;
    const decimal TetoMulta = 50m;

    public static void Main(string[] args)
    {
        //Testes(); //para testar basta descomentar essa linha
        string opcao;
        do
        {
            Menu();
            Console.Write("Digite a opção desejada: ");
            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    ObterPrazoDevolucao();
                    break;
                case "2":
                    OpcaoMulta();
                    break;
                case "3":
                    VerificarEmprestimos();
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("VALOR INVÁLIDO! DIGITE UM VALOR VÁLIDO");
                    break;
            }
        } while (opcao != "0");
    }

    public static void ObterPrazoDevolucao()
    {
        DateTime dataEmprestimo = LerData("Insira a data do Empréstimo (dd/MM/AAAA): ");

        DateTime prazoDevolucao = CalcularPrazoDevolucao(dataEmprestimo);

        Console.WriteLine($"O seu prazo de Devolução é: {prazoDevolucao.ToString("dd/MM/yyyy")}");
    }

    public static void OpcaoMulta()
    {
        DateTime dataEmprestimo = LerData("Insira a data do Empréstimo (dd/MM/AAAA): ");

        DateTime prazoDevolucao = CalcularPrazoDevolucao(dataEmprestimo);

        Console.WriteLine($"Seu prazo de Devolução é: {prazoDevolucao.ToString("dd/MM/yyyy")}");

        DateTime dataDevolucao = LerData("Insira a data da Devolução (dd/MM/AAAA): ");

        if(dataDevolucao < dataEmprestimo)
        {
            Console.WriteLine("A data de devolução não pode ser anterior à do empréstimo.");
            return;
        }

        int diasAtraso = CalcularDiasAtraso(prazoDevolucao, dataDevolucao);

        Console.WriteLine($"Seu(s) dia(s) de Atraso é (são): {diasAtraso}");

        decimal multa = CalcularMulta(diasAtraso);
        Console.WriteLine($"Sua multa é de: R${multa:F2}");
    }

    public static void VerificarEmprestimos()
    {
        Console.Write("Informe a quantidade de empréstimos ativos que você possui: ");
        string emprestimosAtivosStr = Console.ReadLine();

        bool verificacao = int.TryParse(emprestimosAtivosStr, out int emprestimosAtivos);
        
        if (!verificacao || emprestimosAtivos < 0)
        {
            Console.WriteLine("Digite uma quantidade válida (inteira e >= 0)");
            return;
        }
        if (PodeEmprestar(emprestimosAtivos))
        {
            Console.WriteLine("Você pode emprestar!");
            return;
        }
        Console.WriteLine("Você não pode emprestar!");

    }

    public static void Menu()
    {
        Console.WriteLine("=== MENU DA BIBLIOTECA ===");
        Console.WriteLine("1. Calcular prazo de devolução");
        Console.WriteLine("2. Calcular multa de uma devolução");
        Console.WriteLine("3. Verificar limite de empréstimos");
        Console.WriteLine("0. Sair");
    }

    public static void Testes()
    {
        DateTime dataEmprestimo = new DateTime(2026, 11, 17);
        DateTime prazoDevolucao = CalcularPrazoDevolucao(dataEmprestimo);

        Console.WriteLine(prazoDevolucao.ToString("dd/MM/yyyy"));

        Console.WriteLine(CalcularDiasAtraso(prazoDevolucao, new DateTime(2026, 12, 2))); //saída 1 dia de atraso
        Console.WriteLine(CalcularMulta(15)); //saída R$30 de multa 
        Console.WriteLine(PodeEmprestar(3));  //com 3 não pode, pois passaria o limite e ficaria com 4
    }

    public static DateTime CalcularPrazoDevolucao(DateTime dataEmprestimo)
    {
        return dataEmprestimo.AddDays(PrazoDeDevolucaoDias);
    }

    public static int CalcularDiasAtraso(DateTime prazo, DateTime dataDevolucao)
    {
        int diasDeAtraso = 0;
        if (dataDevolucao.Date > prazo.Date)
        {
            diasDeAtraso = (dataDevolucao.Date - prazo.Date).Days;
        } 
        return diasDeAtraso;
    }

    public static decimal CalcularMulta(int diasAtraso)
    {
        decimal multaTotal = TetoMulta;
        decimal multaCalculada = MultaPorDia * diasAtraso;

        if (multaCalculada < TetoMulta)
        {
            multaTotal = multaCalculada;
        }

        return multaTotal;
    }

    public static bool PodeEmprestar(int emprestimosAtivos)
    {
        //Verifica se emprestimoAtivos é menor que LimiteEmprestimosAtivos (true ou false) 
        //não pode ser <= , pois temos que pensar em quantos emprestimos ele vai ter depois de validarmos se ele pode emprestar +1
        return emprestimosAtivos < LimiteEmprestimosAtivos;
    }

    public static DateTime LerData(string mensagem)
    {
        while (true)
        {
            // 1. mostrar a mensagem (Console.Write)
            Console.Write(mensagem);
            // 2. ler o que foi digitado e guardar em uma variável string?
            string texto = Console.ReadLine();
            
            if (DateTime.TryParseExact(texto, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data))
            {
                return data;
            }
            Console.WriteLine("Data inválida. Use o formato dd/MM/aaaa.");
        }
    }
}
