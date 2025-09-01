namespace DalRepository
{
    public class TextFiles
    {

        public static string OpenTanachFile()
        {
           
            //return  File.ReadAllText(Application.StartupPath + "/Tanach.txt");
            return File.ReadAllText(@"C:\הנדסאים\שנה ב\C#\TanachProject\DalRepository\bin\Debug\net6.0\tora.txt");
          
            

        }
    }
}