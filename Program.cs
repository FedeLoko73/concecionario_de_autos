using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Tp_1_archivos
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream Archivo;
            StreamReader Leer;
            StreamWriter grabar;
            string pat, marca, modelo, cadena, busmarca, resp, resp1;
            string[] vec;
            DateTime fecha;
            int precio;
            char opcion;
            int cont;
            cont=0;
            resp="s";
            resp1 = "s";

            
            while (resp=="s")
            {
                menu();
                opcion=Console.ReadKey().KeyChar;
                while (opcion != 'a' && opcion != 'b' && opcion != 'l')
                {
                    Console.Clear();
                    Console.WriteLine("Opcion Incorrecta, vuelva a ingresar: ");
                    menu();
                    opcion=Console.ReadKey().KeyChar;
                    Console.WriteLine("\n");
                }
                switch(opcion)
                {
                    case'a':
                        {
                            Console.Clear();
                            while (resp1=="s")
                            {
                            Console.WriteLine("Ingrese patente del auto: ");
                            pat = Console.ReadLine();
                                while (pat.Length!=6)
                                {
                                    Console.WriteLine("Formato incorrecto, Vuelva a ingresar: ");
                                    pat = Console.ReadLine();
                                }
                             Console.WriteLine("Ingrese Fecha de Patentado dd/mm/aaaa : ");
                            cadena=Console.ReadLine();
                            while (DateTime.TryParse(cadena, out fecha) == false)
                            {
                                Console.WriteLine("Formato o fecha incorrecta, vuelva a ingresar: ");
                                cadena=Console.ReadLine();
                            } 
                                
                            Console.WriteLine("Ingrese marca del vehiculo: ");
                            marca = Console.ReadLine();

                            Console.WriteLine("Ingrese modelo del vehiculo: ");
                            modelo=Console.ReadLine();
                            Console.WriteLine("Ingrese el valor del auto: ");
                            cadena = Console.ReadLine();
                            while(int.TryParse(cadena, out precio) ==false)
                            {
                                Console.WriteLine("Valor Incorrecto, vuelva a ingresar: ");
                                cadena=Console.ReadLine();
                            }
                            Archivo=new FileStream("autos.txt", FileMode.Append);
                            grabar=new StreamWriter(Archivo);
                            grabar.Write(pat);
                            grabar.Write(";");
                            grabar.Write(fecha.Date.ToString("dd/mm/yyyy"));
                            grabar.Write(";");
                            grabar.Write(marca);
                            grabar.Write(";");
                            grabar.Write(modelo);
                            grabar.Write(";");
                            grabar.Write(precio);
                            grabar.Write("\n");
                            grabar.Close();
                            Archivo.Close();
                            Console.WriteLine("Seguir ingresando? s/n: ");
                            resp1=Console.ReadLine();
                            Console.Clear();
                            }
                            break;
                        } 
                    case 'b':
                        {
                            Console.Clear();
                            Console.WriteLine("Ingrese Marca a buscar : ");
                            busmarca=Console.ReadLine();
                            Archivo = new FileStream("autos.txt", FileMode.Open);
                            Leer = new StreamReader(Archivo);
                            Console.WriteLine("--------------------------------------------------------------------------------");
                            Console.WriteLine(":Pat. :Fecha Pat. :Marca               :Modelo                 :Precio          :");
                            Console.WriteLine("--------------------------------------------------------------------------------");
                            cont = 0;
                            while (Leer.EndOfStream == false)
                            {
                                cadena = Leer.ReadLine();
                                vec = cadena.Split(';');
                                
                                if (busmarca == vec[2])
                                {
                                    cont = cont+1;
                                    Console.WriteLine(":"+vec[0]+":"+vec[1]+":"+vec[2].PadRight(20,' ')+":"+vec[3].PadRight(23,' ')+":"+vec[4]);
                                    
                                    }
                            }
                            Console.WriteLine("--------------------------------------------------------------------------------");
                            Console.WriteLine("Registros Listados: "+cont);
                            if (cont == 0)
                            {
                                Console.WriteLine("//////Marca no registrada///////");
                            }
                            Archivo.Close();
                            Leer.Close();
                            break;
                    }

                    case 'l':
                        {
                            Console.Clear();
                            cont = 0;
                            if (File.Exists("autos.txt"))
                        {
                            Console.WriteLine("\nContenido del Archivo:");
                            Archivo = new FileStream("autos.txt", FileMode.Open);
                            Leer = new StreamReader(Archivo);
                                Console.WriteLine("--------------------------------------------------------------------------------");
                                Console.WriteLine(":Pat.  :Fecha Pat.  :Marca               :Modelo                 :Precio        ");
                                Console.WriteLine("--------------------------------------------------------------------------------");
                            while (Leer.EndOfStream == false)
                            {
                                cadena = Leer.ReadLine();
                                vec=cadena.Split(';');
                                Console.WriteLine(":"+vec[0]+":"+vec[1]+"  :"+vec[2].PadRight(20,' ')+":"+vec[3].PadRight(23,' ')+":"+vec[4]);
                                cont=cont+1;
                                }
                                Console.WriteLine("--------------------------------------------------------------------------------");
                                Console.WriteLine("Registros Listados: "+cont);
                            Leer.Close();
                            Archivo.Close();
                        }
                        else
                        {
                            Console.WriteLine("\nEl archivo no existe.");
                        }
                        break;
                    }
                }
                        Console.WriteLine("Seguir Trabajando s/n: ");
                        resp=Console.ReadLine();
                        while (resp != "s" && resp != "n")
                        {
                            Console.WriteLine("Respuesta incorrecta, Vuelva a ingresar: ");
                            resp = Console.ReadLine();
                        }
                        Console.Clear();
            }
                

                        Console.ReadKey();

}
       static void menu()
        {
            Console.WriteLine("      ////////Ingrese Opcion/////////");
            Console.WriteLine("      (a)<<-- Agregar un registro");
            Console.WriteLine("      (b)<<-- Buscar vehiculos por marca");
            Console.WriteLine("      (l)<<-- Listar stock");
            Console.WriteLine("                      ");
            Console.Write("Ingrese su opcion: ");
        }
    }
}
