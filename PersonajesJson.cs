using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using espacioPersonajes;
using System.Net;

namespace persistenciaDeDatos
{
    class personajesJson
    {
        //Funcion para guardar una lista de personajes en un archivo json
        public void GuardarPersonajes(string nombreArchivo, List<personajes> listaPersonajes)
        {
            FileStream archivo = new FileStream(nombreArchivo, FileMode.OpenOrCreate);
            var serializar = JsonSerializer.Serialize(listaPersonajes);
            using (StreamWriter Guardar = new StreamWriter(archivo))
            {
                Guardar.Write(serializar);
                Guardar.Close();
            }

        }
        //Función para leer lista de personajes desde un archivo JSON
        public List<espacioPersonajes.personajes> LeerPersonajes(string nombreArchivo)
        {
            FileStream archivo = new FileStream(nombreArchivo, FileMode.Open);
            string? archivoLeido;

            using (var leer = new StreamReader(archivo))
            {
                archivoLeido = leer.ReadToEnd();
                leer.Close();
            }
            var PersonajesJson = new List<personajes>();
            PersonajesJson = JsonSerializer.Deserialize<List<personajes>>(archivoLeido);
            return (PersonajesJson);
        }
        //Funcion para controlar si un archivo existe y no esta vacío
        public bool Existe(string nombreArchivo)
        {
            if (File.Exists(nombreArchivo))
            {
                FileStream archivo = new FileStream(nombreArchivo, FileMode.Open);
                StreamReader archivoLeer = new StreamReader(archivo);
                string? contenidoArch = archivoLeer.ReadToEnd();
                archivoLeer.Close();
                if (contenidoArch != "")
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            }
            else
            {
                return (false);
            }
        }

//Funcion para según una latitud y longitud aleatoria obtener el clima de esta por medio de una APi
        public Root? GetClimas()
        {
            Root climas = new Root();
            var rand = new Random();
            double lon = rand.Next(-180, 180);
            double lat = rand.Next(-90, 90);
            string APIKey = "548061c052d24a66bfe0360a767c3457";
            var url = $"https://api.weatherbit.io/v2.0/current?lat={lat}&lon={lon}&key={APIKey}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            climas = NewMethod(climas, request);
            return (climas);
        }

        private static Root NewMethod(Root climas, HttpWebRequest request)
        {
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            climas = JsonSerializer.Deserialize<Root>(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("Problemas de acceso a la API");
                EstablecerValloresDefault(climas);
            }

            return climas;
        }

        private static void EstablecerValloresDefault(Root climas)
        {
            Datum datumAux = new Datum();
            datumAux.temp = 25.0;
            datumAux.precip = 0;
            datumAux.snow = 0;
            datumAux.clouds = 0;
            Weather weatherAux = new Weather();
            weatherAux.description = " soleado y templado";
            datumAux.weather = weatherAux;
            List<Datum> listaDatumAux = new List<Datum>();
            listaDatumAux.Add(datumAux);
            climas.data = listaDatumAux;
            climas.count = 1;
        }
    }
}

