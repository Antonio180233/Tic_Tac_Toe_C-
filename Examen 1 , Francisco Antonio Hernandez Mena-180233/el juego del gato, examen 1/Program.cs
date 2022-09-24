/*
 * Created by SharpDevelop.
 * User: Antonio Hernández
 * Date: 2/26/2021
 * Time: 12:44 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

using System.Threading;
 

namespace TIC_TAC_TOE

{

    class Program

    {

        //Generando arreglo

        //Por default se le asignan posiciones nombradas del cero al nueve 

        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        static int player = 1; //Por defaul inicia el jugador uno, asignando a la variable player

        static int choice; //se toma la eleccion del jugador para marcar en el tablero 

 
 

        static int flag = 0;

 

        static void Main(string[] args)

        {

            do

            {

                Console.Clear();// siempre se limpiara la pantalla para imprimir el nuevo tablero

                Console.WriteLine("Jugador 1:X Y Jugador 2:O");
               
                Console.WriteLine("\n");

                if (player % 2 == 0)//checando la oportunidad del jugador

                {

                    Console.WriteLine("Oportunidad del jugador 2");

                }

                else

                {

                    Console.WriteLine("Oportunidad del jugador 1");

                }

                Console.WriteLine("\n");

                Board();// llamando la funcion tablero
                  Console.WriteLine("Ingrese la posicion donde quiere mover:");
                choice = int.Parse(Console.ReadLine());//Leyendo la opcion hacia donde se quiere mover el usuario
                //Condiciones para evitar caida del juego porque el usuario meta datos incorrectos
                if (choice>9||choice<1){
                	Console.WriteLine("Ingrese un valor menor o igual a  9 e igual o mayor a 1");
                	 choice = int.Parse(Console.ReadLine());//Leyendo la opcion hacia donde se quiere mover el usuario
                }
 

                // checando si la posicion donde se quiere poner el usuario esta marcada con (X or O)

                if (arr[choice] != 'X' && arr[choice] != 'O')

                {

                    if (player % 2 == 0) 

                    {

                        arr[choice] = 'O';

                        player++;

                    }

                    else

                    {

                        arr[choice] = 'X';

                        player++;

                    }

                }


                else //mensaje para cuando el jugador esta en una celda ocupada
                {

                    Console.WriteLine("Error row {0} esta marcada con {1}", choice, arr[choice]);

                    Console.WriteLine("\n");

                    Console.WriteLine("Espere 5 segundos y vuelva a intentar.....");

                    Thread.Sleep(5000);

                }

                flag = CheckWin();// llamada para checar si hay ganador (Funcion checkwin)

            } while (flag != 1 && flag != -1);//el programa corre hasta que todas las celdas de los arreglos esten llenas y haya o no ganador 

 

            Console.Clear();// limpieza de consola 

            Board();

 

            if (flag == 1)// si la bandera tiene un valor de 1 ,entonces tenemos un ganador

            {

                Console.WriteLine("El jugador  {0} ha ganado!!!", (player % 2) + 1);

            }

            else//si el valor de la bandera es -1 , hay un empate

            {

                Console.WriteLine("***EMPATE***");

            }

            Console.ReadLine();

        }

      //tablero

        private static void Board()

        {

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);

            Console.WriteLine("     |     |      ");

        }

 

        //Funcion para saber si alguien ya gano

        private static int CheckWin()

        {

            #region Horzontal Winning Condtion

            //Condicion para ganar en el primer row  

            if (arr[1] == arr[2] && arr[2] == arr[3])

            {

                return 1;

            }

            //condicion para ganar en el segundo  Row   

            else if (arr[4] == arr[5] && arr[5] == arr[6])

            {

                return 1;

            }

            //condicion para ganar en el tercer Row   

            else if (arr[6] == arr[7] && arr[7] == arr[8])

            {

                return 1;

            }

            #endregion

 

            #region vertical Winning Condtion

            //Condiciones para ganar verticalmente     

            else if (arr[1] == arr[4] && arr[4] == arr[7])

            {

                return 1;

            }

         

            else if (arr[2] == arr[5] && arr[5] == arr[8])

            {

                return 1;

            }


            else if (arr[3] == arr[6] && arr[6] == arr[9])

            {

                return 1;

            }

            #endregion

 

            #region Diagonal Winning Condition

            else if (arr[1] == arr[5] && arr[5] == arr[9])

            {

                return 1;

            }

            else if (arr[3] == arr[5] && arr[5] == arr[7])

            {

                return 1;

            }

            #endregion

 

            #region Checking For Draw

        

            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')

            {

                return -1;

            }

            #endregion

 

            else

            {

                return 0;

            }

        }

    }

}  