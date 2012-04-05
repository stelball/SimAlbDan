using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Inloggning
{
    class Program
    {
        static void Main(string[] args)
        {
            //DickMTF'er

            bool loop = true;
            List<string> användarnamn = new List<string>();
            List<string> lösenord = new List<string>();
            string användarNamn;
            string lösenOrd;
            int försök = 0;
            int val;
            int användare;

            #region FileRead
            if (File.Exists("Användare"))
            {
                TextReader textR = new StreamReader("Användare");
                användare = int.Parse(textR.ReadLine());
                for (int i = 0; i < användare; i++)
                {
                    användarnamn.Add(textR.ReadLine());
                }
                textR.Close();
            }
            if (File.Exists("Lösenord"))
            {
                TextReader textR = new StreamReader("Lösenord");
                användare = int.Parse(textR.ReadLine());
                for (int i = 0; i < användare; i++)
                {
                    lösenord.Add(textR.ReadLine());
                }
                textR.Close();
            }
            #endregion

            try
            {
                #region Kolla namn mot lista, inloggad se alternativ lista, inte inloggad gör om
                loop = true;
                while (loop)
                {
                    Console.WriteLine("#################################################\n#################################################");

                    Console.Write("\n1 = Skapa användare\n2 = Logga in\nVal: ");
                    val = int.Parse(Console.ReadLine());

                    Console.Write("\nAnvändarnamn: ");
                    användarNamn = Console.ReadLine();
                    Console.Write("Lösenord: ");
                    lösenOrd = Console.ReadLine();

                    #region add
                    if (val == 1)
                    {
                        //add users
                        if (användarNamn != "" && !användarNamn.Contains(" "))
                        {
                            användarnamn.Add(användarNamn);
                            lösenord.Add(lösenOrd);

                            Console.WriteLine("Användare skapad!");
                        }
                        else
                        {
                            Console.WriteLine("Användarnamnet får ej innehålla mellanslag eller vara tomt!");
                        }
                    }
                    #endregion

                    #region logga in
                    else if (val == 2)
                    {
                        //logga in
                        for (int i = 0; i < användarnamn.Count; i++)
                        {
                            if (användarNamn == användarnamn[i] && lösenOrd == lösenord[i])
                            {
                                försök = 0;
                                bool inloggad = true;                                
                                Console.WriteLine("\nVälkommen {0}!", användarNamn);
                                while (inloggad)
                                {
                                    Console.Write("\nVälj ett av nedanstående alternativ:\n1 = Lägg till Användare\n2 = Lista användare\n3 = Ta bort användare\n4 = Spela Random\n5 = Logga ut\n6 = Avsluta\nVal: ");
                                    val = int.Parse(Console.ReadLine());

                                    if (val == 1 || val == 3)
                                    {
                                        Console.Write("\nAnvändarnamn: ");
                                        användarNamn = Console.ReadLine();
                                        Console.Write("Lösenord: ");
                                        lösenOrd = Console.ReadLine();

                                        #region add
                                        if (val == 1)
                                        {
                                            //add users
                                            if (användarNamn != "" && !användarNamn.Contains(" "))
                                            {
                                                användarnamn.Add(användarNamn);
                                                lösenord.Add(lösenOrd);

                                                Console.WriteLine("Användare skapad!");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Användarnamnet får ej innehålla mellanslag eller vara tomt!");
                                            }
                                        }
                                        #endregion                                        

                                        #region del
                                        else if (val == 3)
                                        {
                                            //del users
                                            if (användarNamn != "" || användarNamn.Contains(" "))
                                            {
                                                användarnamn.Remove(användarNamn);
                                                lösenord.Remove(lösenOrd);

                                                Console.WriteLine("Användare raderad!");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Användarnamnet får ej innehålla mellanslag eller vara tomt!");
                                            }
                                        }
                                        #endregion
                                    }

                                    #region list
                                    else if (val == 2)
                                    {
                                        Console.WriteLine("");
                                        //list users
                                        for (int ini = 0; ini < användarnamn.Count; ini++)
                                        {
                                            Console.WriteLine("{0}\tAcc: {1}\tPW: {2}", ini + 1, användarnamn[ini], lösenord[ini]);
                                        }
                                    }
                                    #endregion

                                    #region Game
                                    else if (val == 4)
                                    {
                                        Random random = new Random();
                                        int talx = random.Next(101);

                                        for (int ior = 0; ior < 1000; ior++)
                                        {
                                            Console.Write("\nGissa ett tal mellan 0-100!\nGissning: ");
                                            val = int.Parse(Console.ReadLine());

                                            if (Random(val, talx) == 0)
                                            {
                                                Console.WriteLine("Rätt!\nDet tog {0} försök!", ior + 1);
                                                loop = false;
                                            }

                                            else if (Random(val, talx) == 1)
                                            {
                                                Console.WriteLine("Högre!");
                                            }

                                            else if (Random(val, talx) == 2)
                                            {
                                                Console.WriteLine("Lägre!");
                                            }

                                            else if (Random(val, talx) == 10)
                                            {
                                                Console.WriteLine("Talet måste vara mellan 0-100");
                                            }
                                        }
                                    }
                                    #endregion

                                    else if (val == 5)
                                        inloggad = false;

                                    else if (val == 6)
                                    {
                                        inloggad = false;
                                        loop = false;
                                    }

                                    else
                                        Console.WriteLine("Du måste skriva siffran för ditt val!");
                                }
                            }
                        }
                        försök++;
                        Console.WriteLine("\nFeeel! Gör om.");
                        if (försök == 3)
                        {
                            Console.WriteLine("\nFeeel tre gånger... programmet låses!");
                            försök = 0;
                            loop = false;
                        }
                    }
                    #endregion

                    Console.WriteLine("\n#################################################\n#################################################");
                    Console.WriteLine("Tryck på en tangent för att fortsätta!");
                    Console.ReadKey();
                    Console.Clear();
                }
                #endregion
            }
            catch
            {
                Console.WriteLine("Ett fel uppstod!");
                Console.WriteLine("Tryck på en tangent för att fortsätta!");
                Console.ReadKey();
            }

            #region FileWrite
            TextWriter textWA = new StreamWriter("Användare");
            textWA.WriteLine(användarnamn.Count);
            for (int i = 0; i < användarnamn.Count; i++)
            {
                textWA.WriteLine(användarnamn[i]);
            }
            textWA.Close();

            TextWriter textWL = new StreamWriter("Lösenord");
            textWL.WriteLine(lösenord.Count);
            for (int i = 0; i < lösenord.Count; i++)
            {
                textWL.WriteLine(lösenord[i]);
            }
            textWL.Close();
            #endregion
        }

        static int Random(int gissning, int random)
        {
            int svar = 10;

            if (gissning == random)
            {
                svar = 0;
                return svar;
            }

            else if (gissning < random && gissning >= 0)
            {
                svar = 1;
                return svar;
            }

            else if (gissning > random && gissning <= 100)
            {
                svar = 2;
                return svar;
            }

            return svar;
        }
    }
}