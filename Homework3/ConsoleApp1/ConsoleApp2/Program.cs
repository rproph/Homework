using System.IO;
using System;
using System.Text.Json;

namespace ConsoleApp2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };

            try
            {
                string json = File.ReadAllText("info.json");
                var shopData = JsonSerializer.Deserialize<Shop>(json, options);
                //shopData.Shops[1].FindAvailablePhonesCount();

                shopData.MakeBuyRequest();
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("Invalid file path.");
            }
        }
    }
}
