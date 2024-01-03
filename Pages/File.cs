
using System.IO;


namespace Project_DB.Pages
{
    public class File
    {

        public File()
        {

            string writeText = "Hello World!";  // Create a text string
            File.WriteAllText("filename.txt", writeText);  // Create a file and write the content of writeText to it

            string readText = File.ReadAllText("filename.txt");  // Read the contents of the file
            Console.WriteLine(readText);  // Output the content
        }

        private static string ReadAllText(string v)
        {
            throw new NotImplementedException();
        }

        private static void WriteAllText(string v, string writeText)
        {
            throw new NotImplementedException();
        }
    }

    
}

