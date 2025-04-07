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

    }
}
