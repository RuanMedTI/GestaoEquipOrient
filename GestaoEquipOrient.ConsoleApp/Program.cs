using System;
using System.Collections.Generic;

namespace GestaoEquipOrient.ConsoleApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<Produto> produtos = new List<Produto>();
            List<Chamado> chamados = new List<Chamado>();

            string[] menuItems = MostreOpcoesMenu();

            var selection = MostrarMenu(menuItems);

            while (selection != 9)
            {
                switch (selection)
                {
                    case 1:
                        Produto.ListarProdutos();
                        break;
                    case 2:
                        Produto.AddProduto();
                        break;
                    case 3:
                        Produto.ExcluirProduto();
                        break;
                    case 4:
                        Produto.EditarProduto();
                        break;
                    case 5:
                        Chamado.ListarChamado();
                        break;
                    case 6:
                        Chamado.AbrirChamado();
                        break;
                    case 7:
                        Chamado.EditarChamado();
                        break;
                    case 8:
                        Chamado.ExcluirChamado();
                        break;
                    default:
                        break;
                }
                selection = MostrarMenu(menuItems);
            }
            Console.WriteLine("Até mais :)");
            Console.ReadLine();
        }
        private static string[] MostreOpcoesMenu()
        {
            return new string[]{
                "Mostre todos os produtos",
                "Adicionar um produto",
                "Deletar um produto",
                "Editar um produto",
                "Listar os chamados",
                "Abrir um chamado",
                "Editar um chamado",
                "Deletar o chamado",
                "Sair"
            };
        }
        //Mostrar o menu inicial
        private static int MostrarMenu(string[] menuItems)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Gestão de Equipamentos\n");
            Console.WriteLine("Academia do Programador\n");

            for (int i = 0; i < menuItems.Length; i++)
            {

                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 9)
            {
                Console.WriteLine("Por favor selecione um número de 1-9");
            }
            return selection;
        }
    }
}
