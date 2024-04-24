// See https://aka.ms/new-console-template for more information
public class Program
{
    /// <summary>
    /// Displays a welcome message.
    /// </summary>
    public static void ExibirBoasVindas()
    {
        string curso = "C# criando sua primeira aplicação";
        string nome = "Augusto";
        string sobrenome = "Scardua";
        Console.Clear();
        Console.WriteLine(curso);
        Console.WriteLine(nome + " " + sobrenome);
        Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
        Console.WriteLine("Boas vindas ao Screen Sound\n");

    }

    /// <summary>
    /// Waits for the user to press any key before continuing.
    /// </summary>
    public static void waitUser()
    {
        Console.WriteLine("Pressione qualquer tecla para continuar");
        Console.ReadKey();
    }

    /// <summary>
    /// Displays the menu options and handles user input.
    /// </summary>
    public static void ExibirOpcoesMenu(Bandas bandas)
    {
        ExibirBoasVindas();
        Console.WriteLine("Menu");
        Console.WriteLine("Digite 1 para registrar uma banda");
        Console.WriteLine("Digite 2 para mostrar todas as bandas");
        Console.WriteLine("Digite 3 para avaliar uma banda");
        Console.WriteLine("Digite 4 para exibir a média de uma banda");
        Console.WriteLine("Digite 5 para excluír uma banda");
        Console.WriteLine("Digite -1 para sair");
        try
        {
            int opcao = int.Parse(Console.ReadLine());
            Console.WriteLine("Opção escolhida: " + opcao);

            switch (opcao)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Digite o nome da banda");
                    try
                    {
                        string nomeDaBanda = Console.ReadLine();
                        bandas.adicionarBanda(nomeDaBanda);
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Erro ao adicionar banda");
                    }
                    waitUser();
                    ExibirOpcoesMenu(bandas);
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("Listando as bandas");
                    bandas.listarBandas();
                    Console.WriteLine("Fim da lista");
                    waitUser();
                    ExibirOpcoesMenu(bandas);
                    break;

                case 3:
                    Console.WriteLine("Digite o nome da banda que deseja avaliar");

                    try
                    {
                        string nomeDaBanda = Console.ReadLine();
                        Console.WriteLine("Digite a nota da banda");
                        int nota = int.Parse(Console.ReadLine());
                        bandas.avaliarBanda(nomeDaBanda, nota);
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Erro ao avaliar banda");
                    }

                    ExibirOpcoesMenu(bandas);
                    waitUser();
                    break;

                case 4:
                    Console.WriteLine("Digite o nome da banda que deseja ver a média");
                    ExibirOpcoesMenu(bandas);

                    try
                    {
                        string nomeDaBanda = Console.ReadLine();
                        if (bandas.listaDasBandas.ContainsKey(nomeDaBanda))
                        {
                            List<int> notas = bandas.listaDasBandas[nomeDaBanda];
                            double media = 0;
                            foreach (int nota in notas)
                            {
                                media += nota;
                            }
                            media /= notas.Count;
                            Console.WriteLine($"A média da banda {nomeDaBanda} é {media}");
                        }
                        else
                        {
                            Console.WriteLine($"Banda {nomeDaBanda} não encontrada");
                        }
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Erro ao calcular média");
                    }

                    ExibirOpcoesMenu(bandas);
                    waitUser();
                    break;

                case 5:
                    Console.WriteLine("Digite o nome da banda que deseja excluir");
                    try
                    {
                        string nomeDaBanda = Console.ReadLine();
                        bandas.excluirBanda(nomeDaBanda);
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Erro ao excluir banda");
                    }

                    ExibirOpcoesMenu(bandas);
                    waitUser();
                    break;
                case -1:
                    Console.WriteLine("Saindo do programa");
                    Console.Clear();
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Digite um número válido");
        }
    }

    public static void Main(string[] args)
    {
        Bandas bandas = new Bandas("default");
        ExibirOpcoesMenu(bandas);
    }
}