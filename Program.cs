using System;
using System.Diagnostics;
using static System.Console;
using System.Text;
using System.IO;

namespace ConsoleCRUD
{
    class MainClass
    {
        public static void printMenu(String[] options)
        {
            foreach (String option in options)
            {
                WriteLine(option);
            }
            WriteLine("Escolha a sua opção:");
        }

        public static void Main(String[] args)
        {
            WriteLine(">>>> CADASTRO DE PESSOAS <<<<");
            String[] options = { "1 - Cadastrar",
                                 "2 - Editar",
                                 "3 - Excluir",
                                 "4 - Listar",
                                 "5 - Gravar",
                                 "6 - Ler",
                                 "7 - Sair"};
            int option = 0;
            while (true)
            {
                printMenu(options);
                try
                {
                    option = Convert.ToInt32(ReadLine());
                }
                catch (System.FormatException)
                {
                    WriteLine("Por favor, digite uma opção entre 1 e " + options.Length);
                    continue;
                }
                catch (Exception)
                {
                    WriteLine("Um erro aconteceu!!");
                    continue;
                }
                switch (option)
                {
                    case 1:
                        Cadastrar();
                        break;
                    case 2:
                        Editar();
                        break;
                    case 3:
                        Excluir();
                        break;
                    case 4:
                        Listar();
                        break;
                    case 5:
                        Gravar();
                        break;
                    case 6:
                        Ler();
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        WriteLine("Por favor, digite uma opção entre 1 e " + options.Length);
                        break;
                }
            }
        }

        static List<string> nomes = new List<string>();
        static List<int> idades = new List<int>();

        private static void Cadastrar()
        {
            Clear();
            WriteLine(">>>> CADASTRO DE PESSOA <<<<");
            WriteLine();
            WriteLine("Digite o nome da pessoa:");
            string nome = ReadLine();
            var repetido = nomes.Any(x => x.Contains(nome));
            if (repetido == true)
            {
                WriteLine("Esta pessoa já existe em nossa base de dados!!!\n");
                return;
            }
            else
            {
                nomes.Add(nome);
            }
            WriteLine("Digite a idade da pessoa:");
            idades.Add(Convert.ToInt32(ReadLine()));
            WriteLine();
        }

        private static void Listar()
        {
            Clear();
            WriteLine();
            WriteLine(">>>> LISTAGEM DE PESSOAS <<<<");
            int pos = 0;
            foreach (var item in nomes)
            {
                WriteLine($"Nome: {item}, idade: {idades[pos]}");
                pos++;
            }
            WriteLine();
        }

        private static void Editar()
        {
            Clear();
            WriteLine();
            ForegroundColor = ConsoleColor.Green;
            WriteLine(">>>> EDIÇÃO DA PESSOA <<<<");
            WriteLine();
            ResetColor();
            string nome = "";
            WriteLine("Digite o nome que você deseja editar:");
            nome = ReadLine();
            int index = nomes.IndexOf(nome);
            if (index >= 0)
            {
                WriteLine(">>>> Registro que será editado <<<<");
                WriteLine($"Nome: {nomes[index]}");
                WriteLine($"Idade: {idades[index]}");
                WriteLine();
                WriteLine("Digite o nome:");
                nomes[index] = ReadLine();
                WriteLine("Digite a idade:");
                idades[index] = Convert.ToInt32(ReadLine());
                WriteLine();
                WriteLine("Pessoa editada com sucesso!!");
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Registro não encontrado!!!!");
                ResetColor();
            }
        }

        private static void Excluir()
        {
            Clear();
            WriteLine();
            ForegroundColor = ConsoleColor.Green;
            WriteLine(">>>> EXCLUSÃO DA PESSOA <<<<");
            WriteLine();
            ResetColor();
            string nome = "";
            WriteLine("Digite o nome que você deseja excluir:");
            nome = ReadLine();
            int index = nomes.IndexOf(nome);
            if (index >= 0)
            {
                WriteLine(">>>> Registro que será excluído <<<<");
                WriteLine($"Nome: {nomes[index]}");
                WriteLine($"Idade: {idades[index]}");
                WriteLine();
                nomes.RemoveAt(index);
                idades.RemoveAt(index);
                WriteLine();
                WriteLine("Pessoa excluída com sucesso!!");
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Registro não encontrado!!!!");
                ResetColor();
            }
        }

        private static void Gravar()
        {
            WriteLine();
            WriteLine(">>>> GRAVANDO OS DADOS <<<<");
            try
            {
                StreamWriter dados;
                string arq = @"C:\\Users\\Aluno\\source\\repos\\ConsoleApp1\\dados.txt";
                dados = File.CreateText(arq);
                foreach (var item in nomes)
                {
                    dados.WriteLine($"{item}");
                }
                dados.Close();
                StreamWriter dados2;
                string arq2 = @"C:\\Users\\Aluno\\source\\repos\\ConsoleApp1\\dados2.txt";
                dados2 = File.CreateText(arq2);
                foreach (var item2 in idades)
                {
                    dados2.WriteLine($"{item2}");
                }
                dados2.Close();
                WriteLine();
            }
            catch (Exception e)
            {
                WriteLine("Erro: " + e.Message);
            }
            finally
            {
                WriteLine("Dados gravados");
            }
        }

        private static void Ler()
        {
            Clear();
            WriteLine();
            WriteLine(">>>> LENDO ARQUIVO <<<<");
            WriteLine();
            var nome = File.ReadAllLines(@"C:\\Users\\Aluno\\source\\repos\\ConsoleApp1\\dados.txt");
            for (int i = 0; i < nome.Length; i++)
            {
                nomes.Add(nome[i]);
            }
            var idade = File.ReadAllLines(@"C:\\Users\\Aluno\\source\\repos\\ConsoleApp1\\dados2.txt");
            for (int i = 0; i < idade.Length; i++)
            {
                idades.Add(Convert.ToInt32(idade[i]));
            }
            WriteLine();
            WriteLine(">>>> LEITURA DE DADOS COM EXITO <<<<");

        }

    }

}