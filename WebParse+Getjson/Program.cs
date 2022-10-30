using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Parse
{
    internal class Program
    {
        HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        { 
            Program program = new Program();
            await program.GetPosts();
        }
        private async Task GetPosts()
        {
            string response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");
            List<Post> posts = JsonConvert.DeserializeObject<List<Post>>(response);
            foreach (var item in posts)
            {
                if (item.userId == 2)
                {
                    Console.WriteLine($"{item.title}\n");
                }
            }
        }
    }
}
