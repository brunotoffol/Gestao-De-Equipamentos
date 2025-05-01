using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using System.Collections;
using System.Collections.Generic;


namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado
{

    public abstract class RepositorioBase<T> where T : EntidadeBase<T>
    {
        private List<T> registros = new List<T>();
        private int contadorIds = 0;

        public void CadastrarRegistro(T novoRegistro)
        {
            novoRegistro.Id = ++contadorIds;

            registros.Add(novoRegistro);
        }
        public bool EditarRegistro(int idRegistro, T registroEditado)
        {
            foreach (T item in registros)
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
            T registroSelecionado = SelecionarRegistroPorId(IdRegistro);

            if(registroSelecionado != null)
            {
                registros.Remove(registroSelecionado);
                return true;
            }           
            
            return false;
        }
        public List<T> SelecionarRegistros()
        {
            return registros;
        }
        public T SelecionarRegistroPorId(int IdRegistro)
        {
            foreach (T item in registros)
            {
               if (item.Id == IdRegistro)
                    return item;
            }           
            return null;
        }        
    }
}
