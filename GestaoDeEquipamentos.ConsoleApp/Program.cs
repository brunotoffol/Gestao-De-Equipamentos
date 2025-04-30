using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using GestaoDeEquipamentos.ConsoleApp.Util;

namespace GestaoDeEquipamentos.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TelaPrincipal telaPrincipal = new TelaPrincipal();

            while (true)
            {
                telaPrincipal.ApresentarMenuPrincipal();

                TelaBase telaSelecionada = telaPrincipal.ObterTela();

                char opcaoEscolhida = telaSelecionada.ApresentarMenu();

                if (telaSelecionada is TelaChamado)
                {
                    TelaChamado telaChamado = (TelaChamado)telaSelecionada;
                    if (opcaoEscolhida == '5')
                    {
                        telaChamado.VisualizarChamadosEmAberto();
                    }
                }

                switch (opcaoEscolhida)
                {
                    case '1': telaSelecionada.CadastrarRegistro(); break;

                    case '2': telaSelecionada.EditarRegistro(); break;

                    case '3': telaSelecionada.ExcluirRegistro(); break;

                    case '4': telaSelecionada.VisualizarRegistros(true); break;

                    default: break;
                }
            }

        }
    }
}
