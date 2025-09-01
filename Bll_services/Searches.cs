using Newtonsoft.Json;


namespace Bll_services
{
    public class Searches
    { 
        static List<DTO_Common_Enteties.Location> l = new List<DTO_Common_Enteties.Location>();
        static string ToraText;
       


        public static List<int> GetIndexWord(string word)
        {
            List<int> l = new List<int>();
            //string s = File.ReadAllText(Application.StartupPath + "/Tanach.txt");
            int place = ToraText.IndexOf(word);
          
                
            while (place > -1)
            {
                l.Add(place);
                place = ToraText.IndexOf(word, place + 1);
            }
            return l;


        }

        public static List<DTO_Common_Enteties.Location> TransTanachTextToLocation()
        {
            l = new List<DTO_Common_Enteties.Location>();

            string[] chumashim = ToraText.Split('$');
            for (int i = 1; i < chumashim.Length; i++)
            {
        
                string[] parashot = chumashim[i].Split('^');
                for (int j = 1; j < parashot.Length; j++)
                {
                    string[] prakim = parashot[j].Split('~');
                    for (int k = 1; k < prakim.Length; k++)
                    {
                        string[] psukim = prakim[k].Split('!');
                        for (int r = 1; r < psukim.Length; r++) {
                            l.Add(new DTO_Common_Enteties.PasukTora
                            {
                                Text = psukim[r].Substring( psukim[r].IndexOf("{") + 5, psukim[r].Substring(psukim[r].IndexOf("{") + 5).IndexOf("\r\n") ),
                                Book = chumashim[i].Substring(chumashim[i].IndexOf("חומש"), chumashim[i].IndexOf('.')),
                                Parasha = parashot[j].Substring(parashot[j].IndexOf("פרשת"), parashot[j].IndexOf('~')-3),
                                Perek = prakim[k].Substring(prakim[k].IndexOf("פרק"),prakim[k].IndexOf("!")-12),
                                Pasuk = psukim[r].Substring(psukim[r].IndexOf("{") + 1, psukim[r].IndexOf(" ") + 1),
                            });
                        }
                    }
                  
                }

            }

            return l;
        }

        public static List<DTO_Common_Enteties.PasukTora> GetLocationWord(string word)
        {
            string jsonTora = File.ReadAllText(@"C:\הנדסאים\שנה ב\C#\TanachProject\DalRepository\bin\Debug\net6.0\tora.json");
            List<DTO_Common_Enteties.PasukTora> l = JsonConvert.DeserializeObject< List < DTO_Common_Enteties.PasukTora>>(jsonTora);
            List<DTO_Common_Enteties.PasukTora> lWord = new List<DTO_Common_Enteties.PasukTora>();
            string[] textArr;
           
            string str = "";
            string temp = "";
            for (int i = 0; i < l.Count(); i++)
            {
                str = l[i].Text;
                textArr= l[i].Text.Split(' ');
             
                string s = l[i].Text.Substring(l[i].Text.LastIndexOf(" ")+1);
                Console.WriteLine(s);
                foreach (string v in textArr) { 
                if (v.Equals(word) &&!lWord.Contains(l[i])&&str!=temp)
                {
                    lWord.Add(l[i]);
                }}
            
                temp = str;
            }

            return lWord;
        }
        public static List<DTO_Common_Enteties.PasukTora> GetLocationFullWord(string word)
        {
            string jsonTora = File.ReadAllText(@"C:\הנדסאים\שנה ב\C#\TanachProject\DalRepository\bin\Debug\net6.0\tora.json");
            List<DTO_Common_Enteties.PasukTora> l = JsonConvert.DeserializeObject<List<DTO_Common_Enteties.PasukTora>>(jsonTora);
            List<DTO_Common_Enteties.PasukTora> lWord = new List<DTO_Common_Enteties.PasukTora>();
            string[] textArr;
          
            for (int i = 0; i < l.Count(); i++)
            {
          
                textArr = l[i].Text.Split(' ');
               
                string s = l[i].Text.Substring(l[i].Text.LastIndexOf(" ") + 1);
               
                foreach (string v in textArr)
                {
                    
                    if (v.Contains(word) && !lWord.Contains(l[i]))
                    {
                        lWord.Add(l[i]);
                    }
                }
              
            }

            return lWord;
          
        }
   
        
        public static List<DTO_Common_Enteties.PasukTora> GmatryWord(string word)
        {
            List<DTO_Common_Enteties.PasukTora> lWord = new List<DTO_Common_Enteties.PasukTora>();

            return lWord;
        }
        static Searches()
        {
            ToraText = File.ReadAllText(DalRepository.TextFiles.OpenTanachFile());

            ToraText = DalRepository.TextFiles.OpenTanachFile();
            File.ReadAllText(@"C:\הנדסאים\שנה ב\C#\TanachProject\DalRepository\bin\Debug\net6.0\tora.txt");
            l = TransTanachTextToLocation();
            string strJson = JsonConvert.SerializeObject(l);
            StreamWriter tora = new StreamWriter(@"C:\הנדסאים\שנה ב\C#\TanachProject\DalRepository\bin\Debug\net6.0\tora.json");
            tora.WriteLine(strJson);
            tora.Close();

        }

    }



    }

