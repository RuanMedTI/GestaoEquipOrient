using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquipOrient.ConsoleApp
{
        public class Produto
        {
        //atributos publicos
            public string nomeProduto { get; set; }
            public string precoProduto { get; set; }
            public int IdProdutos { get; set; }
            public string dataProdutoDia { get; set; }
            public string dataProdutoMes { get; set; }
            public string dataProdutoAno { get; set; }
            public string fabriProduto { get; set; }

        static int id = 1;
        static List<Produto> produtos = new List<Produto>();

        //Adicionar um produto
        public static void AddProduto()
        {
            string nomeProduto, precoProduto, dataProdutoDia, dataProdutoMes, dataProdutoAno, fabriProduto;
            MetodoAddProduto(out nomeProduto, out precoProduto, out dataProdutoDia, out dataProdutoMes, out dataProdutoAno, out fabriProduto);
            bool nomeMenorSeis = false;

            if (nomeProduto.Length < 6)
            {
                nomeMenorSeis = true;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Min 6 caracteres");
                Console.ResetColor(); ;
            }

            produtos.Add(new Produto()
            {
                IdProdutos = id++,
                nomeProduto = nomeProduto,
                precoProduto = precoProduto,
                dataProdutoDia = dataProdutoDia,
                dataProdutoMes = dataProdutoMes,
                dataProdutoAno = dataProdutoAno,
                fabriProduto = fabriProduto,
            });
        }

        //Editar um produto, primeiro pede o ID, após isso as informaçoes.
        public static void EditarProduto()
        {
            MetodoEditarProduto();

        }

        private static void MetodoEditarProduto()
        {
            var produto = EncontrarProdutoPorId();
            Console.WriteLine("Nome do equipamento: ");
            produto.nomeProduto = Console.ReadLine();
            Console.WriteLine("Preço do equipamento: ");
            produto.precoProduto = Console.ReadLine();
            Console.WriteLine("Data de fabricação (DD): ");
            produto.dataProdutoDia = Console.ReadLine();
            Console.WriteLine("Data de fabricação (MM): ");
            produto.dataProdutoMes = Console.ReadLine();
            Console.WriteLine("Data de fabricação (AA): ");
            produto.dataProdutoAno = Console.ReadLine();
        }

        //Método para encontrar um produto pelo iD
        public static Produto EncontrarProdutoPorId()
        {
            Console.WriteLine("Insira o ID: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Por favor, digite um número válido");
            }

            foreach (var item in produtos)
            {
                if (item.IdProdutos == id)
                {
                    return item;
                }
            }
            return null;
        }
        //Excluir um produto
        public static void ExcluirProduto()
        {
            MetodoExcluirProduto();
        }

        private static void MetodoExcluirProduto()
        {
            var EncontreProduto = EncontrarProdutoPorId();
            if (EncontreProduto != null)
            {
                produtos.Remove(EncontreProduto);
            }
        }

        

        private static void MetodoAddProduto(out string nomeProduto, out string precoProduto, out string dataProdutoDia,
            out string dataProdutoMes, out string dataProdutoAno, out string fabriProduto)
        {
            Console.WriteLine("Nome do Produto: ");
            nomeProduto = Console.ReadLine();
            Console.WriteLine("Preço do Produto: ");
            precoProduto = Console.ReadLine();
            Console.WriteLine("Data de Fabricação: (DD) ");
            dataProdutoDia = Console.ReadLine();
            Console.WriteLine("Data de Fabricação: (MM) ");
            dataProdutoMes = Console.ReadLine();
            Console.WriteLine("Data de Fabricação: (AA) ");
            dataProdutoAno = Console.ReadLine();
            Console.WriteLine("Fabricante do produto: ");
            fabriProduto = Console.ReadLine();
        }


        //Listar os produtos
        public static void ListarProdutos()
        {
            Console.WriteLine("\nLista de Equipamentos");
            foreach (var produto in produtos)
            {
                Console.WriteLine($" Id: {produto.IdProdutos} \n" +
                                $" Nome do Produto: {produto.nomeProduto} \n" +
                                $" Preço do produto: {produto.precoProduto} Reais \n" +
                                $" Data de Fabricação: {produto.dataProdutoDia} \n" +
                                $" Mês de Fabricação: {produto.dataProdutoMes} \n" +
                                $" Ano de Fabricação: {produto.dataProdutoAno} \n");
            }
            Console.WriteLine("\n");

        }

        }
}

