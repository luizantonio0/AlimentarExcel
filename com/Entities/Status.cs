namespace com.Entities
{
    public enum Status
    {
        Liberado_Manual,
        Liberado,
        ERRO
    }
    public static class StatusExtensions
    {
        public static string ToCustomString(this Status status)
        {
            return status.ToString().Replace("_", " ");
        }
    }
}