namespace GestaoDeEquipamentos.ConsoleApp
{
    public static class GeradorIds
    {
        public static int IdEquipamentos = 0;

        public static int GerarIdEquipamento()
        {
            IdEquipamentos++;

            return IdEquipamentos;
        }

        /* Exemplo de como gear um ID baseado em GUID
         * 
         * public static Guid GerarGuidEquipamento()
        {
            return Guid.NewGuid();
        }
        */

    }
}
