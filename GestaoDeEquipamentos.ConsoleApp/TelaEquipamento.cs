namespace GestaoDeEquipamentos.ConsoleApp
{
    class TelaEquipamento
    {
        public Equipamento[] equipamentos = new Equipamento[100];
        public int contadorEquipamentos = 0;
        public string ApresentarMenu()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Gestão de Equipamentos");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Escolha a operação desejada: ");
            Console.WriteLine("1 - Cadastro de Equipamento");
            Console.WriteLine("2 - Editar Equipamento");
            Console.WriteLine("3 - Excluir Equipamento");
            Console.WriteLine("4 - Visualização dos Equipamentos Cadastrados");
            Console.WriteLine("--------------------------------------------");

            Console.Write("Digite a opção desejada: ");
            string opcaoEscolhida = Console.ReadLine();

            return opcaoEscolhida;
        }
        public void CadastrarEquipamento()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Gestão de Equipamentos");
            Console.WriteLine("--------------------------------------------");

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
            novoEquipamento.Id = GeradorIds.GerarIdEquipamento();

            equipamentos[contadorEquipamentos++] = novoEquipamento;

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Pressione ENTER para continuar");
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

            bool conseguiuEditar = false;

            for (int i = 0; i < equipamentos.Length; i++)
            {
                if (equipamentos[i] == null) continue;

                else if (equipamentos[i].Id == idSelecionado)
                {
                    equipamentos[i].Nome = novoEquipamento.Nome;
                    equipamentos[i].Fabricante = novoEquipamento.Fabricante;
                    equipamentos[i].PrecoAquisicao = novoEquipamento.PrecoAquisicao;
                    equipamentos[i].DataFabricacao = novoEquipamento.DataFabricacao;

                    conseguiuEditar = true;

                }
            }

            if (!conseguiuEditar)
            {
                Console.WriteLine("Não foi possível editar o item selecionado");
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

            bool conseguiuExcluir = false;

            for (int i = 0; i < equipamentos.Length; i++)
            {
                if (equipamentos[i] == null) continue;

                else if (equipamentos[i].Id == idSelecionado)
                {
                    equipamentos[i] = null;
                    conseguiuExcluir |= true;
                }
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

            for (int i = 0; i < equipamentos.Length; i++)
            {
                Equipamento e = equipamentos[i];

                if (e == null) continue;

                Console.WriteLine("{0, -10} | {1, -15} | {2, -11} | {3, -20} | {4, -20} | {5, -20}", e.Id, e.Nome, e.ObterNumeroSerie(), e.Fabricante, e.PrecoAquisicao.ToString("C2"), e.DataFabricacao.ToShortDateString());

            }

            Console.WriteLine("--------------------------------------------");            
        }
    }
}
