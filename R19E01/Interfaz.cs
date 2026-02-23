using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            //Constantes
            const byte NUM_OPCIONES = 3;

            // Recursos
            byte seleccion = 0;
            bool esValido;
            string mensajeError = "";

            do
            {
                esValido = true;
                //1.- Mostrar el menú
                Console.Clear();
                Console.WriteLine("\t\t MENÚ DE ACCIONES - CONCESIONARIO");
                Console.WriteLine("");
                Console.WriteLine("\t 0 - Salir");
                Console.WriteLine("\t 1 - Mostrar Lista de Vehiculos");
                Console.WriteLine("\t 2 - Mostrar Vehículos");
                Console.Write("Opcion: ");
                try
                {
                    //2.- Obtener la opción
                    seleccion = Convert.ToByte(Console.ReadLine());

                    //3.- Validar la opción
                    if (seleccion >= NUM_OPCIONES)
                    {
                        throw new OverflowException();
                    }
                }
                catch (FormatException error)
                {
                    esValido = false;
                    mensajeError = "ERROR: Ha introducido caracteres no numéricos";
                }
                catch (OverflowException error)
                {
                    esValido = false;
                    mensajeError = "ERROR: Ha introducido un valor que no es opcion del menú";
                }

                //4.- Retroalimentación al usuario
                if (!esValido)
                {
                    Console.WriteLine($"{mensajeError}");
                    Console.Write("Pulse una tecla para continuar");
                    Console.ReadLine();
                }

            }
            while (!esValido);
            

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

        public static void MostrarDatosCoches(Vehiculo coche)
        {
            Console.Clear();
            Console.WriteLine($"Marca: {coche.Marca}");
            Console.WriteLine($"Modelo: {coche.Modelo}");
            Console.WriteLine($"Tipo de Vehículo: {coche.Tipo}");
            Console.WriteLine($"Combustible: {coche.Combustible}");
            Console.WriteLine($"Precio Contado {coche.PrecioContado}");
            Console.WriteLine($"Precio Financiado: {coche.PrecioFinanciado}");
            Console.WriteLine($"");

            Console.ReadLine();
        }
        #endregion
    }
}
