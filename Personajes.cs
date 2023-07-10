using System;
using System.IO;
namespace espacioPersonajes
{
    public class personajes{
        private datos datosPersonaje;
        private caracteristicas caracteristicasPersonaje;

        public datos DatosPersonaje { get => datosPersonaje; set => datosPersonaje = value; }
        public caracteristicas CaracteristicasPersonaje { get => caracteristicasPersonaje; set => caracteristicasPersonaje = value; }

        public void Mostrar()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("╔═════════════════════════════════════════╗");
    Console.WriteLine("║          DATOS DEL PERSONAJE            ║");
    Console.WriteLine("╚═════════════════════════════════════════╝");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine();
    Console.WriteLine($"NOMBRE: {DatosPersonaje.Nombre}");
    Console.WriteLine($"APODO: {DatosPersonaje.Apodo}");
    Console.WriteLine($"TIPO: {DatosPersonaje.TipoPersonaje}");
    Console.WriteLine($"FECHA DE NACIMIENTO: {DatosPersonaje.FechaNac}");
    Console.WriteLine($"EDAD: {DatosPersonaje.Edad}");
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("╔═════════════════════════════════════════╗");
    Console.WriteLine("║        CARACTERÍSTICAS DEL PERSONAJE    ║");
    Console.WriteLine("╚═════════════════════════════════════════╝");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine();
    Console.WriteLine($"    velocidad: {CaracteristicasPersonaje.Velocidad}");
    Console.WriteLine($"    destreza: {CaracteristicasPersonaje.Destreza}");
    Console.WriteLine($"    fuerza: {CaracteristicasPersonaje.Fuerza}");
    Console.WriteLine($"    nivel: {CaracteristicasPersonaje.Nivel}");
    Console.WriteLine($"    armadura: {CaracteristicasPersonaje.Armadura}");
    Console.WriteLine($"    salud: {CaracteristicasPersonaje.Salud}");
}
    }
    
}