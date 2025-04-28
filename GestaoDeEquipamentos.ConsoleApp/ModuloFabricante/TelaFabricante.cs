using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.Util;
using System.ComponentModel.DataAnnotations;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante
{
    public class TelaFabricante : TelaBase
    {
        public RepositorioFabricante repositorioFabricante;
        public TelaFabricante(RepositorioFabricante repositorioFabricante) : base("Fabricante")
        {
            this.repositorioFabricante = repositorioFabricante;
        }
        public void CadastrarFabricante()
        {
            ExibirCabecalho();

            Console.WriteLine();

            Console.WriteLine($"Cadastrando {nomeEntidade}...");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine();

            Fabricante novoFabricante = (Fabricante)ObterDados();

            string erros = novoFabricante.Validar();

            if (erros.Length > 0)
            {
                Notificador.ExibirMensagem(erros, ConsoleColor.Red);

                CadastrarFabricante();

                return;
            }

            repositorioFabricante.CadastrarRegistro(novoFabricante);

            Notificador.ExibirMensagem("O registro foi concluído com sucesso!", ConsoleColor.Green);
        }
        public void EditarFabricante()
        {
            ExibirCabecalho();

            Console.WriteLine("Editando Fabricante...");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine();

            VisualizarFabricantes(false);

            Console.Write("Digite o ID do registro que deseja selecionar: ");
            int idFabricante = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Fabricante fabricanteEditado = (Fabricante)ObterDados();

            bool conseguiuEditar = repositorioFabricante.EditarRegistro(idFabricante, fabricanteEditado);

            if (!conseguiuEditar)
            {
                Notificador.ExibirMensagem("Houve um erro durante a edição do registro...", ConsoleColor.Red);

                return;
            }

            Notificador.ExibirMensagem("O registro foi editado com sucesso!", ConsoleColor.Green);
        }
        public void ExcluirFabricante()
        {
            ExibirCabecalho();

            Console.WriteLine("Excluindo Fabricante...");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine();

            VisualizarFabricantes(false);

            Console.Write("Digite o ID do registro que deseja selecionar: ");
            int idFabricante = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            bool conseguiuExcluir = repositorioFabricante.ExcluirRegistro(idFabricante);

            if (!conseguiuExcluir)
            {
                Notificador.ExibirMensagem("Houve um erro durante a exclusão do registro...", ConsoleColor.Red);
                return;
            }

            Notificador.ExibirMensagem("O registro foi excluído com sucesso!", ConsoleColor.Green);
        }
        public void VisualizarFabricantes(bool exibirTitulo)
        {
            if (exibirTitulo)
                ExibirCabecalho();

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
        public override EntidadeBase ObterDados()
        {
            Console.Write("Digite o nome do fabricante: ");
            string nome = Console.ReadLine()!.Trim();

            Console.Write("Digite o endereço de email do fabricante: ");
            string email = Console.ReadLine()!.Trim();

            Console.Write("Digite o telefone do fabricante: ");
            string telefone = Console.ReadLine()!.Trim();

            Fabricante fabricante = new Fabricante(nome, email, telefone);

            return fabricante;
        }       
    }
}

