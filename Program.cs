using System;
using System.IO;
using espacioPersonajes;
using persistenciaDeDatos;
using System.Collections.Generic;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.ForegroundColor=ConsoleColor.White;
        var manejoArchivos = new personajesJson();
        string ruta = "ArchivoGuardar.json";
        List<personajes> personajeCreado = new List<personajes>();
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
        
Console.WriteLine("╔════════════════════════════════════════════════════════╗");
Console.WriteLine("║                                                        ║");
Console.WriteLine("║  ¡Bienvenido al emocionante mundo de la batalla épica! ║");
Console.WriteLine("║  En este juego, tendrás la oportunidad de sumergirte   ║");
Console.WriteLine("║  en una aventura llena de acción y estrategia.         ║");
Console.WriteLine("║  Prepárate para enfrentarte a desafiantes oponentes    ║");
Console.WriteLine("║  y demostrar tu valía en la arena.                     ║");
Console.WriteLine("║                                                        ║");
Console.WriteLine("║  El juego consiste en elegir al azar un personaje y    ║");
Console.WriteLine("║  enfrentarte a tus adversarios uno por uno hasta       ║");
Console.WriteLine("║  vencerlos a todos. Tu misión es mantener tu salud     ║");
Console.WriteLine("║  intacta mientras reduces la del oponente a cero.      ║");
Console.WriteLine("║  Recuerda, si tu salud llega a cero, perderás, pero    ║");
Console.WriteLine("║  si logras derrotar a tu oponente, avanzarás a la      ║");
Console.WriteLine("║  siguiente ronda.                                      ║");
Console.WriteLine("║                                                        ║");
Console.WriteLine("║  Tendrás la oportunidad de atacar primero y luego      ║");
Console.WriteLine("║  defenderte. Durante tus turnos de ataque, podrás      ║");
Console.WriteLine("║  elegir entre lanzar un poderoso ataque o tomar una    ║");
Console.WriteLine("║  bebida energética para recuperar un valor aleatorio   ║");
Console.WriteLine("║  de salud entre 0 y 30. ¡La elección es tuya!          ║");
Console.WriteLine("║                                                        ║");
Console.WriteLine("║  ¡Prepárate para una batalla intensa y desafiante!     ║");
Console.WriteLine("║  Enfréntate a tus oponentes con coraje y estrategia,   ║");
Console.WriteLine("║  y recuerda que el juego llegará a su fin cuando       ║");
Console.WriteLine("║  hayas sido derrotado o hayas eliminado a los 9        ║");
Console.WriteLine("║  oponentes restantes.                                  ║");
Console.WriteLine("║                                                        ║");
Console.WriteLine("║  ¡Que comience la batalla! ¡Buena suerte!              ║");
Console.WriteLine("║                                                        ║");
Console.WriteLine("╚════════════════════════════════════════════════════════╝");
        Console.ForegroundColor=ConsoleColor.Green;
        Console.WriteLine(@"\n\n
_________           _______ _______ _______ _______ _______ _       _______________________ 
\__   __|\     /|  (  ____ (  ____ (  ____ (  ____ (  ___  ( (    /(  ___  \__    _(  ____ \
   ) (  | )   ( |  | (    )| (    \| (    )| (    \| (   ) |  \  ( | (   ) |  )  ( | (    \/
   | |  | |   | |  | (____)| (__   | (____)| (_____| |   | |   \ | | (___) |  |  | | (__    
   | |  | |   | |  |  _____|  __)  |     __(_____  | |   | | (\ \) |  ___  |  |  | |  __)   
   | |  | |   | |  | (     | (     | (\ (        ) | |   | | | \   | (   ) |  |  | | (      
   | |  | (___) |  | )     | (____/| ) \ \_/\____) | (___) | )  \  | )   ( |\_)  ) | (____/\
   )_(  (_______)  |/      (_______|/   \__\_______(_______|/    )_|/     \(____/  (_______/
                                                                                            
");
        var rand = new Random();
        var personaje1 = new personajes();
        personaje1 = personajeCreado[rand.Next(0, 9)];
        personajeCreado.Remove(personaje1);
        personaje1.Mostrar();
        var clima = manejoArchivos.GetClimas();
        Console.ForegroundColor=ConsoleColor.Blue;
        Console.WriteLine(@"
____    __    ______           ______     
/\  _`\ /\ \  /\__  _\  /'\_/`\/\  _  \    
\ \ \/\_\ \ \ \/_/\ \/ /\      \ \ \L\ \   
 \ \ \/_/\ \ \  _\ \ \ \ \ \__\ \ \  __ \  
  \ \ \L\ \ \ \L\ \_\ \_\ \ \_/\ \ \ \/\ \ 
   \ \____/\ \____/\_____\ \_\\ \_\ \_\ \_\
    \/___/  \/___/\/_____/\/_/ \/_/\/_/\/_/");
        foreach (var item in clima.data)
        {
            Console.WriteLine("\nTemperatura: " + item.temp + "\nWeather: " + item.weather.description);
            if (item.snow > 0)
            {
                Console.WriteLine(@"
               _(  )_( )_
              (_   _    _)
              * *(_) (__)
             * * * * * *
            * * * * * *
            ");
            }
            else
            {
                if (item.precip > 0)
                {
                    Console.ForegroundColor=ConsoleColor.DarkBlue;
                    Console.WriteLine(@"
               _(  )_( )_
              (_   _    _)
              / /(_) (__)
             / / / / / /
            / / / / / /
            ");
                }
                else
                {
                    if (item.clouds > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(@"                                       ___    ,'""""'.
                                    ,'''  '' ''''      `.
                                   ,'        _.         `._
                                  ,'       ,'              `''''.
                                 ,'    .-''`.    ,-'            `.
                                ,'    (        ,'                :
                              ,'     ,'           __,            `.
                        ,'''''     .' ;-.    ,  ,'  \             `''''.
                      ,'           `-(   `._(_,'     )_                `.
                     ,'         ,---. \ @ ;   \ @ _,'                   `.
                ,-""'         ,'      ,--'-    `;'                       `.
               ,'            ,'      (      `. ,'                          `.
               ;            ,'        \    _,','                            `.
              ,'            ;          `--'  ,'                              `.
             ,'             ;          __    (                    ,           `.
             ;              `____...  `78b   `.                  ,'           ,'
             ;    ...----'''' )  _.-  .d8P    `.                ,'    ,'    ,'
_....----''' '.        _..--'_.-:.-' .'        `.             ,''.   ,' `--'
              `' mGk '' _.-'' .-'`-.:..___...--' `-._      ,-''   `-'
        _.--'       _.-'    .'   .' .'               `'''''
  __.-''        _.-'     .-'   .'  /
 '          _.-' .-'  .-'        .'
        _.-'  .-'  .-' .'  .'   /
    _.-'      .-'   .-'  .'   .'
_.-'       .-'    .'   .'    /
       _.-'    .-'   .'    .'
    .-'            .'
");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(@"       \     (      /
   `.    \     )    /    .'
     `.   \   (    /   .'
       `.  .-''''-.  .'
 `~._    .'/_    _\`.    _.~'
     `~ /  / \  / \  \ ~'
_ _ _ _|  _\O/  \O/_  |_ _ _ _
       | (_)  /\  (_) |
    _.~ \  \      /  / ~._
 .~'     `. `.__.' .'     `~.
       .'  `-,,,,-'  `.
     .'   /    )   \   `.
   .'    /    (     \    `.
        /      )     \     
              (");
                    }

                }
            }
        }
        int ronda=1;
        while (personajeCreado.Count() != 0 && personaje1.CaracteristicasPersonaje.Salud >= 0)
        {
            var rival = new personajes();
            rival = personajeCreado[rand.Next(0, (personajeCreado.Count() - 1))];
            Console.WriteLine("\n");
            Console.WriteLine(@"
██████╗░██╗██╗░░░██╗░█████╗░██╗░░░░░
██╔══██╗██║██║░░░██║██╔══██╗██║░░░░░
██████╔╝██║╚██╗░██╔╝███████║██║░░░░░
██╔══██╗██║░╚████╔╝░██╔══██║██║░░░░░
██║░░██║██║░░╚██╔╝░░██║░░██║███████╗
╚═╝░░╚═╝╚═╝░░░╚═╝░░░╚═╝░░╚═╝╚══════╝");
            rival.Mostrar();
            Console.WriteLine($"╔═════════════════════════════════════════╗");
            Console.WriteLine($"║             RONDA {ronda}               ║");
            Console.WriteLine($"╚═════════════════════════════════════════╝");
            Console.WriteLine(@"
            
█▀▀ █▀█ █▀▄▀█ █ █▀▀ █▄░█ ▀█ ▄▀█   █░░ ▄▀█   █▄▄ ▄▀█ ▀█▀ ▄▀█ █░░ █░░ ▄▀█
█▄▄ █▄█ █░▀░█ █ ██▄ █░▀█ █▄ █▀█   █▄▄ █▀█   █▄█ █▀█ ░█░ █▀█ █▄▄ █▄▄ █▀█
");
            while (personaje1.CaracteristicasPersonaje.Salud >= 0 && rival.CaracteristicasPersonaje.Salud >= 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("------------Su turno-------------");
                Ataque(personaje1, rival);
                Console.WriteLine($"Su salud:{personaje1.CaracteristicasPersonaje.Salud}");
                Console.WriteLine($"Salud de {rival.DatosPersonaje.Nombre}: {rival.CaracteristicasPersonaje.Salud}");
                if (rival.CaracteristicasPersonaje.Salud >= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("------------TURNO DEL RIVAL------------\n");
                    AtaqueRival(rival, personaje1);
                }
                Console.WriteLine($"Su salud:{personaje1.CaracteristicasPersonaje.Salud}");
                Console.WriteLine($"Salud de {rival.DatosPersonaje.Nombre}: {rival.CaracteristicasPersonaje.Salud}");
            }
            ronda+=1;
            personajeCreado.Remove(rival);
            if(personaje1.CaracteristicasPersonaje.Salud>0)
            {
                personaje1.CaracteristicasPersonaje.Salud=100;
            }
        }
        if (personaje1.CaracteristicasPersonaje.Salud >= 0)
        {
            Console.ForegroundColor=ConsoleColor.Yellow;
            Console.WriteLine(@"\t
███████╗███████╗██╗░░░░░██╗░█████╗░██╗██████╗░░█████╗░██████╗░███████╗░██████╗██╗██╗██╗███████╗░██████╗
██╔════╝██╔════╝██║░░░░░██║██╔══██╗██║██╔══██╗██╔══██╗██╔══██╗██╔════╝██╔════╝██║██║██║██╔════╝██╔════╝
█████╗░░█████╗░░██║░░░░░██║██║░░╚═╝██║██║░░██║███████║██║░░██║█████╗░░╚█████╗░██║██║██║█████╗░░╚█████╗░
██╔══╝░░██╔══╝░░██║░░░░░██║██║░░██╗██║██║░░██║██╔══██║██║░░██║██╔══╝░░░╚═══██╗╚═╝╚═╝╚═╝██╔══╝░░░╚═══██╗
██║░░░░░███████╗███████╗██║╚█████╔╝██║██████╔╝██║░░██║██████╔╝███████╗██████╔╝██╗██╗██╗███████╗██████╔╝
╚═╝░░░░░╚══════╝╚══════╝╚═╝░╚════╝░╚═╝╚═════╝░╚═╝░░╚═╝╚═════╝░╚══════╝╚═════╝░╚═╝╚═╝╚═╝╚══════╝╚═════╝░

███████╗██╗░░░░░  ░██████╗░░█████╗░███╗░░██╗░█████╗░██████╗░░█████╗░██████╗░██╗██╗
██╔════╝██║░░░░░  ██╔════╝░██╔══██╗████╗░██║██╔══██╗██╔══██╗██╔══██╗██╔══██╗██║██║
█████╗░░██║░░░░░  ██║░░██╗░███████║██╔██╗██║███████║██║░░██║██║░░██║██████╔╝██║██║
██╔══╝░░██║░░░░░  ██║░░╚██╗██╔══██║██║╚████║██╔══██║██║░░██║██║░░██║██╔══██╗╚═╝╚═╝
███████╗███████╗  ╚██████╔╝██║░░██║██║░╚███║██║░░██║██████╔╝╚█████╔╝██║░░██║██╗██╗
╚══════╝╚══════╝  ░╚═════╝░╚═╝░░╚═╝╚═╝░░╚══╝╚═╝░░╚═╝╚═════╝░░╚════╝░╚═╝░░╚═╝╚═╝╚═╝");
            personaje1.Mostrar();
            Console.WriteLine(@$"        
        |||||||||
        | _   _ |      
       (  ' _ '  )
        |  ___  |               
         |_____|                   
  _______/     \_______         
 /                     \          SOY EL MEJOR!!!!
|   |\             /|   |
|   ||  .       .  ||   |     
|   / \           / \   |
\  |   | |_ | _| |   |  /     
|==|   | |_ | _| |   |==|                    
/  /_ _|_|__|__|_|_ _\  \
|___| /            \|___|
      |     |      |
      |     |      |
      |MEX  |   MEX|         
      |     |      |           
      '|''|'''|''|''           
       |  |   |  |      {personaje1.DatosPersonaje.Apodo};
       |  |   |  |
      /   )   (   \
     Ooooo     ooooO");
        }
        else
        {
            Console.ForegroundColor=ConsoleColor.DarkRed;
            Console.WriteLine(@"
  _______
 /       \
|         |
|   R.I.P |
|         |
|         |
 \       /
  -------");
          Console.WriteLine(@"
█▀▀ ▄▀█ █▀▄▀█ █▀▀   █▀█ █░█ █▀▀ █▀█
█▄█ █▀█ █░▀░█ ██▄   █▄█ ▀▄▀ ██▄ █▀▄");
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
