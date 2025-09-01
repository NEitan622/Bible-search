namespace GUI_UI_PL
{
    public partial class Form1 : Form
    {
        static Queue<string> recentSearches = new Queue<string>();

        public Form1()
        {
            InitializeComponent();
            comboBox1.Visible = false;  
        }


        private void button4_Click(object sender, EventArgs e)
        {
      
            Queue<string> temp = new Queue<string>();

            List<DTO_Common_Enteties.PasukTora> li = Bll_services.Searches.GetLocationWord(search.Text);
            textBox1.Clear();
            moreSearch.BackColor = Color.White;
            moreSearch.Clear();
            string nulls = "מילה זו אינה מופיעה בתורה";
            string allResults = "";
            if (li.Count > 0)
            {


                for (int i = 0; i < li.Count; i++)
                {
                    allResults += "\r\n";
                    allResults += li[i].Book + "/" + li[i].Parasha + "/" + li[i].Perek + "'/" + li[i].Pasuk + "\r\n" + '"' + li[i].Text + '"' + "\r\n";

                }
                comboBox1.Visible = true;
                if (recentSearches.Count() >= 2)
                {
                    comboBox1.Items.Remove(recentSearches.Dequeue());
                }
                if (!recentSearches.Contains(search.Text))
                {
                    recentSearches.Enqueue(search.Text);
                        comboBox1.Items.Add(search.Text); 
                }
                
              
               

                textBox1.Text = allResults;
      
                textBox1.ScrollToCaret();
            }
            else
            {
                textBox1.Text = nulls;
            }
         


        }

       


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            moreSearch.BackColor = Color.MintCream;
            search.BackColor = Color.White;
            search.Clear();
            List<DTO_Common_Enteties.PasukTora> li = Bll_services.Searches.GetLocationFullWord(moreSearch.Text);
            string allResults = "";

            for (int i = 0; i < li.Count; i++)
            {
                allResults += "\r\n";
                allResults += li[i].Book + " " + li[i].Parasha + " " + li[i].Perek + "' " + li[i].Pasuk + "\r\n" + '"' + li[i].Text + '"' + "\r\n";

            }
            textBox1.Text = allResults;
         
            textBox1.ScrollToCaret();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox1.Text = DalRepository.TextFiles.OpenTanachFile();
        }

      

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           search.Text=comboBox1.GetItemText(comboBox1.SelectedItem.ToString());
            button4_Click(sender, e);
        }

      

        private void search_TextChanged(object sender, EventArgs e)
        {
            search.BackColor = Color.MintCream;
        }
    }
}