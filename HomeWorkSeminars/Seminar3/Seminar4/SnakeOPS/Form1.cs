using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeOPS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(KeyPressedHandler);
        }

        private void KeyPressedHandler(Object sender, KeyEventArgs args) 
        {
  
            switch (args.ToString()) 
            { 
                case "Right":

                    break;
                case "Left":

                    break;
                case "Up":

                    break;
                case "Down":

                    break;


            }

        }

    }
}
