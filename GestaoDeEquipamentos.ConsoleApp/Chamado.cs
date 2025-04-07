using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentos.ConsoleApp
{
    class Chamado
    {
        public int Id;
        public string TituloChamado;
        public string DescricaoChamado;
        public Equipamento EquipamentoRelacionadoChamado;
        public DateTime DataAberturaChamado;

        public Chamado(string tituloChamado, string descricaoChamado, Equipamento equipamentoRelacionadoChamado, DateTime dataAberturaChamado)
        {
            TituloChamado = tituloChamado;
            DescricaoChamado = descricaoChamado;
            EquipamentoRelacionadoChamado = equipamentoRelacionadoChamado;
            DataAberturaChamado = dataAberturaChamado;
        }

        public int DiasChamadoAberto()
        {
            return (DateTime.Now - DataAberturaChamado).Days;
        }



    }
}
