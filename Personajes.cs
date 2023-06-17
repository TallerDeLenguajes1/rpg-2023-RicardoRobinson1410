using System;
using System.IO;
namespace espacioPersonajes
{
    public class personajes{
        private datos datosPersonaje;
        private caracteristicas caracteristicasPersonaje;

        public datos DatosPersonaje { get => datosPersonaje; set => datosPersonaje = value; }
        public caracteristicas CaracteristicasPersonaje { get => caracteristicasPersonaje; set => caracteristicasPersonaje = value; }

        public void Mostrar(){
            Console.WriteLine($"NOMBRE: {DatosPersonaje.Nombre}");
            Console.WriteLine($"APODO: {DatosPersonaje.Apodo}");
            Console.WriteLine($"TIPO: {DatosPersonaje.TipoPersonaje}");
            Console.WriteLine($"FECHA DE NACIMIENTO: {DatosPersonaje.FechaNac}");
            Console.WriteLine($"EDAD: {DatosPersonaje.Edad}");
            Console.WriteLine("CARACTERISTICAS");
            Console.WriteLine($"    velocidad: {CaracteristicasPersonaje.Velocidad} ");
            Console.WriteLine($"    destreza: {CaracteristicasPersonaje.Destreza} ");
            Console.WriteLine($"    fuerza: {CaracteristicasPersonaje.Fuerza} ");
            Console.WriteLine($"    nivel: {CaracteristicasPersonaje.Nivel} ");
            Console.WriteLine($"    armadura: {CaracteristicasPersonaje.Armadura} ");
            Console.WriteLine($"    salud: {CaracteristicasPersonaje.Salud} ");
        }
    }
    
}