namespace SuperMercadoWebApplication.Features.Clientes.Interfaces
{
    public interface IClienteDomainService
    {
        // Valida el formato del RTN (Registro Tributario Nacional)
        bool ValidarRTN(string rtn);
    }
}