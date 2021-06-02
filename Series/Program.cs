using System;

namespace Series
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {
            string userOption = TakeUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch(userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSerie();
                        break;
                    case "3":
                        UpdateSerie();
                        break;
                    case "4":
                        DeleteSerie();
                        break;
                    case "5":
                        ShowSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = TakeUserOption();
            }
            Console.WriteLine("Thank you for using our Services.");
            Console.ReadLine();
        }

        private static void ShowSerie()
        {
            Console.WriteLine("Show specific serie");

            Console.Write("Type the serie id: ");
            int selectedId = int.Parse(Console.ReadLine());

            repository.ReturnById(selectedId);
        }

        private static void DeleteSerie()
        {
            Console.WriteLine("Delete Serie");

            Console.Write("Type the serie id to delete: ");
            int selectedId = int.Parse(Console.ReadLine());

            repository.Delete(selectedId);
        }

        private static void UpdateSerie()
        {
            Console.WriteLine("Uptade serie");

            Console.Write("Type the ID Serie");
            int selectedId = int.Parse(Console.ReadLine());

            Console.WriteLine("Inset new serie");

            foreach(int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }
            
            Console.Write("Select a genre: ");
            int selectedGenre = int.Parse(Console.ReadLine());

            Console.Write("Type the serie's title: ");
            string selectedTitle = Console.ReadLine();

            Console.Write("Type the series's description: ");
            string selectedDescription = Console.ReadLine();

            Console.WriteLine("Type the relase year: ");
            int selectedyear = int.Parse(Console.ReadLine());

            Serie updatedSerie = new Serie(id: selectedId,
                                       genre: (Genre)selectedGenre,
                                       title: selectedTitle,
                                       description: selectedDescription,
                                       year: selectedyear);

            repository.Update(selectedId, updatedSerie);
        }

        private static void InsertSerie()
        {
            
            Console.WriteLine("Inset new serie");

            foreach(int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }
            
            Console.Write("Select a genre: ");
            int selectedGenre = int.Parse(Console.ReadLine());

            Console.Write("Type the serie's title: ");
            string selectedTitle = Console.ReadLine();

            Console.Write("Type the series's description: ");
            string selectedDescription = Console.ReadLine();

            Console.WriteLine("Type the relase year: ");
            int selectedyear = int.Parse(Console.ReadLine());

            Serie newserie = new Serie(id: repository.NextId(),
                                       genre: (Genre)selectedGenre,
                                       title: selectedTitle,
                                       description: selectedDescription,
                                       year: selectedyear);

            repository.Insert(newserie);
        }

        private static void ListSeries()
        {
            Console.WriteLine("List Series");

            var list = repository.List();

            if(list.Count == 0)
            {
                Console.WriteLine("No serie available");
                return;
            }

            foreach(var serie in list)
            {
                Console.WriteLine("#Id {0}: {1}  {2}", serie.getId(), serie.getTitle(),(serie.getIsDeleted() ? "*Excluido*" : ""));
            }
            
        }

        private static string TakeUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("How can I help you?");
            Console.WriteLine("Chose the desire option:");

            Console.WriteLine("1 - List series");
            Console.WriteLine("2 - Insert new serie");
            Console.WriteLine("3 - Update serie");
            Console.WriteLine("4 - Delete serie");
            Console.WriteLine("5 - Show specific serie");
            Console.WriteLine("C - Clear the screen");
            Console.WriteLine("X - Exit");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
