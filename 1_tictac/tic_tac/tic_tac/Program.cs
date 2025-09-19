using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace tic_tac
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int buit = 0;
            int[,] matriu1 = new int[3, 3];
            int tirada = 0;
            bool guanyador = false;
            int torn = 1;
            int X, Y;
            EmplenarMatriu(matriu1, buit);
            do
            {
                MostraMatriu(matriu1);
                DemanaPosicio(torn, out X, out Y);
                do {
                    if (!EspaiEsBuit(matriu1, X, Y))
                    {
                        Console.WriteLine($"La posició X: {X} i Y: {Y} ja esta ocupada introdueix una altre.");
                        Console.WriteLine();
                        Console.WriteLine("Taulell Actual");
                        MostraMatriu(matriu1);                        
                        DemanaPosicio(torn, out X, out Y);                        
                    }
                } while (!EspaiEsBuit(matriu1, X, Y));
                guardaTirada(matriu1, X, Y, torn);
                if (HihaGuanyador(matriu1))
                {
                    guanyador = true;
                    Console.WriteLine("El Jugador" + torn + " Ha Guanyat");
                }
                CanviTorn(ref torn);
                tirada++;
            } while (tirada < 9 && !guanyador);
            
           


        }
        static void EmplenarMatriu(int[,] matriu, int buit)
        {
            for (int i = 0; i < matriu.GetLength(0); i++)
            {
                for (int j = 0; j < matriu.GetLength(1); j++)
                {
                    matriu[i, j] = buit;
                }
            }
        }
        static int CanviTorn(ref int torn)
        {
            if (torn == 1)
                torn = 2;
            else
                torn = 1;
            return torn;

        }
        static void MostraMatriu(int[,] matriu)
        {
            for (int i = 0; i < matriu.GetLength(0); i++)
            {
                Console.Write("|");
                for (int j = 0; j < matriu.GetLength(1); j++)
                {
                    Console.Write(matriu[i, j]+ "|");
                }
                Console.WriteLine();
            }
        }
        static void DemanaPosicio(int torn, out int X, out int Y)
        {
            Console.WriteLine("Jugador " + torn);
            do
            {
                Console.WriteLine("Fila:");
                X = Convert.ToInt32(Console.ReadLine());
                if (X < 1 || X > 3)
                {
                    Console.WriteLine("Valor fora de rang, Escriu un numero entre 1 i 3");
                }
            } while (X < 1 || X > 3);
            do
            {
                Console.WriteLine("Columna:");
                Y = Convert.ToInt32(Console.ReadLine());
                if (Y < 1 || Y > 3)
                {
                    Console.WriteLine("Valor fora de rang, Escriu un numero entre 1 i 3");
                }
            } while (Y < 1 || Y > 3);
        }
        static void guardaTirada(int[,] matriu, int X, int Y, int torn)
        {
            matriu[X-1, Y-1] = torn;//assigna el valor 1 a la posició X,Y
        }
        static bool HihaGuanyador(int[,] matriu)
        {
            if ((matriu[0, 0] == matriu[0, 1] && matriu[0, 1] == matriu[0, 2] && matriu[0, 0] != 0) ||
                (matriu[1, 0] == matriu[1, 1] && matriu[1, 1] == matriu[1, 2] && matriu[1, 0] != 0) ||
                (matriu[2, 0] == matriu[2, 1] && matriu[2, 1] == matriu[2, 2] && matriu[2, 0] != 0) ||
                (matriu[0, 0] == matriu[1, 0] && matriu[1, 0] == matriu[2, 0] && matriu[0, 0] != 0) ||
                (matriu[0, 1] == matriu[1, 1] && matriu[1, 1] == matriu[2, 1] && matriu[0, 1] != 0) ||
                (matriu[0, 2] == matriu[1, 2] && matriu[1, 2] == matriu[2, 2] && matriu[0, 2] != 0) ||
                (matriu[0, 0] == matriu[1, 1] && matriu[1, 1] == matriu[2, 2] && matriu[0, 0] != 0) ||
                (matriu[0, 2] == matriu[1, 1] && matriu[1, 1] == matriu[2, 0] && matriu[0, 2] != 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        static bool EspaiEsBuit(int[,] matr, int X, int Y)
        {
            if (matr[X - 1, Y - 1] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

