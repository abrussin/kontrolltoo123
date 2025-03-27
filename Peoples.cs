using System.Threading.Channels;

namespace kontrolltoo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Sisesta tekst, mida soovid salvestada:");
            string userText = Console.ReadLine();

            Console.WriteLine("Sisesta faili salvestamise tee (nt C:\\Temp\\minufail.txt):");
            string filePath = Console.ReadLine();

            SaveTextToFile(userText, filePath);

            Console.WriteLine("Sisesta püramiidi kõrgus: ");
            int height = int.Parse(Console.ReadLine());

            for (int i = 1; i <= height; i++)
            {
                for (int j = 0; j < height - i; j++)
                {
                    Console.Write(" ");
                }

                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j);
                }

                for (int j = i - 1; j >= 1; j--)
                {
                    Console.Write(j);
                }
                Console.WriteLine();
            }
        }
        
        
            
        public static void SaveTextToFile(string text, string path)
        {
            try
            {
                
                File.WriteAllText(path, text);
                Console.WriteLine("Fail salvestatud edukalt: " + path);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Viga faili salvestamisel!");
                Console.WriteLine("Veateade: " + ex.Message);
            }
            Console.WriteLine("Tee valik numbriga: ");

            Console.WriteLine("1. Min LINQ");
            Console.WriteLine("2. GroupJoin");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    MinLINQ();
                    break;

                case "2":
                    GroupJoin();
                    break;

                default:
                    Console.WriteLine("Vale valik");
                    break;

            }
        }

        public static void MinLINQ()
        {
            var youngest = PeopleList.people.OrderBy(p => p.Age).FirstOrDefault();

            if (youngest != null)
            {
                Console.WriteLine($"Kõige noorem inimene on {youngest.Name}, {youngest.Age} aastane.");
            }
            else
            {
                Console.WriteLine("Andmeid ei leitud.");
            }
        }

        public static void GroupJoin()
        {
            var groupedPeople = PeopleList.people
                .GroupBy(p => p.Age < 20 ? "Noored" : "Täiskasvanud");

            Console.WriteLine("\nInimesed on rühmitatud:");

            foreach (var group in groupedPeople)
            {
                Console.WriteLine($"\n{group.Key}:");
                foreach (var person in group)
                {
                    Console.WriteLine($" - {person.Name}, {person.Age} aastat vana");
                }
            }
        }
    }
}

