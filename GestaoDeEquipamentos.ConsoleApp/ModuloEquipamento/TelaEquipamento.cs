using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento
{
    class TelaEquipamento
    {
        public RepositorioEquipamento repositorioEquipamento;
        public RepositorioFabricante repositorioFabricante;
        public TelaEquipamento(RepositorioEquipamento repositorioEquipamento, RepositorioFabricante repositorioFabricante)
        {
            this.repositorioEquipamento = repositorioEquipamento;
            this.repositorioFabricante = repositorioFabricante;
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
            Console.WriteLine("3 - Excluir Equipamento");
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

            Equipamento novoEquipamento = ObterDadosEquipamento();

            Fabricante fabricante = novoEquipamento.Fabricante;

            fabricante.AdicionarEquipamento(novoEquipamento);

            repositorioEquipamento.CadastrarEquipamento(novoEquipamento);

            Console.WriteLine("--------------------------------------------");
            Notificador.ExibirMensagem("O registro foi cadastrado com sucesso!", ConsoleColor.Green);
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

            Equipamento equipamentoAntigo = repositorioEquipamento.SelecionarEquipamentoPorId(idSelecionado);
            Fabricante fabricanteAntigo = equipamentoAntigo.Fabricante;

            Console.WriteLine();

            Equipamento equipamentoEditado = ObterDadosEquipamento();

            Fabricante fabricanteEditado = equipamentoEditado.Fabricante;

            bool conseguiuEditar = repositorioEquipamento.EditarEquipamento(idSelecionado, equipamentoEditado);

            if (!conseguiuEditar)
            {
                Notificador.ExibirMensagem("Não foi possível editar o item selecionado", ConsoleColor.Red);
                
                return;
            }

            if (fabricanteAntigo != fabricanteEditado)
            {
                fabricanteAntigo.RemoverEquipamento(equipamentoAntigo);

                fabricanteEditado.AdicionarEquipamento(equipamentoEditado);
            }
            Console.WriteLine("--------------------------------------------");
            Notificador.ExibirMensagem("O registro foi cadastrado com sucesso!", ConsoleColor.Green);
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

            Console.Write("Digite o ID do registro que deseja selecionar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Equipamento equipamentoSelecionado = repositorioEquipamento.SelecionarEquipamentoPorId(idSelecionado);

            bool conseguiuExcluir = repositorioEquipamento.ExcluirEquipamento(idSelecionado);

            if (!conseguiuExcluir)
            {
                Notificador.ExibirMensagem("Houve um erro durante a exclusão do registro...", ConsoleColor.Red);                
                return;
            }

            Fabricante fabricanteSelecionado = equipamentoSelecionado.Fabricante;

            fabricanteSelecionado.RemoverEquipamento(equipamentoSelecionado);
            
            Console.WriteLine("--------------------------------------------");
            Notificador.ExibirMensagem("O registro foi excluído com sucesso!", ConsoleColor.Green);


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

                Console.WriteLine("{0, -10} | {1, -15} | {2, -11} | {3, -20} | {4, -20} | {5, -20}", e.Id, e.Nome, e.NumeroSerie, e.Fabricante.Nome, e.PrecoAquisicao.ToString("C2"), e.DataFabricacao.ToShortDateString());

            }

            Console.WriteLine("--------------------------------------------");

            Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.DarkYellow);
        }
        public void VisualizarFabricantes()
        {
            Console.WriteLine();

            Console.WriteLine("Visualizando Fabricantes...");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine();

            Console.WriteLine("{0, -6} | {1, -20} | {2, -30} | {3, -30} | {4, -20}", "Id", "Nome", "Email", "Telefone", "Qtd. Equipamentos");

            EntidadeBase[] registros = repositorioFabricante.SelecionarRegistros();
            Fabricante[] fabricantesCadastrados = new Fabricante[registros.Length];

            for (int i = 0; i < registros.Length; i++)
            {
                fabricantesCadastrados[i] = (Fabricante)registros[i];
            }

            for (int i = 0; i < fabricantesCadastrados.Length; i++)
            {
                Fabricante f = fabricantesCadastrados[i];

                if (f == null) continue;

                Console.WriteLine("{0, -6} | {1, -20} | {2, -30} | {3, -30} | {4, -20}", f.Id, f.Nome, f.Email, f.Telefone, f.QuantidadeEquipamentos);
            }

            Console.WriteLine();

            Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.DarkYellow);
        }
        public Equipamento ObterDadosEquipamento()
        {
            Console.Write("Digite o nome do equipamento: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o valor de aquisição - R$: ");
            decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Digite a data de fabricação - (dd/MM/yyyy): ");
            DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

            VisualizarFabricantes();

            Console.Write("Digite o ID do fabricante que deseja selecionar: ");
            int idFabricante = Convert.ToInt32(Console.ReadLine());

            Fabricante fabricanteSelecionado = (Fabricante)repositorioFabricante.SelecionarRegistroPorId(idFabricante);

            Equipamento equipamento = new Equipamento(nome, precoAquisicao, dataFabricacao, fabricanteSelecionado);
            return equipamento;
        }
    }
}
