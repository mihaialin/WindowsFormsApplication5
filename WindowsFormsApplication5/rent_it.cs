using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class rent_it : Form
    {
        public rent_it()
        {
            InitializeComponent();
        }
      
        private void rent_it_Load(object sender, EventArgs e)
        {
            Form1 F1 = new Form1();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.vehicleList[Form1.selectedCar].setVacant(false);
            rent_it.ActiveForm.Close();
        }
    }
}
