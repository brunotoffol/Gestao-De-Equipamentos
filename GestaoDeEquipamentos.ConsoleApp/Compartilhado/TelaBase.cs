using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using GestaoDeEquipamentos.ConsoleApp.Util;

namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado;

public abstract class TelaBase
{

    protected string nomeEntidade;

    protected TelaBase(string nomeEntidade)
    {
        this.nomeEntidade = nomeEntidade;
    }

    public void CadastrarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine($"Cadastrando {nomeEntidade}...");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        EntidadeBase novoRegistro = ObterDados();

        string erros = novoRegistro.Validar();

        if (erros.Length > 0)
        {
            Notificador.ExibirMensagem(erros, ConsoleColor.Red);

            CadastrarRegistro();

            return;
        }

        //repositorioFabricante.CadastrarRegistro(novoRegistro);

        Notificador.ExibirMensagem("O registro foi concluído com sucesso!", ConsoleColor.Green);
    }
    public void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine($"|          Controle de {nomeEntidade}s    |");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();
    }
    public virtual char ApresentarMenu()
    {
        ExibirCabecalho();

        Console.WriteLine($"1 - Cadastrar {nomeEntidade} ");
        Console.WriteLine($"2 - Editar {nomeEntidade} ");
        Console.WriteLine($"3 - Excluir {nomeEntidade} ");
        Console.WriteLine($"4 - Visualizar {nomeEntidade} ");
        Console.WriteLine("S - Voltar");
        Console.WriteLine("--------------------------------------------");
        Console.Write("Escolha uma das opções: ");
        char operacaoEscolhida = Console.ReadLine()![0];
        return operacaoEscolhida;
    }

    public abstract EntidadeBase ObterDados();

}
