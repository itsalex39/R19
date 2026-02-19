
namespace R19E01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Constantes
            const int NUM_VEHICULOS = 5;

            //Recursos
            // Estructura que almacenará los vehiculos
            Vehiculo[] concesionario;
            bool salir = false;
            byte opcion = 0;        //0 - Salir

            //Inicializacion
            //1.- Carga inicial de vehiculos
            concesionario = new Vehiculo[NUM_VEHICULOS];
            CargarVehiculos(concesionario);
            
            //2.- Acciones del programa
            do
            {
                //Entrada
                //2.1.- Seleccionar la accion a realizar
                opcion = Interfaz.ObtenerOpcionMenu();

                //Proceso
                //2.2.- Realizar la acción segun la opción seleccionada
                switch (opcion)
                {
                    //2.2.1.- Salida del programa
                    case 0:
                        salir = true;
                        break;
                    //2.2.2.- Mostrar listado de vehiculos
                    case 1:
                        //TODO: implementacion de la accion Mostrar Listado
                        break;
                    //2.2.3.- Mostrar datos de un vehiculo
                    case 2:
                        //TODO: Implementacion de la accion Mostrar Vehiculo
                        break;
                }

                //Salida


            }
            while (!salir);
            




        }

        private static void CargarVehiculos(Vehiculo[] lista)
        {
            //Recursos
            Vehiculo coche;     //No instanciado (null)

            //Cargar Vehiculo 1
            coche = new Vehiculo();
            coche.Marca = "Seat";
            coche.Modelo = "Altea";
            coche.PrecioContado = 18500f;

            lista[0] = coche;

            //Cargar Vehiculo 2
            coche = new Vehiculo("Ferrari", "Testarrosa");
            coche.PrecioContado = 75000f;

            lista[1] = coche;

            //Cargar Vehiculo 3
            coche = new Vehiculo("BMW", "M3");
            coche.PrecioContado = 60000;

            lista[2] = coche;
            //Cargar Vehiculo 4

            //Cargar Vehiculo 5

        }
    }
}
