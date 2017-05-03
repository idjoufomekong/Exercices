using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FormXML
{
    public partial class Form1 : Form
    {
        private XDocument doc;
        public Form1()
        {
            InitializeComponent();
            button1.Click += Button1_Click;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            doc = XDocument.Load(@"..\..\CollectionsBD.xml");
            listBox1.DataSource = DAL.GetTitreAlbumsAn60(doc);
            DAL.AjouterAuteurDabere(doc);
            DAL.AjouterAlbum(doc);
            DAL.MajAlbum15(doc);
            dataGridView1.DataSource = DAL.DeserialiserLinq();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
    }
}
