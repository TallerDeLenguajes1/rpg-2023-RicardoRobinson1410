using System;
using System.IO;
namespace espacioPersonajes
{
    public class personajes{
        private datos datosPersonaje;
        private caracteristicas caracteristicasPersonaje;

        public datos DatosPersonaje { get => datosPersonaje; set => datosPersonaje = value; }
        public caracteristicas CaracteristicasPersonaje { get => caracteristicasPersonaje; set => caracteristicasPersonaje = value; }

    }
    
}