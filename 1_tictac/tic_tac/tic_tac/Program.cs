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
                guardaTirada(matriu1, X, Y, torn);
                comprovaGuanyador(matriu1, ref guanyador);
                CanviTorn(ref torn);
                tirada++;
            } while (tirada < 9 && !guanyador);
            Console.WriteLine("El Jugador"+ torn+" Ha Guanyat");
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
        static void comprovaGuanyador(int[,] matriu, ref bool guanyador)
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
                guanyador = true;
            }
        }
    }
}

