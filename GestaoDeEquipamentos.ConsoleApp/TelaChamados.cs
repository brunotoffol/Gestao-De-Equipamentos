namespace GestaoDeEquipamentos.ConsoleApp
{
    class TelaChamados
    {
        public Chamado[] chamados = new Chamado[100];
        public int contadorChamados = 0;

        private TelaEquipamento telaEquipamento;
        public TelaChamados(TelaEquipamento telaEquipamento)
        {
            this.telaEquipamento = telaEquipamento;
        }
        public void CadastrarChamado()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Cadastro de Chamado");
            Console.WriteLine("--------------------------------------------");

            // Exibe os equipamentos disponíveis
            telaEquipamento.VisualizarEquipamentos(true);

            Console.Write("Digite o ID do equipamento relacionado: ");
            int idEquipamento = Convert.ToInt32(Console.ReadLine());

            Equipamento equipamentoRelacionadoChamado = null;

            foreach (Equipamento equipamento in telaEquipamento.equipamentos)
            {
                if (equipamento != null && equipamento.Id == idEquipamento)
                {
                    equipamentoRelacionadoChamado = equipamento;
                    break;
                }
            }

            if (equipamentoRelacionadoChamado == null)
            {
                Console.WriteLine("Equipamento não encontrado.");
                Console.ReadLine();
                return;
            }

            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Cadastro de Chamado");
            Console.WriteLine("--------------------------------------------");

            Console.Write("Digite o título do chamado: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a descrição do chamado: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite a data de abertura (dd/MM/yyyy): ");
            DateTime dataAberturaChamado = Convert.ToDateTime(Console.ReadLine());

            Chamado novoChamado = new Chamado(titulo, descricao, equipamentoRelacionadoChamado, dataAberturaChamado);
            novoChamado.Id = GeradorIds.GerarIdChamado();

            chamados[contadorChamados++] = novoChamado;

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Chamado cadastrado com sucesso!");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
        public void VisualizarChamados()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Lista de Chamados");
            Console.WriteLine("--------------------------------------------");

            // Cabeçalho da Tabela
            Console.WriteLine("{0, -5} | {1, -20} | {2, -20} | {3, -30} | {4, -15} | {5, -15}",
                "ID", "Título", "Equipamento", "Descrição", "Data Abertura", "Dias em Aberto");

            for (int i = 0; i < chamados.Length; i++)
            {
                Chamado chamado = chamados[i];
                if (chamado == null) continue;

                
                Console.WriteLine("{0, -5} | {1, -20} | {2, -20} | {3, -30} | {4, -15} | {5, -15}",
                    chamado.Id,
                    chamado.TituloChamado,
                    chamado.EquipamentoRelacionadoChamado.Nome,
                    chamado.DescricaoChamado,
                    chamado.DataAberturaChamado.ToShortDateString(),
                    chamado.DiasChamadoAberto());
            }

            Console.WriteLine("--------------------------------------------");            
            Console.ReadLine();
        }
        public void EditarChamado()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Editar Chamado");
            Console.WriteLine("--------------------------------------------");

            VisualizarChamados();

            Console.Write("Digite o ID do chamado que deseja editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Chamado chamadoParaEditar = null;
            
            for (int i = 0; i < chamados.Length; i++)
            {
                if (chamados[i] != null && chamados[i].Id == idSelecionado)
                {
                    chamadoParaEditar = chamados[i];
                    break;
                }
            }
            if (chamadoParaEditar == null)
            {
                Console.WriteLine("Chamado não encontrado!");
                Console.ReadLine();
                return;
            }

            Console.Write("Digite o novo título para o chamado: ");
            string novoTitulo = Console.ReadLine();

            Console.Write("Digite a nova descrição para o chamado: ");
            string novaDescricao = Console.ReadLine();

            Console.WriteLine("Escolha o novo equipamento relacionado ao chamado:");
            telaEquipamento.VisualizarEquipamentos(false);

            Console.Write("Digite o ID do equipamento: ");
            int novoIdEquipamento = Convert.ToInt32(Console.ReadLine());

            Equipamento novoEquipamento = null;

            foreach (var e in telaEquipamento.equipamentos)
            {
                if (e != null && e.Id == novoIdEquipamento)
                {
                    novoEquipamento = e;
                    break;
                }
            }

            if (novoEquipamento == null)
            {
                Console.WriteLine("Equipamento não encontrado!");
                Console.ReadLine();
                return;
            }

            chamadoParaEditar.TituloChamado = novoTitulo;
            chamadoParaEditar.DescricaoChamado = novaDescricao;
            chamadoParaEditar.EquipamentoRelacionadoChamado = novoEquipamento;

            Console.WriteLine("Chamado editado com sucesso!");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Pressione ENTER para voltar ao menu.");
            Console.ReadLine();
        }

        public void ExcluirChamado()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Excluir Chamado");
            Console.WriteLine("--------------------------------------------");

            VisualizarChamados();

            Console.Write("Digite o ID do chamado que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = false;

            for (int i = 0; i < chamados.Length; i++)
            {
                if (chamados[i] != null && chamados[i].Id == idSelecionado)
                {
                    chamados[i] = null;
                    conseguiuExcluir = true;
                    break;
                }
            }

            if (conseguiuExcluir)
            {
                Console.WriteLine("Chamado excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("Chamado não encontrado.");
            }

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Pressione ENTER para voltar ao menu.");
            Console.ReadLine();
        }

    }
}

