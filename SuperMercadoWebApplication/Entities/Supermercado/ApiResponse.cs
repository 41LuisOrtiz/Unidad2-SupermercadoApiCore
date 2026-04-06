namespace SuperMercadoWebApplication.Entities.Supermercado
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T Data { get; set; }
    }
}
