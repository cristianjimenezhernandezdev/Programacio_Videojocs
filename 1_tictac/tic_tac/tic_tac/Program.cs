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
            int X = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("columna");
            int Y = Convert.ToInt32(Console.ReadLine());
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

            /*
            
             
            int torn=1;
            do
            {
            - Gestio torn--------
            Per canviar de torn
              if (torn == 1)
               { torn = 2;}
                else { torn = 1; }
            - Mostrar matriu--------
            - Demanar posicions tirada--------
            - comprovar validesa tirada
            - gurdar tirada a tauler
              matriu1[X, Y] = torn;//assigna el valor 1 a la posició X,Y
            - comprovar si has guanyat
             hi ha 8 maneres possibles de guanyar
            if (matriu[0,0]==matriu[0,1]&& matriu[0,1]==matriu[0,2] && matriu[0,0]!=0)||
                guanyador=true;
           
            tiradas++;
            } while (torn < 9 && !guanyador);
             */


        }
        static int CanviTorn(int torn)
        {
            if (torn == 1)
            { torn = 2; }
            else { torn = 1; }
            return torn;
        }
        static void MostraMatriu(int[,] matriu)
        {
            for (int i = 0; i < matriu.GetLength(0); i++)
            {
                for (int j = 0; j < matriu.GetLength(1); j++)
                {
                    Console.Write(matriu[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void DemanaPosicio(int torn, out int X, out int Y)
        {
            Console.WriteLine("Jugador " + torn);
            Console.WriteLine("fila");
            X = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("columna");
            Y = Convert.ToInt32(Console.ReadLine());
        }
        static void guardaTirada(int[,] matriu, int X, int Y, int torn)
        {
            matriu[X, Y] = torn;//assigna el valor 1 a la posició X,Y
        }
    }
}

