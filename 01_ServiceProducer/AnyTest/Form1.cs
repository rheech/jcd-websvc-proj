using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using libwebsvcprod;

namespace AnyTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GoogleSuggester suggester = new GoogleSuggester();
            suggester.GetSuggestionsList("Hello World");
        }
    }
}
