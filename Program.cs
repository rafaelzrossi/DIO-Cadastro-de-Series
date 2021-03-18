using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                Console.WriteLine();
                opcaoUsuario = ObterOpcaoUsuario();

            }

            
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("DIO Series a seu dispor!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir Nova Série");
            Console.WriteLine("3 - Atualizar Série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Visualizar Série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();


            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    
        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");

            var lista = repositorio.Lista();

            if(lista.Count == 0){
                Console.WriteLine("Nenhuma Série Cadastrada.");
                return;
            }

            foreach(var serie in lista)
            {
                Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir uma nova série");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.proximoId(),
                                        genero: (Genero)entradaGenero,
                                        ano: entradaAno,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }
    
        private static void AtualizarSerie(){
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie serieAtualizada = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        ano: entradaAno,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, serieAtualizada);
        }
    
        private static void ExcluirSerie(){
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            Serie serie = repositorio.RetornaPorId(indiceSerie);

            serie.Exclui();
        }

        private static void VisualizarSerie(){
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            Serie serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie.ToString());
        }
       
    }
}
