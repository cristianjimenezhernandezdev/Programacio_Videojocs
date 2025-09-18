using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int FILES = 3;
            const int COLUMNES = 3;
            int min = 0;
            int max = 2;
            int buit = 0;
            int i, j;
            int[,] matriu1 = new int[FILES, COLUMNES];

            for (i = 0; i < FILES; i++)
            {
                for (j = 0; j < COLUMNES; ++j)
                    matriu1[i, j] = buit;
            }
            Console.WriteLine("La Matriu és: ");//mostra la matriu
            for (i = 0; i < FILES; i++)
            {
                for (j = 0; j < COLUMNES; ++j)
                {
                    Console.Write(matriu1[i, j] + " ");
                }

                if (i == FILES - 1 && j == 2)
                {
                    Console.Write("");
                }
                else
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine("Jugador 1");
            Console.WriteLine("fila");
            int X= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("columna");  
            int Y= Convert.ToInt32(Console.ReadLine());
            matriu1[X, Y] = 1;//assigna el valor 1 a la posició X,Y


            Console.WriteLine("La Matriu és: ");//mostra la matriu
            for (i = 0; i < FILES; i++)
            {
                for (j = 0; j < COLUMNES; ++j)
                {
                    Console.Write(matriu1[i, j] + " ");
                }

                if (i == FILES - 1 && j == 2)
                {
                    Console.Write("");
                }
                else
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Jugador 2");
            Console.WriteLine("fila");
            X = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("columna");
            Y = Convert.ToInt32(Console.ReadLine());
            matriu1[X, Y] = 2;//assigna el valor 1 a la posició X,Y
            Console.WriteLine("La Matriu és: ");//mostra la matriu
            for (i = 0; i < FILES; i++)
            {
                for (j = 0; j < COLUMNES; ++j)
                {
                    Console.Write(matriu1[i, j] + " ");
                }

                if (i == FILES - 1 && j == 2)
                {
                    Console.Write("");
                }
                else
                {
                    Console.WriteLine();
                }
            }

            /*for (i = 0; i < FILES; i++) // Comptar per separat els positius i negatius i fent la suma al contador
            {
                for (j = 0; j < COLUMNES; j++)
                {
                    if (matriu1[i, j] > 0)
                        contpos++;
                    else if (matriu1[i, j] < 0)
                        contneg++;
                }
            }
            percpos = (contpos * 100.0) / total;
            perneg = (contneg * 100.0) / total;

            Console.WriteLine();
            Console.WriteLine("Percentatge de nombres positius: {0}", percpos);
            Console.WriteLine("Percentatge de nombres negatius: {0}", perneg);*/
        }
    }
    }

