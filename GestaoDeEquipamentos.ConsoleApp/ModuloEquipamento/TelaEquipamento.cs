using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento
{
    class TelaEquipamento
    {
        public RepositorioEquipamento repositorioEquipamento;
        public TelaEquipamento()
        {
            repositorioEquipamento = new RepositorioEquipamento();
        }

        public void ExibirCabecalho()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("|          Controle de Equipamentos         |");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine();
        }

        public char ApresentarMenu()
        {            
            ExibirCabecalho();
            
            Console.WriteLine("1 - Cadastro de Equipamento");
            Console.WriteLine("2 - Editar Equipamento");
            Console.WriteLine("1 - Excluir Equipamento");
            Console.WriteLine("4 - Visualização dos Equipamentos Cadastrados");
            Console.WriteLine("S - Voltar");
            Console.WriteLine("--------------------------------------------");
            Console.Write("Escolha a operação desejada: ");
            char opcaoEscolhida = Console.ReadLine()[0];

            return opcaoEscolhida;
        }
        public void CadastrarEquipamento()
        {
            ExibirCabecalho();

            Console.WriteLine();

            Console.WriteLine("Cadastrando Equipamento...");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine();

            Console.Write("Digite o nome do equipamento: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a fabricante do equipamento: ");
            string fabricante = Console.ReadLine();

            Console.Write("Digite o valor de aquisição - R$: ");
            decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Digite a data de fabricação - (dd/MM/yyyy): ");
            DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

            Equipamento novoEquipamento = new Equipamento(nome, fabricante, precoAquisicao, dataFabricacao);

            repositorioEquipamento.CadastrarEquipamento(novoEquipamento);

            Console.WriteLine("--------------------------------------------");            
        }
        public void EditarEquipamento()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Gestão de Equipamentos");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Editando Equipamento...");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine();

            VisualizarEquipamentos(false);

            Console.Write("Digite o ID do equipamento que deseja selecionar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o novo nome do equipamento: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a nova fabricante do equipamento: ");
            string fabricante = Console.ReadLine();

            Console.Write("Digite o novo valor de aquisição - R$: ");
            decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Digite a nova data de fabricação - (dd/MM/yyyy): ");
            DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

            Equipamento novoEquipamento = new Equipamento(nome, fabricante, precoAquisicao, dataFabricacao);

            bool conseguiuEditar = repositorioEquipamento.EditarEquipamento(idSelecionado, novoEquipamento);

            if (!conseguiuEditar)
            {
                Console.WriteLine("Não foi possível editar o item selecionado");
                return;
            }
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Equipamento editado com sucesso");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Pressione ENTER para continuar");
        }
        public void ExcluirEquipamento()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Gestão de Equipamentos");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Excluindo Equipamento...");
            Console.WriteLine("--------------------------------------------");

            VisualizarEquipamentos(false);

            Console.WriteLine("Digite o ID do registro que deseja selecionar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = repositorioEquipamento.ExcluirEquipamento(idSelecionado);

            if (!conseguiuExcluir)
            {
                Console.WriteLine("Houve um erro durante a exclusão do registro...");
                Console.WriteLine("Pressione ENTER para continuar");
                return;
            }

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Equipamento excluido com sucesso");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Pressione ENTER para continuar");

        }
        public void VisualizarEquipamentos(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                Console.Clear();
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Gestão de Equipamentos");
                Console.WriteLine("--------------------------------------------");

                Console.WriteLine("Visualizando Equipamentos...");
                Console.WriteLine("--------------------------------------------");
            }

            //Cabeçalho da Tabela
            Console.WriteLine("{0, -10} | {1, -15} | {2, -11} | {3, -20} | {4, -20} | {5, -20}","Id", "Nome", "Numero de Série", "Fabricante", "Preço", "Data de Fabricação");

            Equipamento[] equipamentosCadastrados = repositorioEquipamento.SelecionarEquipamento();

            for (int i = 0; i < equipamentosCadastrados.Length; i++)
            {
                Equipamento e = equipamentosCadastrados[i];

                if (e == null) continue;

                Console.WriteLine("{0, -10} | {1, -15} | {2, -11} | {3, -20} | {4, -20} | {5, -20}", e.Id, e.Nome, e.ObterNumeroSerie(), e.Fabricante, e.PrecoAquisicao.ToString("C2"), e.DataFabricacao.ToShortDateString());

            }

            Console.WriteLine("--------------------------------------------");            
        }
    }
}
