using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R19E01
{
    public enum TipoVehiculos : byte { Turismo, Furgoneta, Camion, Moto };
    public enum TiposCombustible : byte { Gasolina, Diesel, Electrico, Hibrido };
    public enum TiposEstado : byte { Nuevo, Ocasion, SegundaMano };
    public class Vehiculo
    {
        // Constantes
        const int TAMAÑO_MAX_MARCA = 20;
        const int TAMAÑO_MIN_MARCA = 3;
        const string MARCA_MODEL_DEF = "Desconocido";
        const int TAMAÑO_MAX_MODELO = 25;
        const int TAMAÑO_MIN_MODELO = 2;
        //const string TIPOS_VEHICULOS = "TURISMO FURGONETA CAMIÓN MOTO";
        const float PRECIO_MIN = 1000;
        const float PRECIO_MAX = 100000;
        const float PRECIO_DEF = 0;
        const float DESCUENTO = 0.10f;
        const int LIMITE_MATRICULACION = 10;

        // Miembros / Campos
        private string _marca;
        private string _modelo;
        //private string _tipoVehiculo;
        public TipoVehiculos Tipo;
        public TiposCombustible Combustible;
        public TiposEstado Estado;
        private float _precioContado;
        private DateTime _fechaMatriculacion;


        // Contructores
        public Vehiculo()
        {
            _marca = MARCA_MODEL_DEF;
            _modelo = MARCA_MODEL_DEF;
            //_tipoVehiculo = "TURISMO"; Campo privado de la vers anterior
            Tipo = TipoVehiculos.Turismo;
            Combustible = TiposCombustible.Diesel;
            Estado = TiposEstado.Nuevo;
            _precioContado = PRECIO_DEF;
        }

        public Vehiculo(string marca, string modelo)
        {
            Marca = marca;
            Modelo = modelo;
            //_tipoVehiculo = "TURISMO"; Campo privado de la vers anterior
            Tipo = TipoVehiculos.Turismo;
            Combustible = TiposCombustible.Diesel;
            Estado = TiposEstado.Nuevo;
            _precioContado = PRECIO_DEF;
        }

        #region Propiedades
        public string Marca
        {
            get
            {
                // Comprobacion de inicializacion
                if (_marca == MARCA_MODEL_DEF)
                {
                    throw new Exception("ERROR: La marca no se ha inicializado para el vehiculo");
                }
                return _marca;
            }
            set 
            {
                // Validacion del dato a establecer
                ValidarDato(value, TAMAÑO_MAX_MARCA, TAMAÑO_MIN_MODELO);

                //TODO: Falta Implementar la validacion de digitos y signos de puntuacion
                ValidarEspecialMarca(value);
                _marca = value;
            }
        }

        public string Modelo
        {
            get
            {
                // Comprobacion de Inicializacion
                if (_modelo == MARCA_MODEL_DEF)
                {
                    throw new Exception("ERROR: Modelo del vehiculo no establecido");
                }

                return _modelo;
            }
            set
            {
                //Validacion del dato a establecer
                ValidarDato(value, TAMAÑO_MAX_MODELO, TAMAÑO_MIN_MODELO);

                _modelo= value;
            }
        }

        //public string TipoVehiculo
        //{
        //    get
        //    {
        //        return _tipoVehiculo;
        //    }
        //    set
        //    {
        //        //Validar tipo de vehiculo
        //        value = value.ToUpper();
        //        if (!TIPOS_VEHICULOS.Contains(value))
        //        {
        //            throw new Exception("ERROR: Tipo de vehiculo no valido");
        //        }

        //        _tipoVehiculo = value;
        //    }
        //}

        public float PrecioContado
        {
            get
            {
                if (_precioContado == PRECIO_DEF)
                {
                    throw new Exception("Valor no establecido");
                }

                return _precioContado;
            }
            set
            {
                ValidarPrecio(value);

                _precioContado = value;
            }
        }

        public float PrecioFinanciado
        {
            get
            {
                return CalcularPrecioFinanciado();
            }
        }

        public DateTime FechaMatriculacion
        {
            get
            {


                return _fechaMatriculacion;
            }
            set
            {
                //Validacion Fecha Matriculacion
                ValidarFechaMatriculacion(value);

                _fechaMatriculacion = value;
            }
        }

        #endregion

        #region Métodos Privadas
        private void ValidarDato(string dato, int tamMax, int tamMin)
        {
            // 1.- Nulo o Vacio
            if (string.IsNullOrEmpty(dato))
            {
                throw new Exception("ERROR: No se ha introducido el dato");
            }
            //2.- Tamaño
            if (dato.Length < tamMin || dato.Length > tamMax)
            {
                throw new Exception("ERROR: Tamaño de la cadena incorrecto");
            }

            //3.- Caracteres especiales
            for (int i = 0; i< dato.Length; i++)
            {
                if (char.IsSymbol(dato[i]))
                {
                    throw new Exception("ERROR: El dato contiene simbolos");
                }
            }
        }
        private void ValidarEspecialMarca(string marca)
        {
            for (int i = 0; i < marca.Length; i++)
            {
                if (Char.IsDigit(marca[i]))
                {
                    throw new Exception("ERROR: Digitos no permitidos");
                }
                if (Char.IsPunctuation(marca[i]))
                {
                    throw new Exception("ERROR: Signos de puntuacion no permitidos");
                }
            }
        }

        private void ValidarPrecio(float precio)
        {
            if (precio < PRECIO_MIN)
            {
                throw new Exception("ERROR: Precio inferior al minimo");
            }
            if(precio > PRECIO_MAX)
            {
                throw new Exception("ERROR: Precio superior al maximo");
            }
        }

        private void ValidarFechaMatriculacion(DateTime fecha)
        {
            // RECURSOS
            DateTime fechaActual = DateTime.Today;

            //0.- Comprobar el parametro
            //if (fecha == null)
            //{
            //    throw new Exception("ERROR: No se ha establecido una fecha");
            //} Nunca se ejecutara el throw porque un DateTime nunca sera nulo

            //1.- Fecha posterior a la actual
            if (fechaActual < fecha)
            {
                throw new Exception("El coche no se puede haner matriculado en el futuro");
            }

            //2.- Coche con una matriculacion con un limite establecido
            fechaActual = fechaActual.AddYears(-LIMITE_MATRICULACION);
            if (fechaActual > fecha)
            {
                throw new Exception($"ERROR: El coche tiene mas de {LIMITE_MATRICULACION} años");
            }
        }

        #endregion

        #region Metodos Publicos
        public float CalcularPrecioFinanciado()
        {
            float precioF;

            precioF = PrecioContado - PrecioContado * DESCUENTO;

            return precioF;
        }
        #endregion
    }
}
