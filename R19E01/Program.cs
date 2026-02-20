
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
            byte opcion = 1;        //0 - Salir
                                    //1 - Mostrar listado de vehiculos
                                    //2 - Mostrar datos de un vehiculo

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
                        Controlador.MostrarListado(concesionario);
                        break;
                    //2.2.3.- Mostrar datos de un vehiculo
                    case 2:
                        Controlador.MostrarVehiculo(concesionario);
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
            coche.PrecioContado = 60000f;

            lista[2] = coche;
            //Cargar Vehiculo 4
            coche = new Vehiculo();
            coche.Marca = "Renault";
            coche.Modelo = "Megane";
            coche.PrecioContado = 2000;

            lista[3] = coche;

            //Cargar Vehiculo 5
            coche = new Vehiculo("Ford", "Transit");
            coche.PrecioContado = 5800;
            coche.TipoVehiculo = "FURGONETA";

            lista[4] = coche;

        }
    }
}
