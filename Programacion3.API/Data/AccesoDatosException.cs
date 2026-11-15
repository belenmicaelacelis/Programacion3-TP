namespace Programacion3.API.Data;

public class AccesoDatosException : Exception
{
    public AccesoDatosException(string mensaje, Exception innerException)
        : base(mensaje, innerException)
    {
    }
}