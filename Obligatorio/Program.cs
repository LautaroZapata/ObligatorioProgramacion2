using Dominio;
namespace Obligatorio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sistema unS = Sistema.Instancia;
            int opcion = 0;
 
            // menu
            string[] opciones = { "Listar Clientes", "Listar Vuelos con codigo IATA", "Alta de cliente ocasional", "Listar Pasajes por rango de fechas" };
            do
            {
                Menu(opciones);
                opcion = PedirNumero("Opcion");
                switch (opcion)
                {
                    case 1:
                        // Listado de todos los clientes
                        try
                        {
                            foreach (Usuario unUser in unS.ListarClientes())
                            {
                                Console.WriteLine(unUser);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;


                    case 2:
                        // Listar vuelos

                        try
                        {
                            Console.WriteLine("Ingrese el codigo IATA del aeropuerto");
                            string codigoIata = Console.ReadLine();
                            foreach (Vuelo unVuelo in unS.ListarVuelos(codigoIata))
                            {
                                Console.WriteLine(unVuelo);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;



                    case 3:
                        // Alta cliente ocasionales
                        try
                        {
                            Console.WriteLine("Ingrese el documento del cliente sin puntos ni guiones.");
                            string documento = Console.ReadLine();
                            Console.WriteLine("Ingrese el nombre del cliente");
                            string nombre = Console.ReadLine();
                            Console.WriteLine("Ingrese el mail del cliente");
                            string mail = Console.ReadLine();
                            Console.WriteLine("Ingrese la contraseña del cliente");
                            string password = Console.ReadLine();
                            Console.WriteLine("Ingrese la nacionalidad del cliente");
                            string nacionalidad = Console.ReadLine();
                            Ocasionales clienteOcasional = new Ocasionales(documento, nombre, nacionalidad, mail, password);
                            unS.AgregarUsuario(clienteOcasional);
                            Console.WriteLine("Se registro el usuario con exito.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        

                        break;
                    case 4:
                        //Filtro pasajes
                        try
                        {
                            Console.WriteLine("Ingrese una fecha");
                            string fecha1 = Console.ReadLine();
                            Console.WriteLine("Ingrese otra fecha");
                            string fecha2 = Console.ReadLine();
                            DateTime fecha1Parseada = DateTime.Parse(fecha1);
                            DateTime fecha2Parseada = DateTime.Parse(fecha2);
                            foreach (Pasaje unPasaje in unS.ListarPasajes(fecha1Parseada, fecha2Parseada))
                            {
                                Console.WriteLine(unPasaje);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                }
                if (opcion != 0)
                {
                    Console.Write("Cualquier tecla para seguir...");
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }

        static public void Menu(string[] opciones)
        {
            Console.Clear();
            int numero = 1;
            Console.WriteLine("Ingresa una de las siguientes opciones (0 para finalizar)");
            foreach (string opcion in opciones)
            {
                Console.WriteLine(numero + " - " + opcion);
                numero++;
            }
        }

        static public int PedirNumero(string mensaje = "Ingrese número.")
        {
            int numero;
            bool exito;
            do
            {
                exito = int.TryParse(Console.ReadLine(), out numero);
                if (!exito)
                {
                    MensajeError("Debe escribir solo numeros.");
                }
            } while (!exito);

            return numero;
        }
        static public void MensajeError(string mensaje)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"---Error----> {mensaje}");
            Console.BackgroundColor = ConsoleColor.Black;
        }

    }
}
