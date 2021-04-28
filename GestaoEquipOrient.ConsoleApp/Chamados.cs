using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquipOrient.ConsoleApp
{
    internal class Chamado
    {
        //atributos publicos
        public string tituloChamado { get; set; }
        public string descriChamado { get; set; }
        public int IdChamados { get; set; }
        public string dataChamadoDia { get; set; }

        public string dataChamadoMes { get; set; }

        public string diaAtualChamado {get; set;}

        public string dataChamadoAno { get; set; }

        public string diasAberto { get; set; }
        public string equipChamado { get; set; }

        static int id = 1;

        static List<Chamado> chamados = new List<Chamado>();

        public static void ChamadoMostrar(List<Chamado> chamados)
        {
            chamados.Add(new Chamado()
            { 
                IdChamados = id++,
                tituloChamado = "Manutenção mouse",
                descriChamado = "Arrumar sensor do mouse",
                dataChamadoDia = "16",
                dataChamadoMes = "02",
                dataChamadoAno = "2020",
                equipChamado = "Teclado"
            });

        }

            private static Chamado EncontrarProdutoPorId1()
        {
            Console.WriteLine("Insira o ID: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Por favor, digite um número válido");
            }

            foreach (var item in chamados)
            {
                if (item.IdChamados == id)
                {
                    return item;
                }
            }
            return null;
        }

        //Listar Chamados
        public static void ListarChamado()
        {
            Console.WriteLine("\nLista de Chamados");

            foreach (var chamado in chamados)
            {

               Console.WriteLine($" Id: {chamado.IdChamados} \n"
                                + $" Título do Chamado: {chamado.tituloChamado} \n" +
                                $" Descrição do Chamado: {chamado.descriChamado} \n"
                                + $" {chamado.equipChamado} \n" +
                                $"O chamado está aberto desde: \n" +
                                $" Data do Chamado: {chamado.dataChamadoDia} \n"
                                + $" Mês Aberto: {chamado.dataChamadoMes} \n"
                                + $" Ano: {chamado.dataChamadoAno} \n"
                                );
            }
            Console.WriteLine("\n");

        }

        //Abrir chamado
        public static void AbrirChamado()
        {
            string dataChamadoDia;
            string tituloChamado, descriChamado, equipChamado, dataChamadoMes, dataChamadoAno;
            MetodoAbrirChamado(out tituloChamado, out descriChamado, out dataChamadoMes, out dataChamadoDia, out dataChamadoAno, out equipChamado);
            string diasAberto = (dataChamadoDia).ToString();
            chamados.Add(new Chamado()
            {
                IdChamados = id++,
                tituloChamado = tituloChamado,
                descriChamado = descriChamado,
                dataChamadoDia = dataChamadoDia,
                dataChamadoMes = dataChamadoMes,
                dataChamadoAno = dataChamadoAno,
                equipChamado = equipChamado,
            });

        }

        private static void MetodoAbrirChamado(out string tituloChamado, out string descriChamado, out string dataChamadoDia, out string dataChamadoMes, out string dataChamadoAno, out string equipChamado)
        {
            Console.WriteLine("Título do chamado: ");
            tituloChamado = Console.ReadLine();
            Console.WriteLine("Descrição do chamado: ");
            descriChamado = Console.ReadLine();
            Console.WriteLine("Abertura do chamado: (DD) ");
            dataChamadoDia = Console.ReadLine();
            Console.WriteLine("Abertura do chamado: (MM) ");
            dataChamadoMes = Console.ReadLine();
            Console.WriteLine("Abertura do chamado: (AA) ");
            dataChamadoAno = Console.ReadLine();
            Console.WriteLine("Equipamento: ");
            equipChamado = Console.ReadLine();

        }

        public static void EditarChamado()
        {
            var chamado = EncontrarProdutoPorId1();
            MetodoEditarChamado(chamado);

        }

        private static void MetodoEditarChamado(Chamado chamado)
        {
            Console.WriteLine("Nome do equipamento: ");
            chamado.tituloChamado = Console.ReadLine();
            Console.WriteLine("Preço do equipamento: ");
            chamado.descriChamado = Console.ReadLine();
            Console.WriteLine("Data do chamado (DD) ");
            chamado.dataChamadoDia = Console.ReadLine();
            Console.WriteLine("Data do chamado (MM) ");
            chamado.dataChamadoMes = Console.ReadLine();
            Console.WriteLine("Data do chamado (AA) ");
            chamado.dataChamadoAno = Console.ReadLine();
            Console.WriteLine("Equipamento: ");
            var equipChamado = Console.ReadLine();
        }

        public static void ExcluirChamado()
        {
            MetodoExcluirChamado();
        }

        private static void MetodoExcluirChamado()
        {
            var encontreChamado = EncontrarProdutoPorId1();
            if (encontreChamado != null)
            {
                chamados.Remove(encontreChamado);
                Console.WriteLine("Chamado excluído :( ");
            }
        }

    }

}

