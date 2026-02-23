using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R19E01
{
    public static class Controlador
    {
        public static void MostrarListado(Vehiculo[] listaCoches)
        {
            //TODO: implementacion de la accion Mostrar Listado
            
            Interfaz.MostrarListaCoches(listaCoches);
        }

       public static void MostrarVehiculo(Vehiculo[] listaCoches)
       {
            // Recursos 
            int seleccion = 0;

            //1.- Mostrar lista de Vehiculos

            //2.- Seleccionar Vehiculo

            //3.- Validar Selección

            //4.- Mostrar la Retroalimentación

            //5.- Mostrar Datos Vehiculo
            Interfaz.MostrarDatosCoches(listaCoches[seleccion]);
       }
    }
}
