namespace WebApiSignalR
{
    public class FileHelper
    {
        public static void Write(double data)
        {
            File.WriteAllText("data.txt", data.ToString());
        }

        public static double Read()
        {
            return double.Parse(File.ReadAllText("data.txt"));
        }
    }
}
