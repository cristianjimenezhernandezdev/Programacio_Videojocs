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
            const int FILES = 4;
            const int COLUMNES = 2;
            int min = -50;
            int max = 50;
            int i, j;
            int[,] matriu1 = new int[FILES, COLUMNES];
            double percpos, perneg;
            int contpos = 0, contneg = 0;
            int total = (FILES * COLUMNES);//les files multiplicat per les columnes son el total per calcular el percentatge

            Random rnd = new Random();

            for (i = 0; i < FILES; i++)
            {
                for (j = 0; j < 2; ++j)
                    matriu1[i, j] = rnd.Next(min, max + 1);
            }
            Console.WriteLine("La Matriu 1 és: ");//mostra la matriu
            for (i = 0; i < FILES; i++)
            {
                for (j = 0; j < 2; ++j)
                {
                    Console.Write(matriu1[i, j] + " ");
                }

                if (i == FILES - 1 && j == 2)
                {
                    Console.Write("");
                }
                else
                {
                    Console.Write(", ");
                }
            }

            for (i = 0; i < FILES; i++) // Comptar per separat els positius i negatius i fent la suma al contador
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
            Console.WriteLine("Percentatge de nombres negatius: {0}", perneg);
        }
    }
    }
}
