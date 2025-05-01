using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using System.Collections;


namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado
{

    public abstract class RepositorioBase
    {
        private ArrayList registros = new ArrayList();
        private int contadorIds = 0;

        public void CadastrarRegistro(EntidadeBase novoRegistro)
        {
            novoRegistro.Id = ++contadorIds;

            registros.Add(novoRegistro);
        }
        public bool EditarRegistro(int idRegistro, EntidadeBase registroEditado)
        {
            foreach (EntidadeBase item in registros)
            {
                if (item.Id == idRegistro)
                {
                    item.AtualizarRegistro(registroEditado);

                    return true;
                }
            }         
                      
            return false;
        }
        public bool ExcluirRegistro(int IdRegistro)
        {
            EntidadeBase registroSelecionado = SelecionarRegistroPorId(IdRegistro);

            if(registroSelecionado != null)
            {
                registros.Remove(registroSelecionado);
                return true;
            }
            
            #region exemplo iteração com cor
            //for (int i = 0;i < registros.Count; i++)
            //{
            //    EntidadeBase registroSelecionado = (EntidadeBase) registros[i]!;
                
            //    if (registroSelecionado == null)
            //        continue;

            //    else if (registroSelecionado.Id == IdRegistro)
            //    {
            //       registros.Remove(registroSelecionado);
            //       return true;
            //   }             
            //}
            #endregion
            return false;
        }
        public ArrayList SelecionarRegistros()
        {
            return registros;
        }
        public EntidadeBase SelecionarRegistroPorId(int IdRegistro)
        {
            foreach (EntidadeBase item in registros)
            {
               if (item.Id == IdRegistro)
                    return item;
            }           
            return null;
        }        
    }
}
