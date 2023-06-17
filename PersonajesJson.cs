using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json; 
using espacioPersonajes;

namespace persistenciaDeDatos{
    class personajesJson{
    public void GuardarPersonajes(string nombreArchivo, List<personajes> listaPersonajes){
        FileStream archivo=new FileStream(nombreArchivo,FileMode.OpenOrCreate);
        var serializar=JsonSerializer.Serialize(listaPersonajes);
        using (StreamWriter Guardar=new StreamWriter(archivo))
        {
           Guardar.Write(serializar);
           Guardar.Close();
        }
        
        }
    public List<espacioPersonajes.personajes> LeerPersonajes(string nombreArchivo){
        FileStream archivo=new FileStream(nombreArchivo,FileMode.Open);
        string? archivoLeido;
        
        using(var leer=new StreamReader(archivo)){
            archivoLeido=leer.ReadToEnd();
            leer.Close();
        }
        var PersonajesJson=new List<personajes>();
        PersonajesJson=JsonSerializer.Deserialize<List<personajes>>(archivoLeido);
        return(PersonajesJson);
        }
    public bool Existe(string nombreArchivo){
        if(File.Exists(nombreArchivo)){
            FileStream archivo=new FileStream(nombreArchivo,FileMode.Open);
            StreamReader archivoLeer=new StreamReader(archivo);
            string? contenidoArch=archivoLeer.ReadToEnd();
            archivoLeer.Close();
            if(contenidoArch!=""){
                return(true);
            }
            else{
                return(false);
            }
        }
        else{
                return(false);
            }
        }
    }
}
