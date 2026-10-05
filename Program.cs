
/*
* Filnamn: Program.cs
* Författare: Emma Heikkinen
* Datum: 2026-09-22
* Kurs: Programmering i C#.NET DT071G
* 
* Beskrivning:
* En konsolappplikation i form av en gästbok där användaren kan
lägga till och ta bort inlägg samt avsluta applikationen.
*/

namespace Guestbooks
{
    class GuestBookProgram
    {
        static void Main(string[] args)
        {
            Guestbook guestbook = new Guestbook();      //Nytt GuestBook-objekt

            while (true)                                //While-loop 
            {

                Console.Clear();

                //Själva startsidan för gästboken:

                Console.WriteLine("Välkommen till GÄSTBOKEN <3");
                Console.WriteLine();

                int index = 1;
                foreach (GuestPost post in guestbook.GetPosts())
                {
                    Console.WriteLine("[" + index++ + "] " + post.Name + " har skrivit: ");
                    Console.WriteLine(post.Post);
                    Console.WriteLine();
                }

                Console.WriteLine("1. Lägg till post.");
                Console.WriteLine("2. Ta bort post.");
                Console.WriteLine("3. Lämna gästboken.");
                Console.WriteLine();


                //Vad vill användaren göra?
                Console.Write("Vad vill du göra? ");
                string? choice = Console.ReadLine();

                if (choice != "1" && choice != "2" && choice != "3")        //Startsida visas om annat än 1-3 anges
                {
                    continue;
                }
                else
                {

                    switch (choice)
                    {

                        //Val 1 - Lägga till ett inlägg
                        case "1":
                            Console.Clear();

                            Console.WriteLine("Inlägg med tomma fält publiceras inte.");    //Varning till användaren, inga tomma fält
                            Console.WriteLine();

                            //FÖr användaren att fylla i
                            Console.Write("Vad heter du?: ");
                            string? nameAnswer = Console.ReadLine();

                            Console.Write("Ditt meddelande: ");
                            string? postAnswer = Console.ReadLine();

                            //Skickas till "startsidan" om fält missats
                            if (string.IsNullOrEmpty(nameAnswer) || string.IsNullOrEmpty(postAnswer))
                            {
                                continue;
                            }

                            guestbook.AddPost(nameAnswer, postAnswer);      //Inlägg läggs till
                            break;


                        //Val 2 - Ta bort ett inlägg utifrån index
                        case "2":

                            //Rensa konsollen, men visa inlägg som finns att radera
                            Console.Clear();
                            int ind = 1;
                            foreach (GuestPost post in guestbook.GetPosts())
                            {
                                Console.WriteLine("[" + ind++ + "] " + post.Name + " har skrivit: ");
                                Console.WriteLine(post.Post);
                                Console.WriteLine();
                            }

                            Console.Write("Ange vilket inlägg vill du radera: ");
                            string? indexAnswer = Console.ReadLine();

                            if (string.IsNullOrEmpty(indexAnswer))   //Tillbaka till start om inget anges
                            {
                                continue;
                            }

                            //Prova att ta bort inlägg
                            try
                            {
                                int fixedIndex = Convert.ToInt32(indexAnswer) - 1;      //-1 för rätt index
                                guestbook.DelPost(Convert.ToInt32(fixedIndex));
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Fel uppstod, prova igen senare. Tryck enter.");  //Om något blir fel
                                Console.ReadKey();
                            }
                            break;


                        //Val 3 - Avsluta
                        case "3":
                            Environment.Exit(0);        //Avsluta programmet direkt
                            break;
                    }

                }

            }
        }
    }
}
