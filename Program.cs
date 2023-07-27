using System;
using System.IO;
using espacioPersonajes;
using persistenciaDeDatos;
using espacioMostrar;
using System.Collections.Generic;
internal class Program
{
    private static void Main(string[] args)
    {
        var Show = new Mostrar();
        //Creacion y cargado lista personajes
        var manejoArchivos = new personajesJson();
        string ruta = "ArchivoGuardar.json";
        List<personajes> personajeCreado = new List<personajes>();
        // Si ya existe el archivo y no esta vacio GuardarJson, se leen los personajes y se los muestra
        if (manejoArchivos.Existe(ruta))
        {
            personajeCreado = manejoArchivos.LeerPersonajes(ruta);
            Console.WriteLine("===============LISTA PERSONAJES===================\n");
            var contador = 1;
            foreach (var item in personajeCreado)
            {
                Console.WriteLine($"{contador}.{item.DatosPersonaje.Nombre}");
                contador += 1;
            }
        }
        //Si no existe el archivo o esta vacio se crea la lista de personajes y se la guarda en el archivo Json
        else
        {
            var personajeFabrica = new FabricaDePersonajes();
            personajes personajeCrear = new personajes();
            for (int i = 0; i < 10; i++)
            {
                personajeCrear = personajeFabrica.CrearPersonaje(i);
                personajeCreado.Add(personajeCrear);
            }
            manejoArchivos.GuardarPersonajes(ruta, personajeCreado);
        }

        Show.CondicionInicial();
        //Se elige un personaje aleatorio de la lista de personajes. Luego, se lo removerá de la lista para que no haya personajes repetidos
        var rand = new Random();
        var personaje1 = new personajes();
        personaje1 = personajeCreado[rand.Next(0, 9)];
        personajeCreado.Remove(personaje1);
        Show.MostrarMiPersonaje(personaje1);
        var clima = manejoArchivos.GetClimas();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(@"
____    __    ______           ______     
/\  _`\ /\ \  /\__  _\  /'\_/`\/\  _  \    
\ \ \/\_\ \ \ \/_/\ \/ /\      \ \ \L\ \   
 \ \ \/_/\ \ \  _\ \ \ \ \ \__\ \ \  __ \  
  \ \ \L\ \ \ \L\ \_\ \_\ \ \_/\ \ \ \/\ \ 
   \ \____/\ \____/\_____\ \_\\ \_\ \_\ \_\
    \/___/  \/___/\/_____/\/_/ \/_/\/_/\/_/");
        //Se muestra el clima que sacamos de la APPI, y según haya sol, nieve, lluvia o nubes se muestra un dibujo de ello
        //Para cada tipo de clima, la salud inicial con la que empieza el personaje en la primera ronda será distinta
        ModificarSaludPorClima(personaje1, clima);
        Show.MostrarClima(clima);
        int ronda = 1;
        //Establezco una condición en el while para que itere mientras la lista de personajes no este vacía y la salud del personaje sera >=0
        while (personajeCreado.Count() != 0 && personaje1.CaracteristicasPersonaje.Salud >= 0)
        {
            //Elijo un rival de manera aleatoria de la lista
            var rival = new personajes();
            rival = personajeCreado[rand.Next(0, (personajeCreado.Count() - 1))];
            Show.MostrarComienzoBatalla(ronda);
            //Establezco la condición de iteración para una batalla, pues la salud de ambos personajes debe ser >=0
            while (personaje1.CaracteristicasPersonaje.Salud >= 0 && rival.CaracteristicasPersonaje.Salud >= 0)
            {
                // Desarrollo de la batalla, un turno cada uno. Nuestro personaje puede elegir entre atacar o recuperar vida. El rival solo ataca
                Console.ForegroundColor = ConsoleColor.White;
                Ataque(personaje1, rival);
                Show.MostrarMiturno(personaje1,rival);
                if (rival.CaracteristicasPersonaje.Salud >= 0)
                {
                    AtaqueRival(rival, personaje1);
                    Show.MostrarTurnoRival(personaje1,rival);
                }
        
            }
            //Al terminar el enfrentamiento, se remueve al rival de la lista y se le aumenta un un nivel a nuestro personaje
            ronda += 1;
            personajeCreado.Remove(rival);
            personaje1.CaracteristicasPersonaje.Nivel += 1;
            if (personaje1.CaracteristicasPersonaje.Salud > 0)
            {
                //Luego del enfrentamiento, se restablece la salud del personaje a 100
                personaje1.CaracteristicasPersonaje.Salud = 100;
            }
        }
        if (personaje1.CaracteristicasPersonaje.Salud >= 0)
        {
            Show.MostrarGanador(personaje1);
        }
        else
        {
            Show.MostrarPerdedor();
        }

    }

    private static void ModificarSaludPorClima(personajes personaje1, Root? clima)
    {
        foreach (var item in clima.data)
        {
            if (item.snow != 0)
            {
                personaje1.CaracteristicasPersonaje.Salud = 50;
            }
            else
            {
                if (item.precip != 0)
                {
                    personaje1.CaracteristicasPersonaje.Salud = 75;
                }
                else
                {
                    if (item.clouds > 0)
                    {
                        personaje1.CaracteristicasPersonaje.Salud = 100;
                    }
                    else
                    {
                        personaje1.CaracteristicasPersonaje.Salud = 125;
                    }

                }
            }
        }
    }

    //Funcion ataque de nuestro personaje, tiene la posibilidad de atacar o recuperar vida. Lo maximo de vida que se puede tener es 100
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
            danioProvocado = (ataque * efectividad - defensa) / constanteDeAjuste+10;
            personajeDefiende.CaracteristicasPersonaje.Salud -= danioProvocado;
        }
        else
        {
            personajeAtaca.CaracteristicasPersonaje.Salud += rand.Next(0, 50);
            if (personajeAtaca.CaracteristicasPersonaje.Salud > 100)
            {
                personajeAtaca.CaracteristicasPersonaje.Salud = 100;
            }
        }
    }
    //Funcion de ataque del rival, solo puede atacar
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
        danioProvocado = (ataque * efectividad - defensa) / constanteDeAjuste+10;
        personajeDefiende.CaracteristicasPersonaje.Salud -= danioProvocado;
    }
}
