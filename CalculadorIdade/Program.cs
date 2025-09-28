using System;
using System.Globalization;

namespace CalculadorIdade
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== CALCULADOR DE IDADE E VERIFICADOR DE HABILITAÇÃO ===");
            Console.WriteLine($"Data atual do sistema: {DateTime.Now:dd/MM/yyyy}");
            Console.WriteLine(new string('=', 50));

            bool continuar = true;

            while (continuar)
            {
                try
                {
                    // Solicitar data de nascimento
                    DateTime dataNascimento = SolicitarDataNascimento();

                    // Calcular idade
                    int idade = CalcularIdade(dataNascimento);

                    // Exibir resultados
                    ExibirResultados(dataNascimento, idade);

                    // Verificar habilitação
                    VerificarHabilitacao(idade);

                    // Perguntar se deseja continuar
                    continuar = DesejaCalcularNovamente();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nErro: {ex.Message}");
                    Console.WriteLine("Pressione qualquer tecla para tentar novamente...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            Console.WriteLine("\nObrigado por usar o Calculador de Idade!");
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        static DateTime SolicitarDataNascimento()
        {
            while (true)
            {
                Console.WriteLine("\nFormatos aceitos:");
                Console.WriteLine("- dd/mm/aaaa (ex: 15/03/1990)");
                Console.WriteLine("- dd-mm-aaaa (ex: 15-03-1990)");
                Console.WriteLine("- dd.mm.aaaa (ex: 15.03.1990)");
                Console.Write("Digite sua data de nascimento: ");

                string entrada = Console.ReadLine();

                // Tentar vários formatos de data
                string[] formatosAceitos = {
                    "dd/MM/yyyy",   // 15/03/1990
                    "dd-MM-yyyy",   // 15-03-1990
                    "dd.MM.yyyy",   // 15.03.1990
                    "d/M/yyyy",     // 5/3/1990
                    "d-M-yyyy",     // 5-3-1990
                    "d.M.yyyy"      // 5.3.1990
                };

                DateTime data = DateTime.MinValue;
                bool dataValida = false;

                // Tentar parse com cultura invariante (garante dd/mm/yyyy)
                foreach (string formato in formatosAceitos)
                {
                    if (DateTime.TryParseExact(entrada, formato,
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out data))
                    {
                        dataValida = true;
                        break;
                    }
                }

                // Se não conseguiu com formatos específicos, tentar com cultura atual
                if (!dataValida)
                {
                    if (DateTime.TryParse(entrada, CultureInfo.CurrentCulture, DateTimeStyles.None, out data))
                    {
                        dataValida = true;
                        Console.WriteLine($"Data interpretada como: {data:dd/MM/yyyy}");
                        Console.Write("Esta data está correta? (s/n): ");

                        ConsoleKeyInfo confirmacao = Console.ReadKey();
                        Console.WriteLine();

                        if (confirmacao.Key != ConsoleKey.S)
                        {
                            continue;
                        }
                    }
                }

                if (dataValida)
                {
                    // Validar se a data não é futura
                    if (data > DateTime.Now)
                    {
                        Console.WriteLine("Erro: A data de nascimento nao pode ser no futuro!");
                        continue;
                    }

                    // Validar se a data não é muito antiga (mais de 120 anos)
                    if (DateTime.Now.Year - data.Year > 120)
                    {
                        Console.WriteLine("Erro: Data muito antiga! Verifique a data informada.");
                        continue;
                    }

                    // Confirmar a data final
                    Console.WriteLine($"Data confirmada: {data:dd/MM/yyyy} ({data:dddd})");
                    return data;
                }
                else
                {
                    Console.WriteLine("Formato de data invalido!");
                    Console.WriteLine("Por favor, use um dos formatos mostrados acima.");
                }
            }
        }

        static int CalcularIdade(DateTime dataNascimento)
        {
            DateTime hoje = DateTime.Now;
            int idade = hoje.Year - dataNascimento.Year;

            // Verificar se ainda não fez aniversário este ano
            if (hoje.Month < dataNascimento.Month ||
                (hoje.Month == dataNascimento.Month && hoje.Day < dataNascimento.Day))
            {
                idade--;
            }

            return idade;
        }

        static void ExibirResultados(DateTime dataNascimento, int idade)
        {
            Console.WriteLine("\n" + new string('-', 40));
            Console.WriteLine("RESULTADO DO CALCULO");
            Console.WriteLine(new string('-', 40));

            Console.WriteLine($"Data de nascimento: {dataNascimento:dd/MM/yyyy}");
            Console.WriteLine($"Data atual: {DateTime.Now:dd/MM/yyyy}");
            Console.WriteLine($"Sua idade é: {idade} anos");
        }

        static void VerificarHabilitacao(int idade)
        {
            Console.WriteLine("\n" + new string('-', 40));
            Console.WriteLine("VERIFICACAO DE HABILITACAO");
            Console.WriteLine(new string('-', 40));

            if (idade >= 18)
            {
                Console.WriteLine("RESULTADO: PODE TIRAR CARTEIRA DE HABILITACAO!");
                Console.WriteLine($"Você tem {idade} anos e já atingiu a idade mínima de 18 anos.");
            }
            else
            {
                int anosRestantes = 18 - idade;
                Console.WriteLine("RESULTADO: NAO PODE TIRAR CARTEIRA DE HABILITACAO");
                Console.WriteLine($"Voce tem {idade} anos.");
                Console.WriteLine($"Ainda faltam {anosRestantes} ano(s) para atingir a idade minima de 18 anos.");

                // Calcular quando poderá tirar
                DateTime dataHabilitacao = DateTime.Now.AddYears(anosRestantes);
                Console.WriteLine($"Voce podera tirar a habilitacao a partir de: {dataHabilitacao:dd/MM/yyyy}");
            }
        }

        static bool DesejaCalcularNovamente()
        {
            Console.WriteLine("\n" + new string('=', 50));
            Console.Write("Deseja calcular outra idade? (s/n): ");

            while (true)
            {
                ConsoleKeyInfo tecla = Console.ReadKey();
                Console.WriteLine();

                if (tecla.Key == ConsoleKey.S)
                {
                    Console.Clear();
                    Console.WriteLine("=== CALCULADOR DE IDADE E VERIFICADOR DE HABILITACAO ===");
                    Console.WriteLine($"Data atual do sistema: {DateTime.Now:dd/MM/yyyy}");
                    Console.WriteLine(new string('=', 50));
                    return true;
                }
                else if (tecla.Key == ConsoleKey.N)
                {
                    return false;
                }
                else
                {
                    Console.Write("Por favor, digite 's' para sim ou 'n' para nao: ");
                }
            }
        }
    }
}