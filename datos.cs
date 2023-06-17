using System;
using System.IO;
namespace espacioPersonajes{
public enum Tipopersonjes{
    veloz=1,
    fuerte=2,
    habil=3,
    resistente=4
}
public class datos{
    private Tipopersonjes tipopersonje;
    private string nombre;
    private string apodo;
    private DateTime fechaNac;
    private int edad;
    public Tipopersonjes TipoPersonaje { get => tipopersonje; set => tipopersonje = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Apodo { get => apodo; set => apodo = value; }
    public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
    public int Edad { get => edad; set => edad = value; }

}
}
