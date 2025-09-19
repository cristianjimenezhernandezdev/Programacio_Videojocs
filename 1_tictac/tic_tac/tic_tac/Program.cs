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
        // Punt d'entrada del programa
        static void Main(string[] args)
        {
            // Variables globals del joc
            int buit = 0;                    // Valor que representa una casella buida
            int[,] matriu1 = new int[3, 3];  // Taulell 3x3 guardat com matriu d'enters
            int tirada = 0;                  // Comptador de tirades efectuades
            bool guanyador = false;          // Flag per indicar si ja hi ha un guanyador
            int torn = 1;                    // Torn actual: 1 = jugador 1, 2 = jugador 2 / IA
            int X, Y;                        // Coordenades introduïdes o triades
            int sortir = 0;                  // Flag per sortir del menú principal
            int opcio;                       // Opció escollida pel jugador al menú

            // Bucle principal del menú que permet jugar repetidament fins que l'usuari surt
            do 
            {
                // Inicialitza l'estat del joc per cada partida
                opcio = 0;
                tirada = 0;
                torn = 1;
                guanyador = false;

                EmplenarMatriu(matriu1, buit); // Omple la matriu amb zeros (caselles buides)

                // Mostra el menú principal i llegeix l'opció de l'usuari
                Console.WriteLine("Benvingut al joc del tres en ratlla");
                Console.WriteLine("1. VS Player");
                Console.WriteLine("2. VS IA");
                Console.WriteLine("3. EXIT");
                Console.WriteLine("OPCIO: ");
                opcio = Convert.ToInt32(Console.ReadLine());

                if (opcio == 1)
                {
                    // Modo 2 jugadors (local)
                    do
                    {
                        MostraMatriu(matriu1); // Mostra el taulell actual
                        DemanaPosicio(torn, out X, out Y); // Demana la posició al jugador actual

                        // Si la posició està ocupada, torna a preguntar fins que sigui vàlida
                        do
                        {
                            if (!EspaiEsBuit(matriu1, X, Y))
                            {
                                Console.WriteLine($"La posició X: {X} i Y: {Y} ja esta ocupada introdueix una altre.");
                                Console.WriteLine();
                                Console.WriteLine("Taulell Actual");
                                MostraMatriu(matriu1);
                                DemanaPosicio(torn, out X, out Y);
                            }
                        } while (!EspaiEsBuit(matriu1, X, Y)); // Comprova si l'espai està buit

                        guardaTirada(matriu1, X, Y, torn); // Guarda la tirada del jugador a la matriu

                        // Comprova si la tirada ha creat un guany
                        if (HihaGuanyador(matriu1))
                        {
                            guanyador = true;
                            Console.WriteLine("El Jugador" + torn + " Ha Guanyat"); // Mostra el guanyador
                        }

                        CanviTorn(ref torn); // Passa el torn al següent jugador
                        tirada++;
                    } while (tirada < 9 && !guanyador); // Continua fins que s'acabin les tirades o hi hagi guanyador

                    // Si s'han esgotat les tirades i no hi ha guanyador, és empat
                    if (!guanyador && tirada == 9)
                        Console.WriteLine("Empat");
                }
                else if (opcio == 2)
                {
                    // Modo jugador vs IA (IA mou aleatòriament caselles buides)
                    do
                    {
                        MostraMatriu(matriu1); // Mostra el taulell actual

                        if (torn == 1)
                        {
                            // Torn del jugador humà: demana posició i valida que estigui buida
                            DemanaPosicio(torn, out X, out Y);

                            while (!EspaiEsBuit(matriu1, X, Y))
                            {
                                Console.WriteLine($"La posició X: {X}, Y: {Y} ja està ocupada, introdueix una altre.");
                                MostraMatriu(matriu1);
                                DemanaPosicio(torn, out X, out Y);
                            }
                        }
                        else
                        {
                            // Torn de la IA: tria aleatòriament una casella buida
                            IA(matriu1, out X, out Y);
                            Console.WriteLine($"La IA tria la posició X: {X}, Y: {Y}");
                        }

                        guardaTirada(matriu1, X, Y, torn); // Guarda la tirada de qui sigui el torn

                        // Comprova si la tirada ha creat un guany
                        if (HihaGuanyador(matriu1))
                        {
                            guanyador = true;

                            if (torn == 1)
                                Console.WriteLine("El Jugador ha guanyat!");
                            else
                                Console.WriteLine("La IA ha guanyat!");
                            break; // Surt del bucle de partida
                        }

                        CanviTorn(ref torn); // Canvia el torn
                        tirada++;

                    } while (tirada < 9 && !guanyador);

                    if (!guanyador && tirada == 9)
                        Console.WriteLine("Empat");


                }
                else if (opcio == 3)
                {
                    // L'usuari ha escollit sortir del programa
                    sortir = 1;
                }
                else
                {
                    // Opció no vàlida al menú
                    Console.WriteLine("Opció no vàlida");
                }
            }while (sortir != 1);
        }
        //---------------------------Metodes---------------------------

        // Omple la matriu amb el valor de buit (inicialitza el taulell a zeros)
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

        // Canvia el torn entre jugador 1 i 2 (funció auxiliar que modifica el paràmetre per referència)
        static int CanviTorn(ref int torn)
        {
            if (torn == 1)
                torn = 2;
            else
                torn = 1;
            return torn;
        }

        // Mostra el taulell per pantalla en format senzill
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

        // Demana la posició al jugador actual. Valida que el valor estigui entre 1 i 3.
        // Retorna les coordenades en X (fila) i Y (columna) per mitjà de 'out'.
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

        // Guarda la tirada del jugador a la matriu (resta 1 perquè l'usuari introdueix valors 1..3)
        static void guardaTirada(int[,] matriu, int X, int Y, int torn)
        {
            matriu[X-1, Y-1] = torn;// assigna el valor del jugador a la posició X,Y
        }

        // Comprova totes les línies possibles per veure si hi ha tres en ratlla
        // Retorna true si algun jugador ha guanyat
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

        // Comprova si una casella de la matriu està buida (valor 0)
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

        // Generador aleatori utilitzat per la IA
        static readonly Random RNG = new Random();

        // IA molt simple que selecciona una casella buida aleatòriament
        static void IA(int[,] matriu, out int X, out int Y)
        {
            do
            {
                X = RNG.Next(1, 4); // valor entre 1 i 3 (fila)
                Y = RNG.Next(1, 4); // valor entre 1 i 3 (columna)
            } while (!EspaiEsBuit(matriu, X, Y)); // repeteix fins trobar una casella buida
        }

    }
}

