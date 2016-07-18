using System;
using System.Windows.Forms;
using System.Runtime.Serialization.Json;
using System.Text;

namespace JsonParse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ParseBtn_Click(object sender, EventArgs e)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Person));
            string fileContent=System.IO.File.ReadAllText("json.txt");
            Person person = (Person)json.ReadObject(new System.IO.MemoryStream(Encoding.Unicode.GetBytes(fileContent)));
            FNameLbl.Text = person.FirstName;
            LNameLbl.Text = person.LastName;
            PhonesLbl.Text = string.Join(", ", person.PersonPhones);
            StreetLbl.Text = person.PersonAddress.StreetAddress;
            CityLbl.Text = person.PersonAddress.City;
            PostalLbl.Text = person.PersonAddress.Postal.ToString();
        }
    }
}

