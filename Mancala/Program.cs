// See https://aka.ms/new-console-template for more information

using System.Collections;

int[] PiedrasCasillas = new int[12] { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };

int turno = 1;

int puntosJugador1 = 0;
int puntosJugador2 = 0;

string opcion = "LARRY";
int casilla = 0;

while (puntosJugador1 < 25 || puntosJugador2 < 25)
{
    
    if(opcion == "" || opcion == null)
    {
        Console.WriteLine("Ingresó un valor incorrecto, repita por favor");
    }
    else
    {
        if(opcion == "LARRY")
        {
            Console.WriteLine("Bienvenido!");
        }
        else
        {
            try
            {
                casilla = Convert.ToInt32(opcion);
                casilla--;
                if(casilla > 0 && casilla < 13)
                {
                    Console.WriteLine("Casilla seleccionada "+casilla+".");
                    var piedras = PiedrasCasillas[casilla];
                    PiedrasCasillas[casilla] = 0;
                    if(casilla > 5)
                    {
                        casilla++;
                    }
                    else
                    {
                        casilla--; ;
                    }
                    for (int i = 1; i <= piedras; i++)
                    {
                        if(casilla < 6)
                        {
                            if (casilla == -1)
                            {
                                Puntos();
                                casilla = 6;
                            }
                            else
                            {
                                if (PiedrasCasillas[casilla] == 0)
                                    Puntos(PiedrasCasillas[Equivalente(casilla)] + 1);
                                else
                                    PiedrasCasillas[casilla]++;
                                casilla--;
                                if (i == piedras)
                                {
                                    turno = turno == 1 ? 2 : 1;
                                }
                            }
                        }
                        else
                        {
                            if(casilla == 12)
                            {
                                Puntos();
                                casilla = 5;
                            }
                            else
                            {
                                if (PiedrasCasillas[casilla] == 0)
                                    Puntos(PiedrasCasillas[Equivalente(casilla)] + 1);
                                else
                                    PiedrasCasillas[casilla]++;
                                casilla++;
                                if (i == piedras)
                                {
                                    turno = turno == 1 ? 2 : 1;
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("La casilla "+casilla+" no existe o ¿qué juego piensa que es este?");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ingresó un valor incorrecto, repita por favor");
            }
        }
        
    }
    Console.WriteLine(@"¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
    Console.WriteLine(@"  MANCALA! Es el turno del jugador " + turno);
    Console.WriteLine(@"_________________________________________________________________________");
    Console.WriteLine(@" Jugador 2     C01     C02     C03     C04     C05     C06     Jugador 1 ");
    Console.WriteLine(@" /¯¯¯¯¯¯\     /¯¯¯\   /¯¯¯\   /¯¯¯\   /¯¯¯\   /¯¯¯\   /¯¯¯\     /¯¯¯¯¯¯\ ");
    Console.WriteLine(@"/        \   |  " + ValidarPiedras(PiedrasCasillas[0]) + " | |  " + ValidarPiedras(PiedrasCasillas[1]) + " | |  " + ValidarPiedras(PiedrasCasillas[2]) + " | |  " + ValidarPiedras(PiedrasCasillas[3]) + " | |  " + ValidarPiedras(PiedrasCasillas[4]) + " | |  " + ValidarPiedras(PiedrasCasillas[5]) + @" |   /        \");
    Console.WriteLine(@"|        |    \___/   \___/   \___/   \___/   \___/   \___/    |        |");
    Console.WriteLine(@"|   "+ValidarPiedras(puntosJugador2)+"   |     ___     ___     ___     ___     ___     ___     |   "+ValidarPiedras(puntosJugador1) +"   |");
    Console.WriteLine(@"|        |    /   \   /   \   /   \   /   \   /   \   /   \    |        |");
    Console.WriteLine(@"\        /   |  " + ValidarPiedras(PiedrasCasillas[6]) + " | |  " + ValidarPiedras(PiedrasCasillas[7]) + " | |  " + ValidarPiedras(PiedrasCasillas[8]) + " | |  " + ValidarPiedras(PiedrasCasillas[9]) + " | |  " + ValidarPiedras(PiedrasCasillas[10]) + " | |  " + ValidarPiedras(PiedrasCasillas[11]) + @" |   \        /");
    Console.WriteLine(@" \______/     \___/   \___/   \___/   \___/   \___/   \___/     \______/ ");
    Console.WriteLine(@"               C07     C08     C09     C10     C11     C12               ");
    Console.WriteLine(@"¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
    
    Console.Write("Casilla a Jugar (ingrese número): ");
    opcion = Console.ReadLine();
    Console.Clear();
}


string ValidarPiedras(int piedras)
{
    if (piedras > 9)
        return piedras.ToString();
    return "0" + piedras;
}

void Puntos(int puntos = 1)
{
    if (turno == 1)
        puntosJugador1 += puntos;
    else
        puntosJugador2 += puntos;
}

int Equivalente(int casilla)
{
    return casilla switch
    {
        0 => 6,
        1 => 7,
        2 => 8,
        3 => 9,
        4 => 10,
        5 => 11,
        6 => 0,
        7 => 1,
        8 => 2,
        9 => 3,
        10 => 4,
        _ => 5,
    };
}