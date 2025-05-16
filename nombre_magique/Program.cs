internal class Program
{
    static int DemanderNombre(int min, int max)
    {
        
        int nombre = min - 1;
        while (!(nombre >= min && nombre <= max))
        {
            Console.Write("Rentrez un nombre entre " + min + " et " + max + " : ");
            string? nombreStr = Console.ReadLine();

            //Il faut gérer les nullables avec Console.WriteLine
            if (string.IsNullOrWhiteSpace(nombreStr))
            {
                Console.WriteLine("ERREUR : entrée vide ou invalide");
                continue;
            }
            //Après qu'on soit sûre que nombreStr n'est pas null on peut essayer de le parser
            try
            {
                nombre = int.Parse(nombreStr.Trim());
                if (!(nombre >= min && nombre <= max))
                {
                    Console.WriteLine("Le nombre doit être entre " + min + " et " + max);
                    nombre = 0; 
                }
            }
            catch
            {
                Console.WriteLine("ERREUR : ce nombre n'est pas valide");
            }
        }
        return nombre;
    }
    private static void Main(string[] args)
    {
        Random rand = new Random();
        const int NOMBRE_MIN = 1;
        const int NOMBRE_MAX = 10;
        int NOMBRE_MAGIQUE = rand.Next(NOMBRE_MIN, NOMBRE_MAX + 1);
        int nbVies = 4;
        int nombre = NOMBRE_MAGIQUE + 1;

        while (nbVies > 0)
        {
            Console.WriteLine();
            Console.WriteLine("Nombre de vies restantes : " + nbVies);
            nombre = DemanderNombre(NOMBRE_MIN, NOMBRE_MAX);
            if (nombre < NOMBRE_MAGIQUE)
            {
                Console.WriteLine("Le nombre magique est plus grand");
            }
            else if (nombre > NOMBRE_MAGIQUE)
            {
                Console.WriteLine("Le nombre magique est plus petit");
            } else 
            {
                Console.WriteLine("Bravo, vous avez trouvé le nombre magique");
                break;
            }
            nbVies--;
        }

        if (nbVies == 0)
        {
            Console.WriteLine("\nVous avez perdu, le nombre magique était " + NOMBRE_MAGIQUE);
        }
    }
}