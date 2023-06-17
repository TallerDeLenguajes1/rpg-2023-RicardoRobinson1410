using System;
using System.IO;
namespace espacioPersonajes{
public class FabricaDePersonajes{
string[] nombresLuchadores=
{
    "John Cena",
    "The Rock",
    "Stone Cold Steve Austin",
    "Hulk Hogan",
    "Bret Hart",
    "The Undertaker",
    "Rey Mysterio",
    "Triple H",
    "Randy Orton",
    "Roman Reigns"
};
private static string[] apodosLuchadores = 
{
    "Stone Cold",
    "La Roca",
    "The Undertaker",
    "Hulk Hogan",
    "Macho Man",
    "Nature Boy",
    "The Ultimate Warrior",
    "Rowdy Roddy Piper",
    "Bret 'The Hitman' Hart",
    "The magician boy"
};
DateTime[] fechasNacimiento =
{
    new DateTime(1977, 4, 23),    // John Cena
    new DateTime(1972, 5, 2),     // The Rock
    new DateTime(1964, 12, 18),   // Stone Cold Steve Austin
    new DateTime(1953, 8, 11),    // Hulk Hogan
    new DateTime(1957, 7, 2),     // Bret Hart
    new DateTime(1965, 3, 24),    // The Undertaker
    new DateTime(1974, 12, 11),   // Rey Mysterio
    new DateTime(1969, 7, 27),    // Triple H
    new DateTime(1980, 4, 1),     // Randy Orton
    new DateTime(1985, 5, 25)     // Roman Reigns
};

    public personajes CrearPersonaje(){
        datos DatosPersonaje = new datos();
        var CaracteristicasPersonaje = new caracteristicas();
        personajes personaje=new personajes();
        Random indicerandom=new Random();
        int i=indicerandom.Next(0,9);
        DatosPersonaje.Nombre=nombresLuchadores[i];
        DatosPersonaje.Apodo=apodosLuchadores[i];
        DatosPersonaje.FechaNac=fechasNacimiento[i];
        // Console.WriteLine("Ingrese el tipo de personaje (El personaje tendrá 10 puntos en la habilidad que predomine, en las otras sera aleatorio)");
        // Console.WriteLine("1. Veloz");
        // Console.WriteLine("2. Fuerte");
        // Console.WriteLine("3. Habil");
        // Console.WriteLine("4. Resistente");
        // string? a=Console.ReadLine();
        // Tipopersonjes tip;
        // bool anda1=Enum.TryParse(a, out tip);
        // if(anda1){
        //     Console.WriteLine("Ingreso existoso enum");
        // }else{
        //     Console.WriteLine("Error enum");
        // }
            Random rand = new Random();
            Tipopersonjes tip = (Tipopersonjes)rand.Next(1,4);
        DatosPersonaje.TipoPersonaje=tip;
        DatosPersonaje.Edad=CalcularEdad(DatosPersonaje.FechaNac);
        switch (DatosPersonaje.TipoPersonaje)
        {
            case Tipopersonjes.veloz: 
                CaracteristicasPersonaje.Velocidad=10;
                CaracteristicasPersonaje.Destreza=indicerandom.Next(1,5);
                CaracteristicasPersonaje.Fuerza=indicerandom.Next(1,10);
                CaracteristicasPersonaje.Nivel=indicerandom.Next(1,10);
                CaracteristicasPersonaje.Armadura=indicerandom.Next(1,10);
                break;
            case Tipopersonjes.habil: 
                CaracteristicasPersonaje.Velocidad=indicerandom.Next(1,10);
                CaracteristicasPersonaje.Destreza=5;
                CaracteristicasPersonaje.Fuerza=indicerandom.Next(1,10);
                CaracteristicasPersonaje.Nivel=indicerandom.Next(1,10);
                CaracteristicasPersonaje.Armadura=indicerandom.Next(1,10);
                break;
            case Tipopersonjes.fuerte:
                CaracteristicasPersonaje.Velocidad=indicerandom.Next(1,10);
                CaracteristicasPersonaje.Destreza=indicerandom.Next(1,5);
                CaracteristicasPersonaje.Fuerza=10;
                CaracteristicasPersonaje.Nivel=indicerandom.Next(1,10);
                CaracteristicasPersonaje.Armadura=indicerandom.Next(1,10);
                break;
            case Tipopersonjes.resistente:
                CaracteristicasPersonaje.Velocidad=indicerandom.Next(1,10);
                CaracteristicasPersonaje.Destreza=indicerandom.Next(1,5);
                CaracteristicasPersonaje.Fuerza=indicerandom.Next(1,10);
                CaracteristicasPersonaje.Nivel=indicerandom.Next(1,10);
                CaracteristicasPersonaje.Armadura=10;
                break;            
        }
        CaracteristicasPersonaje.Nivel=indicerandom.Next(1,10);
        CaracteristicasPersonaje.Salud=100;
        personaje.CaracteristicasPersonaje = new caracteristicas();
        personaje.DatosPersonaje = new datos();
        personaje.CaracteristicasPersonaje=CaracteristicasPersonaje;
        personaje.DatosPersonaje=DatosPersonaje;

        return(personaje);
    }

        private int CalcularEdad(DateTime fechanac)
        {
            DateTime fechaHoy = DateTime.Now;
            int aniohoy = fechaHoy.Year;
            int anionac=fechanac.Year ;
            return (aniohoy - anionac);
        }
    }
}
