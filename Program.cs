using System;

namespace Dios.Series
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
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
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                Console.ReadLine();
                Console.Clear();

                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            validarSerieNaoEncontrada(indiceSerie);

            var serie = repository.retornaPorId(indiceSerie);
            if (serie == null)
            {
                Console.WriteLine("Nenhuma série encontrada com o id informado");
                return;
            }

            Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            validarSerieNaoEncontrada(indiceSerie);

            repository.Exclui(indiceSerie);
            Console.WriteLine("Sèrie excluida com sucesso");
        }

        private static void AtualizarSerie()
        {

            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            validarSerieNaoEncontrada(indiceSerie);

            repository.Atualiza(indiceSerie, obterDadosSerie(indiceSerie));
            Console.WriteLine("Sèrie atualizada com sucesso");
        }

        private static void InserirSerie()
        {
            repository.Insere(obterDadosSerie(repository.ProximoId()));

            Console.WriteLine("Série cadastrada com sucesso");
        }

        private static Serie obterDadosSerie(int id)
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o código do gênero: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            return new Serie(id, (Genero)entradaGenero, entradaTitulo, entradaDescricao, entradaAno);
        }
        private static void ListarSeries()
        {
            var lista = repository.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            Console.WriteLine("Lista de séries");
            foreach (var serie in lista)
            {
                if (!serie.isRemoved())
                  Console.WriteLine("#ID {0}: {1}", serie.retornaId(), serie);
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Series a seu dispor !!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir nova Séries");
            Console.WriteLine("3 - Atualizar Séries");
            Console.WriteLine("4 - Excluir Séries");
            Console.WriteLine("5 - Visualizar Séries");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void validarSerieNaoEncontrada(int id)
        {
            if (repository.retornaPorId(id) == null)
            {
                Console.WriteLine("Nenhuma série encontrada com o id informado");
                return;
            }
        }
    }
}
