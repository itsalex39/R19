using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R19E01
{
    public static class Interfaz
    {
        #region METODOS DE ENTRADA
        public static byte ObtenerOpcionMenu()
        {
            // Recursos
            byte seleccion = 0;

            //TODO: Implementacion del metodo ObtenerOpcionMenu

            //Salida - Método
            return seleccion;
        }
        #endregion

        #region METODOS DE SALIDA
        public static void MostrarListaCoches(Vehiculo[] listaCoches)
        {
            Console.Clear();

            Console.WriteLine("\t\tLista de Vehiculos");

            for (int i = 0; i < listaCoches.Length; i++)
            {
                Console.WriteLine($"\t {i+1} - {listaCoches[i].Marca} {listaCoches[i].Modelo}");
            }
            Console.ReadLine();
        }
        #endregion
    }
}
