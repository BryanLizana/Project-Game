using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Game
{
    class Program
    {
        static string userone;
        static string usertwo;
        static int turno = 0;
        static String[,] Table = new string[8, 8];
        static String ListPuntaje = "";
        static int puntone;
        static int punttwo;

        static string validar_ganador(string simbol, string user)
        {

            for (int i = 7; i > 0; i--)
            {

                for (int i2 = 0; i2 < 7; i2++)
                {
                    string simbol_now = Convert.ToString(Table[i, i2]);
                    if (simbol_now != "")
                    {
                        if (simbol_now == simbol)
                        {
                            int cantidad_horizontal = 0;
                            int cantidad_vertical = 0;


                            for (int success = 0; success < 4; success++)
                            {
                                if (i2 < 4 && Convert.ToString(Table[i, i2 + success]) == simbol) //si el index es (total) - 4(límite para ganar) es menor del index total y es x 
                                {
                                    cantidad_horizontal++;
                                }

                                if (i < 4 && Convert.ToString(Table[i + success, i2]) == simbol)
                                {
                                    cantidad_vertical++;
                                }
                            }


                            if (cantidad_vertical == 4 || cantidad_horizontal == 4)
                            {
                                Console.WriteLine("Winnn " + user + "( " + simbol + " )");
                                int point = (simbol == "x") ? puntone : punttwo;
                                ListPuntaje = ListPuntaje + "\n " + user + " win: " + point + "puntos";
                                return "1";
                            }

                        }

                    }

                }

            }
            return "0";
        }

        static void cleartable()
        {

            //rellenar valores
            Table = new string[8, 8];
            puntone = 0;
            punttwo = 0;

        }
        static String imprimir_table(string number, string simbol = "")
        {

            //rellenar valores
            int permitir = 1;

            for (int row = 0; row < 7 && permitir == 1; row++) //una vez se rompa la condicion no debe permitir seguir con la consulta
            {

                for (int column = 0; column < 7 && permitir == 1; column++)
                {
                    string value = Table[row, column];
                    if (number == column.ToString() && (row == 6 && value == null)) //esto se activa cuando se ingresa un simbol en una column por primera vez
                    {
                        Table[row, column] = simbol;
                        permitir = 7;
                        break;
                        
                    }
                    else if (number == column.ToString() && value != null)
                    {
                        int i = 0;

                        while (permitir == 1 && i < 7)
                        {
                            if ((row - i) < 1)
                            {
                                permitir = 7;
                            }

                            if (Table[row - i, column] == null && permitir == 1)
                            {
                                Table[row - i, column] = simbol;
                                permitir = 7;
                            }

                            i++;

                        }

                    }
                }

            }

            //imprimir table
            for (int row = 0; row < 7; row++)
            {

                for (int column = 0; column < 7; column++)
                {
                    Console.Write(Table[row, column] + " | ");
                }

                Console.WriteLine("\n ");
            }

            //validar jugada
            if (validar_ganador("x", userone) != "0")
            {
                cleartable();

                return "exit";
            }

            if (validar_ganador("0", usertwo) != "0")
            {
                cleartable();

                return "exit";
            }

            return "next";

        }

        //---------Fn MasterMaind

        static string get_key_random(string key) {

            string keyfinal = "";
            char[] key_array =  new char[key.Length];
            int i = 0;
            while (keyfinal.Length < key.Length)
            {
                 Random rnd = new Random();
                                // int month = rnd.Next(1, 13); 
                char val = key[rnd.Next(0, key.Length)];
                if (!key_array.Contains(val))
                {
                    keyfinal += val.ToString();
                    key_array[i] = val;
                    i++;
                }
            }

            return keyfinal;
        }
 

//-end


static void Main(string[] args)
        {
            
            string option = "!0";

            while (option != "exit")
            {
                Console.WriteLine("Senati Game");
                
                Console.WriteLine("1.Jugar");
                Console.WriteLine("2.Desarrollador");

                Console.Write("Ingresa una opción: ");
                option = Console.ReadLine();

                if (option == "1")
                {
                    string option_one = "0";

                    while (option_one != "exit")
                    {
                        Console.WriteLine("-----------------");
                        Console.WriteLine("Games");
                        Console.WriteLine("1.Cuatro en Raya");
                        Console.WriteLine("2.MasterMind");
                        Console.WriteLine("3.Return");

                        Console.Write("Ingrese una opción: ");
                        option_one = Console.ReadLine();

                        switch (option_one)
                        {
                            case "1": // 4 en raya
                                string option_two = "0";

                                while (option_two != "exit")
                                {
                                    Console.WriteLine("-----------------");
                                    Console.WriteLine("Game Cuatro en Raya");
                                    Console.WriteLine("1.Jugar");
                                    Console.WriteLine("2.Puntajes.");
                                    Console.WriteLine("3.Return");

                                    Console.Write("Enter your option: ");
                                     option_two = Console.ReadLine();

                                    switch (option_two)
                                    {
                                        case "3":
                                            option_two = "exit";
                                            break;
                                        case "2":
                                            //puntajes
                                            Console.WriteLine(ListPuntaje);                                           
                                            break;

                                        case "1":
                                            //4 in line 
                                            Console.Write("Enter UserName One (is X): ");
                                            userone = Console.ReadLine(); // x

                                            Console.Write("Enter UserName Two (is 0): ");
                                            usertwo = Console.ReadLine(); // 0

                                            Console.WriteLine("Play¡¡¡: ");


                                            imprimir_table("");
                                            string number = "a";
                                            while (number != "exit")
                                            {
                                                string user = (turno == 0) ? usertwo : userone;

                                                Console.Write(user + " ingresa un valor entre 1 and 7 : ");

                                                 number = Console.ReadLine();

                                                try
                                                {
                                                    if ( Convert.ToInt32(number) > 0 && Convert.ToInt32(number) < 8)
                                                    {
                                                        number = (Convert.ToInt32(number) - 1).ToString(); // el sistema funciona con valores de 0 a 6
                                                        //establecer el turno
                                                        turno = (turno == 0) ? 1 : 0;

                                                        string simbol = (turno == 0) ? "x" : "0";
                                                        switch (simbol)
                                                        {
                                                            case "x":
                                                                puntone++;
                                                                break;
                                                            case "0":
                                                                punttwo++;
                                                                break;
                                                            default:
                                                                break;
                                                        }

                                                        number = imprimir_table(number, simbol);
                                                    }
                                                }
                                                catch (Exception)
                                                {
                                                    //el valor no es un número
                                                    Console.WriteLine("El valor ingresado no es un número");

                                                }
                                            }

                                            break;
                                        default:
                                            break;

                                    }
                                }

                                break; //--en Cuatro en rayy
                            case "2":  //MasterMind

                                //RBRG
                                string valores_key = "RABNM";
                                string valor_key_random = get_key_random(valores_key);
                                 option_two = "0";
                               
                                while (option_two != "exit")
                                {
                                    Console.WriteLine("-----------------");
                                    Console.WriteLine("Game MasterMind ");
                                    Console.WriteLine("1.Jugar");
                                    Console.WriteLine("2.Puntajes.");
                                    Console.WriteLine("3.Return");

                                    Console.Write("Enter your option: ");
                                    option_two = Console.ReadLine();

                                    switch (option_two)
                                    {
                                        case "3":
                                            option_two = "exit";
                                            break;
                                        case "2":
                                            //puntajes
                                            Console.WriteLine(ListPuntaje);
                                            break;

                                        case "1":
                                            //4 in line 
                                            Console.Write("Enter UserName: ");
                                            userone = Console.ReadLine(); // x
                                            Console.WriteLine("Play¡¡¡: ");

                                            string number = "next";
                                            while (number != "exit")
                                            {
                                                Console.Write(userone + " ingresa un valor correcto : ");

                                                number = Console.ReadLine();

                                                if ( number == valor_key_random)
                                                {
                                                    //Win LOL¡¡¡
                                                    Console.WriteLine(userone + " has descubierto la respuesta. Felicidades¡¡ ");

                                                }
                                                else
                                                {
                                                    //generar respuesta no correcta, pero con pistas
                                                    String response = "";
                                                    for (int i = 0; i < number.Length ; i++) {
                                                        if (number.Substring(i,1)== valor_key_random.Substring(i,1)) {
                                                            response += "0";
                                                        }
                                                        else if(valor_key_random.Contains(number.Substring(i,1))   ) {
                                                            response += "x";
                                                        }else {
                                                            response += "-";
                                                        }
                                                        
                                                    }
                                                Console.WriteLine(response );

                                                    
                                                }

                                            }

                                            break;
                                        default:
                                            break;

                                    }
                                }



                                break;//--end MasterMind
                            case "3":
                                option_one = "exit";
                                break;
                            default:
                                break;
                        }


                    }

                }
                else if (option == "2")
                {
                    Console.WriteLine("Hello, Esta app está desarrollada por Lizana De La O");
                    Console.WriteLine("Presione cualquier tecla para volver al menú. ");
                    Console.ReadKey();
                    Console.WriteLine("");

                }

            }

            Console.WriteLine("Bye");
            Console.ReadKey();

        }
    }
}
