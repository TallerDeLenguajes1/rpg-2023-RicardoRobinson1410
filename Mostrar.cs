using espacioPersonajes;
using System;
using System.IO;
using persistenciaDeDatos;
namespace espacioMostrar
{
    public class Mostrar
    {
        public void CondicionInicial()
        {   
            Console.ForegroundColor = ConsoleColor.White;
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
            Console.WriteLine("║  A medida que vayas avanzando de ronda, aumentaras tu  ║");
            Console.WriteLine("║  nivel en 1, asi te sea mas sencillo derrotar a los    ║");
            Console.WriteLine("║  rivales                                               ║");
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
    }

    public void MostrarPersonaje(personajes personaje1)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("╔═════════════════════════════════════════╗");
    Console.WriteLine("║          DATOS DEL PERSONAJE            ║");
    Console.WriteLine("╚═════════════════════════════════════════╝");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine();
    Console.WriteLine($"NOMBRE: {personaje1.DatosPersonaje.Nombre}");
    Console.WriteLine($"APODO: {personaje1.DatosPersonaje.Apodo}");
    Console.WriteLine($"TIPO: {personaje1.DatosPersonaje.TipoPersonaje}");
    Console.WriteLine($"FECHA DE NACIMIENTO: {personaje1.DatosPersonaje.FechaNac}");
    Console.WriteLine($"EDAD: {personaje1.DatosPersonaje.Edad}");
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("╔═════════════════════════════════════════╗");
    Console.WriteLine("║        CARACTERÍSTICAS DEL PERSONAJE    ║");
    Console.WriteLine("╚═════════════════════════════════════════╝");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine();
    Console.WriteLine($"    velocidad: {personaje1.CaracteristicasPersonaje.Velocidad}");
    Console.WriteLine($"    destreza: {personaje1.CaracteristicasPersonaje.Destreza}");
    Console.WriteLine($"    fuerza: {personaje1.CaracteristicasPersonaje.Fuerza}");
    Console.WriteLine($"    nivel: {personaje1.CaracteristicasPersonaje.Nivel}");
    Console.WriteLine($"    armadura: {personaje1.CaracteristicasPersonaje.Armadura}");
    Console.WriteLine($"    salud: {personaje1.CaracteristicasPersonaje.Salud}");
    }
    public void MostrarMiPersonaje(personajes Personaje1)
    {
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
    MostrarPersonaje(Personaje1);
    }
    public void MostrarClima(Root clima)
    {
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
            if (item.snow != 0)
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
                if (item.precip != 0)
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
    }

    public void MostrarRival(personajes Rival)
    {
        Console.WriteLine("\n");
         Console.WriteLine(@"
██████╗░██╗██╗░░░██╗░█████╗░██╗░░░░░
██╔══██╗██║██║░░░██║██╔══██╗██║░░░░░
██████╔╝██║╚██╗░██╔╝███████║██║░░░░░
██╔══██╗██║░╚████╔╝░██╔══██║██║░░░░░
██║░░██║██║░░╚██╔╝░░██║░░██║███████╗
╚═╝░░╚═╝╚═╝░░░╚═╝░░░╚═╝░░╚═╝╚══════╝");
MostrarPersonaje(Rival);
    }

    public void MostrarComienzoBatalla(int ronda)
    {
            Console.WriteLine($"╔═════════════════════════════════════════╗");
            Console.WriteLine($"║             RONDA {ronda}               ║");
            Console.WriteLine($"╚═════════════════════════════════════════╝");
            Console.WriteLine(@"
            
█▀▀ █▀█ █▀▄▀█ █ █▀▀ █▄░█ ▀█ ▄▀█   █░░ ▄▀█   █▄▄ ▄▀█ ▀█▀ ▄▀█ █░░ █░░ ▄▀█
█▄▄ █▄█ █░▀░█ █ ██▄ █░▀█ █▄ █▀█   █▄▄ █▀█   █▄█ █▀█ ░█░ █▀█ █▄▄ █▄▄ █▀█
");
    }
    public void MostrarMiturno(personajes personaje1, personajes rival)
    {
         Console.WriteLine("------------Su turno-------------");
         Console.WriteLine($"Su salud:{personaje1.CaracteristicasPersonaje.Salud}");
        Console.WriteLine($"Salud de {rival.DatosPersonaje.Nombre}: {rival.CaracteristicasPersonaje.Salud}");
    }
    public void MostrarTurnoRival(personajes personaje1, personajes rival)
    {
        Console.ForegroundColor = ConsoleColor.Red;
         Console.WriteLine("------------turno rival-------------");
         Console.WriteLine($"Su salud:{personaje1.CaracteristicasPersonaje.Salud}");
        Console.WriteLine($"Salud de {rival.DatosPersonaje.Nombre}: {rival.CaracteristicasPersonaje.Salud}");
    }
    public void MostrarGanador(personajes personaje1)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
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
        MostrarMiPersonaje(personaje1);
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

    public void MostrarPerdedor()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
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
}