using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace WindowsFormsApplication5
{



    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static vehicle[] vehicleList = new vehicle[20];
        public static int selectedCar = 0;
        public static int x;

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            System.Media.SoundPlayer player = new System.Media.SoundPlayer((@"C:\Facultate\poze_masini\sunet.wav"));
            player.Play();
            rent.Hide();
            searchOption.SelectedIndex = 0;
            string fileName = @"C:\Facultate\cars.data";
            string myExeDir = ((new FileInfo(System.Reflection.Assembly.GetEntryAssembly().Location)).Directory).ToString();
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            carName.Text = "";
            //System.Windows.Forms.MessageBox.Show("tada");

            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(fs);

            for (int i = 0; i < 20; i++)
            {
                vehicleList[i] = new vehicle();
                vehicleList[i].setMake(r.ReadString());
                vehicleList[i].setModel(r.ReadString());
                vehicleList[i].setVIN(r.ReadString());
                vehicleList[i].setEngine(r.ReadDouble());
                vehicleList[i].setYear(r.ReadInt32());
                vehicleList[i].setGas(r.ReadInt32());
                vehicleList[i].setVacant(r.ReadBoolean());
                vehicleList[i].setObs(r.ReadString());
                vehicleList[i].setMilage(r.ReadString());
                vehicleList[i].setPrice(r.ReadInt32());
                vehicleList[i].setImage(r.ReadString());
                //resultList.Items.Add(vehicleList[i].getMake());
            }



            r.Close();
            fs.Close();






        }

        public class clients { 
            private String name;
            private String cnp;
            private String rent_no;
            private int cars;

            public string getName() {
                return name;
            }
            public string getCNP() {
                return cnp;
            }
            public string getRent() {
                return rent_no;
            }
            public int getCars() {
                return cars;
            }
            public void setName(string x) {
                name = x;
            }
            public void setCnp(string x) {
                cnp = x;
            }
            public void setRent(string x) {
                rent_no = x;
            }
            public void setCars(int x) { 
                cars = x;
            }
            

        }

        public class vehicle
        {
            private String make;
            private String model;
            private String vin;
            private double engine_size;
            private int manufacturing_year;
            private int gas_cunsumption;
            private bool vacant;
            private String observations;
            private String milage;
            private int price;
            private string image;


            public String getMake()
            {
                return make;
            }
            public String getModel()
            {
                return model;
            }
            public String getVIN()
            {
                return vin;
            }
            public double getEngine()
            {
                return engine_size;
            }
            public int getYear()
            {
                return manufacturing_year;
            }
            public int getGas()
            {
                return gas_cunsumption;
            }
            public bool getVacant()
            {
                return vacant;
            }
            public string getObs()
            {
                return observations;
            }
            public string getMilage()
            {
                return milage;
            }
            public int getPrice()
            {
                return price;
            }
            public String getImage()
            {
                return image;
            }

            public void setImage(string x)
            {
                image = x;
            }
            public void setMake(string x)
            {
                make = x;
            }
            public void setModel(string x)
            {
                model = x;
            }
            public void setVIN(string x)
            {
                vin = x;
            }
            public void setEngine(double x)
            {
                engine_size = x;
            }
            public void setYear(int x)
            {
                manufacturing_year = x;
            }
            public void setGas(int x)
            {
                gas_cunsumption = x;
            }
            public void setVacant(bool x)
            {
                vacant = x;
            }
            public void setObs(string x)
            {
                observations = x;
            }
            public void setMilage(string x)
            {
                milage = x;
            }
            public void setPrice(int x)
            {
                price = x;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            rent.Hide();

            if (searchOption.SelectedIndex == 1)
            {
                listBox1.Items.Clear();
                for (int i = 0; i < 13; i++)
                {
                    if (vehicleList[i].getPrice() <= Convert.ToInt32(searchBox.Text))
                    {
                       
                        
                        listBox1.Items.Add(vehicleList[i].getMake() + "  " + vehicleList[i].getModel());
                    }


                }
            }

            if (searchOption.SelectedIndex == 0)
            {
                listBox1.Items.Clear();
                for (int i = 0; i < 13; i++)
                {
                    if ((vehicleList[i].getMake() + "  " + vehicleList[i].getModel()).Contains(searchBox.Text))
                    {


                        listBox1.Items.Add(vehicleList[i].getMake() + "  " + vehicleList[i].getModel());
                    }


                }
            }
            if (searchOption.SelectedIndex == 2)
            {
                listBox1.Items.Clear();
                for (int i = 0; i < 13; i++)
                {
                    if (vehicleList[i].getGas() <= Convert.ToInt32(searchBox.Text))
                    {


                        listBox1.Items.Add(vehicleList[i].getMake() + "  " + vehicleList[i].getModel());
                    }


                }
            }

        }
        public void displayCar(string x) {
            for(int i = 0;i<13;i++){
                if ((vehicleList[i].getMake() + "  " + vehicleList[i].getModel()) == x) {
                    carName.Text = vehicleList[i].getMake() + "  " + vehicleList[i].getModel();
                    selectedCar = i;
                    Image image = Image.FromFile(@"C:\Facultate\poze_masini\" + vehicleList[i].getImage() + ".png");
                    pictureBox1.Image = image;

                    label1.Text = "Consum: " + vehicleList[i].getGas().ToString() + " l/100km";
                    label2.Text = "Pret: " + vehicleList[i].getPrice().ToString() + " euro/zi";
                    label3.Text = "Cilindree: " + vehicleList[i].getEngine().ToString() + " litri";
                    label4.Text = "Detalii: " + vehicleList[i].getObs().ToString();


                    if (vehicleList[i].getObs().ToString() == "Chick magnet")
                    {
                        Color redColor = Color.FromArgb(255, 0, 0); ;
                        label4.ForeColor = redColor;
                    }
                    else {
                        Color redColor = Color.FromArgb(0, 0, 0); ;
                        label4.ForeColor = redColor;
                    }
                    if (vehicleList[i].getVacant())
                    {
                        label5.Text = "Disponibila: Da";
                    }
                    else {
                        label5.Text = "Disponibila: Nu";
                    }

                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayCar(listBox1.SelectedItem.ToString());

            rent.Show();
        }

        private void rent_Click(object sender, EventArgs e)
        {
            rent_it f = new rent_it();
            f.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x++;
            if (x % 2 == 1)
            {
                pictureBox2.Visible = false;
            }
            else {
                pictureBox2.Visible = true;
            }
        }
    }
}
