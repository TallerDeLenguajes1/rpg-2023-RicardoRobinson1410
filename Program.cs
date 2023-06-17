using System;
using System.IO;
using espacioPersonajes;
using persistenciaDeDatos;
using System.Collections.Generic;
// See https://aka.ms/new-console-template for more information
 var manejoArchivos = new persistenciaDeDatos.personajesJson();
string ruta = "ArchivoGuardar.json";
List<espacioPersonajes.personajes> personajeCreado = new List<espacioPersonajes.personajes>();
if (manejoArchivos.Existe(ruta))
{
    var listaMostrar = new List<espacioPersonajes.personajes>();
    listaMostrar = manejoArchivos.LeerPersonajes(ruta);
    foreach (var item in listaMostrar)
    {
        item.Mostrar();
    }
}else{
    var personaje1 = new espacioPersonajes.FabricaDePersonajes();
    personajes personajeCrear = new espacioPersonajes.personajes();
    for (int i = 0; i < 10; i++)
    {
        personajeCrear = personaje1.CrearPersonaje();
        personajeCreado.Add(personajeCrear);
    }
        manejoArchivos.GuardarPersonajes(ruta, personajeCreado);
}

    


