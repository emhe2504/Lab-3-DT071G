using System.Text.Json;

namespace Guestbooks
{
    public class Guestbook
    {
        private string postfile = "guestbook.json";     //namnet på filen som ska användas
        private List<GuestPost> posts = new List<GuestPost>();      //ny lista för GuestPost-objekt

        //Kontruktor
        public Guestbook()
        {
            if(File.Exists(postfile) == true)   //om fil med namnet guestbook.json finns
            {
                string jsonString = File.ReadAllText(postfile); //Lagra all text i filen i denna variabel
                //jsonString --> görs till lista med GuestPost-objekt --> läggs i posts
                posts = JsonSerializer.Deserialize<List<GuestPost>>(jsonString)!;
            }
        }

        //Metod för lägga till post
        public void AddPost(string name, string post)
        {
            GuestPost newpost = new GuestPost();    //Skapa nytt GuestPost-objekt
            newpost.Name = name;                    //Värdet i name till property Name
            newpost.Post = post;                    //Värdet i post till property Post
            posts.Add(newpost);                     //Lägg till nya objektet i listan
            saveToJson();                           //Uppdatera och spara JSON-fil
        }

        //Metod för att radera post
        public void DelPost(int index)
        {
            posts.RemoveAt(index);                  //Radera GuestPost-objekt efter angivet index
            saveToJson();                           //Uppdatera och spara JSON-fil
        }

        //Metod för att hämta alla poster
        public List<GuestPost> GetPosts()
        {
            return posts;
        }

        //Metod för att uppdatera och spara JSON-fil
        private void saveToJson()
        {
            var jsonString = JsonSerializer.Serialize(posts);       //gör posts-lista till json
            File.WriteAllText(postfile, jsonString);                //Skriv jsonString i postfile
        }
    }
}