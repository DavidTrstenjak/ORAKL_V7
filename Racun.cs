using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ORAKL_NIOP
{


    public partial class Racun : Form
    {
        public double ukupnaCijena = 0.0;
        public Racun()
        {
            InitializeComponent();
        }

        private void buttonNatrag_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void Racun_Load(object sender, EventArgs e)
        {

        }

        private void buttonUnesi_Click(object sender, EventArgs e)
        {

            textBox2.Focus();
            XmlDocument doc = new XmlDocument();
            doc.Load("proizvodi.xml");


            XmlNodeList proizvodi = doc.GetElementsByTagName("proizvod");

            foreach (XmlNode proizvod in proizvodi)

            {
                if (proizvod.SelectSingleNode("sifra").InnerText == textBox2.Text)
                {

                    string naziv = proizvod.SelectSingleNode("naziv").InnerText;
                    string cijena = proizvod.SelectSingleNode("cijena").InnerText;

                    textBox1.AppendText(textBox2.Text + "\t" + naziv + "\t" + cijena + "€" + Environment.NewLine);
                    textBox2.Clear();
                    double Cijena =Double.Parse(cijena);

                    ukupnaCijena += Cijena;
                    textBox3.Clear();
                    string krajnjaCijena = ukupnaCijena.ToString("F2");
                    textBox3.AppendText(krajnjaCijena);

                    break;
                }
            }
        }



        private void buttonSlanje_Click(object sender, EventArgs e)
        {
            racun2 form2 = new racun2();
            form2.TextBoxValue = textBox3.Text;
            textBox3.TextChanged += (s, ev) => { form2.TextBoxValue = textBox3.Text; };
            form2.Show();
        }

        public event EventHandler TextBoxValueChanged;

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxValueChanged != null)
                TextBoxValueChanged(this, EventArgs.Empty);
        }
    }
}



        

            
        

        
    

    
    
    

