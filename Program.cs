using System;
using System.IO;
using espacioPersonajes;
using persistenciaDeDatos;
using System.Collections.Generic;
internal class Program
{
    private static void Main(string[] args)
    {
        var manejoArchivos = new personajesJson();
        string ruta = "ArchivoGuardar.json";
        List<personajes> personajeCreado = new List<personajes>();
        if (manejoArchivos.Existe(ruta))
        {
            personajeCreado = manejoArchivos.LeerPersonajes(ruta);
            Console.WriteLine("===============LISTA PERSONAJES===================\n");
            foreach (var item in personajeCreado)
            {
                item.Mostrar();
            }
        }
        else
        {
            var personajeFabrica = new FabricaDePersonajes();
            personajes personajeCrear = new personajes();
            for (int i = 0; i < 10; i++)
            {
                personajeCrear = personajeFabrica.CrearPersonaje();
                personajeCreado.Add(personajeCrear);
            }
            manejoArchivos.GuardarPersonajes(ruta, personajeCreado);
        }
        Console.WriteLine("\n\n El juego consiste en que usted elegirá un personaje aleaoriamente, e irá peleando contra sus adversarios hasta acabar con todos. Si su salud disminuye a 0 pierde, y si la del oponente alcanza 0, gana y pasa a la siguiente ronda. Usted primero atacará y luego defenderá. En sus turnos de ataque puede elegir atacar o tomar una bebida energética para recuperar un valor aleatorio de salud entre 0 y 30. El juego termina cuando es derrotado o elimina a los 9 oponentes restantes");
        Console.WriteLine("\n\n==============PERSONAJE ELEGIDO================");
        var rand = new Random();
        var personaje1 = new personajes();
        personaje1 = personajeCreado[rand.Next(0, 9)];
        personajeCreado.Remove(personaje1);
        personaje1.Mostrar();

        while (personajeCreado.Count()!=0 && personaje1.CaracteristicasPersonaje.Salud >= 0)
        {
            var rival = new personajes();
            rival = personajeCreado[rand.Next(0, (personajeCreado.Count()-1))];
            Console.WriteLine("\n\n---------RIVAL-----------");
            rival.Mostrar();
            while (personaje1.CaracteristicasPersonaje.Salud >= 0 && rival.CaracteristicasPersonaje.Salud >= 0)
            {
                Console.WriteLine("------------Su turno-------------");
                Ataque(personaje1,rival);
                Console.WriteLine($"Su salud:{personaje1.CaracteristicasPersonaje.Salud}");
                Console.WriteLine($"Salud de {rival.DatosPersonaje.Nombre}: {rival.CaracteristicasPersonaje.Salud}");
                if(rival.CaracteristicasPersonaje.Salud>=0){
                    Console.WriteLine("------------TURNO DEL RIVAL------------\n");
                    AtaqueRival(rival,personaje1);
                }
                Console.WriteLine($"Su salud:{personaje1.CaracteristicasPersonaje.Salud}");
                Console.WriteLine($"Salud de {rival.DatosPersonaje.Nombre}: {rival.CaracteristicasPersonaje.Salud}");
            }
            personajeCreado.Remove(rival);
        }
        if(personaje1.CaracteristicasPersonaje.Salud>=0){
            Console.WriteLine("\tFELICIDADES!!!Es el ganador!!");
            personaje1.Mostrar();
        }else{
            Console.WriteLine("Perdio la partida, juegue nuevamente");
        }
}
public static void Ataque(personajes personajeAtaca, personajes personajeDefiende)
        {
            int ataque;
            int defensa;
            int efectividad;
            int constanteDeAjuste = 500;
            int ingresar;
            var rand = new Random();
            int danioProvocado;
            Console.WriteLine("Ingrese '1' si desea atacar y '2' si desea tomar una bebida energética para recuperar vida");
            string? a = Console.ReadLine();
            bool anda1 = int.TryParse(a, out ingresar);
            if (anda1)
            {
                Console.WriteLine("Ingreso exitoso");
            }
            if (ingresar == 1)
            {
                ataque = personajeAtaca.CaracteristicasPersonaje.Destreza * personajeAtaca.CaracteristicasPersonaje.Fuerza * personajeAtaca.CaracteristicasPersonaje.Nivel;
                efectividad = rand.Next(1, 100);
                defensa = personajeDefiende.CaracteristicasPersonaje.Armadura * personajeDefiende.CaracteristicasPersonaje.Velocidad;
                danioProvocado = (ataque * efectividad - defensa) / constanteDeAjuste;
                personajeDefiende.CaracteristicasPersonaje.Salud -= danioProvocado;
            }
            else
            {
                personajeAtaca.CaracteristicasPersonaje.Salud += rand.Next(0, 50);
        }
    }
    public static void AtaqueRival(personajes personajeAtaca, personajes personajeDefiende)
        {
            int ataque;
            int defensa;
            int efectividad;
            int constanteDeAjuste = 500;
            var rand = new Random();
            int danioProvocado;
                ataque = personajeAtaca.CaracteristicasPersonaje.Destreza * personajeAtaca.CaracteristicasPersonaje.Fuerza * personajeAtaca.CaracteristicasPersonaje.Nivel;
                efectividad = rand.Next(1, 100);
                defensa = personajeDefiende.CaracteristicasPersonaje.Armadura * personajeDefiende.CaracteristicasPersonaje.Velocidad;
                danioProvocado = (ataque * efectividad - defensa) / constanteDeAjuste;
                personajeDefiende.CaracteristicasPersonaje.Salud -= danioProvocado;
}
}
