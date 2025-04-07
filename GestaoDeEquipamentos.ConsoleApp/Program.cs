using GestaoDeEquipamentos.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        TelaEquipamento telaEquipamento = new TelaEquipamento();
        TelaChamados telaChamados = new TelaChamados(telaEquipamento);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Sistema de Gestão");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("1 - Gestão de Equipamentos");
            Console.WriteLine("2 - Controle de Chamados");
            Console.WriteLine("3 - Sair");
            Console.WriteLine("--------------------------------------------");
            Console.Write("Digite a opção desejada: ");
            string opcaoPrincipal = Console.ReadLine();

            if (opcaoPrincipal == "1")
            {
                string opcaoEquipamento = telaEquipamento.ApresentarMenu();

                switch (opcaoEquipamento)
                {
                    case "1":
                        telaEquipamento.CadastrarEquipamento();
                        break;
                    case "2":
                        telaEquipamento.EditarEquipamento();
                        break;
                    case "3":
                        telaEquipamento.ExcluirEquipamento();
                        break;
                    case "4":
                        telaEquipamento.VisualizarEquipamentos(true);
                        break;
                }

                Console.ReadLine();
            }
            else if (opcaoPrincipal == "2")
            {
                Console.Clear();
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Controle de Chamados");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("1 - Cadastrar Chamado");
                Console.WriteLine("2 - Visualizar Chamados");
                Console.WriteLine("3 - Editar Chamados");
                Console.WriteLine("--------------------------------------------");
                Console.Write("Digite a opção desejada: ");
                string opcaoChamado = Console.ReadLine();

                switch (opcaoChamado)
                {
                    case "1":
                        telaChamados.CadastrarChamado();
                        break;
                    case "2":
                        telaChamados.VisualizarChamados();
                        break;
                    case "3":
                        telaChamados.EditarChamado();
                        break;
                }

                Console.ReadLine();
            }
            else if (opcaoPrincipal == "3")
            {
                Console.WriteLine("Encerrando o programa...");
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida. Pressione ENTER para tentar novamente.");
                Console.ReadLine();
            }
        }
    }
}
