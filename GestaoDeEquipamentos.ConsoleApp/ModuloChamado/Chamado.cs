﻿using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado
{
    public class Chamado : EntidadeBase
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Equipamento Equipamento { get; set; }
        public DateTime DataAbertura { get; set; }
        public int TempoDecorrido
        {
            get
            {
                TimeSpan diferencaTempo = DateTime.Now.Subtract(DataAbertura);
                return diferencaTempo.Days;
            }


        }
        public Chamado(string titulo, string descricao, Equipamento equipamento)
        {
            Titulo = titulo;
            Descricao = descricao;
            Equipamento = equipamento;
            DataAbertura = DateTime.Now;
        }

        public override void AtualizarRegistro(EntidadeBase registroAtualizado)
        {
            Chamado chamadoAtualizado = (Chamado)registroAtualizado;

            Titulo = chamadoAtualizado.Titulo;
            Descricao = chamadoAtualizado.Descricao;
            Equipamento = chamadoAtualizado.Equipamento;
        }

        public override string Validar()
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(Titulo))
                erros += "O campo 'Título' é obrigatório.\n";

            if (Titulo.Length < 3)
                erros += "O campo 'Titulo' precisa conter ao menos 3 caracteres.\n";

            if (string.IsNullOrWhiteSpace(Descricao))
                erros += "O campo 'Descrição' é obrigatório. \n";

            if (Equipamento == null)
                erros += "O campo 'Data da Fabricação' é obrigatório. \n";

            return erros;
        }



    }
}
