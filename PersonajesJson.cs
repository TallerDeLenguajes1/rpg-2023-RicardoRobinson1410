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
            }
            return (climas);
        }
    }
}

