using System;
using System.Collections.Generic;

namespace exercicioPraticoMenu
{
    class Program
    {
        static List<string> nomes = new List<String>();
        static void Main(string[] args)
        {
            // Invoca a função menu()

            menu();
        }

        private static void menu()
        {
            /* Invoca a construção gráfica do menu, repetidamente, até que a opção "sair" seja digitada, 
                 e também funciona lendo a entrada (opção do menu) */

            construcaoDoMenu();
            inserirNoMenu(Console.ReadLine());
        }

        private static void construcaoDoMenu()
        {
            // Construção do Menu em si

            Console.WriteLine("---------------------------------------------------\n" +
            "Bem-vindo! Acesse uma opção no menu:\n" +
            "Para adicionar nomes a lista, digite 1\n" +
            "Para ler os nomes inseridos na lista, digite 2\n" +
            "Para atualizar/corrigir um nome na lista, digite 3\n" +
            "Para deletar um nome da lista, digite 4\n" +
            "Para encerrar as operações, digite sair\n" +
            "---------------------------------------------------");
        }
        /* int.TryParse(Console.ReadLine(), out opcao); - Foi criado para converter a entrada (string) em int, mas
     depois percebi que não era necessário, mas resolvi comentar caso eu precise futuramente */

        private static void inserirNoMenu(string opcao)
        {
            // Aqui acontece o funcionamento de escolhas do Menu, lendo a opção escolhida e efetuando a ação programada

            switch (opcao)
            {
                case "1":
                    adicionarNome();
                    construcaoDoMenu();
                    inserirNoMenu(Console.ReadLine());
                    break;
                case "2":
                    listarNome();
                    construcaoDoMenu();
                    inserirNoMenu(Console.ReadLine());
                    break;
                case "3":
                    alterarNome();
                    construcaoDoMenu();
                    inserirNoMenu(Console.ReadLine());
                    break;
                case "4":
                    deletarNome();
                    construcaoDoMenu();
                    inserirNoMenu(Console.ReadLine());
                    break;
                case "sair":
                    Console.WriteLine("Fim");
                    break;
                default:
                    Console.WriteLine("Digite uma opção válida: ");
                    construcaoDoMenu();
                    inserirNoMenu(Console.ReadLine());
                    break;
            }
        }

        private static bool verificarNome(string nome)
        {
            /* Vendo vídeos e lendo exercícios resolvidos na internet sobre C#, achei algo interessante e resolvi implementar aqui,
            que é uma função responsável pela verificação em quase todo o código, não sendo necessário refazer essa verificação
            a cada nova função. No caso, essa verificação examina se o nome inserido é, ou não, uma duplicata */

            foreach (string n in nomes)
            {
                if (nome.Trim() == n.Trim())
                {
                    return true;
                }
            }
            return false;
        }
        private static void adicionarNome()
        {
            // Aqui é a função de adicionar nome na vida, que é a 1 do Menu

            Console.WriteLine("Insira um nome na lista:");

            string nome = Console.ReadLine();

            if (!verificarNome(nome))
            {
                if (string.IsNullOrWhiteSpace(nome))
                {
                    Console.WriteLine("O formato do nome é invalido.");
                }
                else
                {
                    nomes.Add(nome);
                    Console.WriteLine("O nome foi adicionado na lista com sucesso!");
                }
            }
            else
            {
                Console.WriteLine("O nome inserido já existe na lista.");
            }
        }

        private static void listarNome()
        {
            // Aqui é a função que mostra a lista de nomes, acionada pelo 2 no Menu

            for (int i = 0; i < nomes.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {nomes[i]}");
            }
            Console.WriteLine();
        }

        private static void alterarNome()
        {
            // Aqui é a função que altera, ou atualiza, um nome na lista, acionada pelo número 3 no Menu

            Console.WriteLine("Digite o nome que deseja alterar na lista:");
            string nomeAlteracao = Console.ReadLine();

            if (verificarNome(nomeAlteracao))
            {
                for (int i = 0; i < nomes.Count; i++)
                {

                    if (nomes[i].Trim() == nomeAlteracao.Trim())
                    {
                        Console.WriteLine("Insira a nova versão do nome:");
                        string novoNome = Console.ReadLine();

                        if (verificarNome(novoNome))
                        {
                            Console.WriteLine("O nome já consta na lista.");
                        }
                        else
                        {
                            nomes[i] = novoNome;
                            Console.WriteLine("O nome foi atualizado!");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("O nome inserido não existe na lista.");
            }

        }

        private static void deletarNome()
        {
            // Aqui é a função que deleta nomes da lista, acionada pelo número 4 do Menu

            Console.WriteLine("Digite o nome da lista que deseja excluir:");
            string nome = Console.ReadLine();

            if (verificarNome(nome))
            {
                for (int i = 0; i < nomes.Count; i++)
                {

                    if (nomes[i] == nome)
                    {
                        nomes.RemoveRange(i, 1);
                        Console.WriteLine("Nome excluído da lista!");
                    }
                }
            }
            else
            {
                Console.WriteLine("O nome inserido é inválido.");
            }
        }
    }
}
