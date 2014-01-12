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

namespace WindowsFormsApplication5
{


  
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static vehicle[] vehicleList = new vehicle[20];
        public static int[] searchResultIndex = new int[20];

        private void Form1_Load(object sender, EventArgs e)
        {
            searchOption.SelectedIndex = 0;           
            string fileName = @"C:\Facultate\cars.data";
            FileStream fs1 = new FileStream(fileName, FileMode.Open, FileAccess.Write);
            BinaryWriter r1 = new BinaryWriter(fs1);
            r1.Write("BMW");
            r1.Write("325d");
            r1.Write("KJJG756JHGKHKLK876RERLNJVC32");
            r1.Write(2.5);
            r1.Write(2009);
            r1.Write(20);
            r1.Write(true);
            r1.Write("Nu Porneste");
            r1.Write("109876");
            r1.Write(90);

            r1.Write("BMW");
            r1.Write("530i");
            r1.Write("BMW09878656JHGKHKLK8NJVC32");
            r1.Write(3.0);
            r1.Write(2009);
            r1.Write(20);
            r1.Write(true);
            r1.Write("Are doar 3 roti");
            r1.Write("89876");
            r1.Write(120);

            r1.Write("Opel");
            r1.Write("Insignia");
            r1.Write("AA4756JHGKHKLK876RERLNJVC32");
            r1.Write(1.8);
            r1.Write(2012);
            r1.Write(20);
            r1.Write(true);
            r1.Write("Nu are o usa");
            r1.Write("999876");
            r1.Write(45);

            r1.Write("Aston Martin");
            r1.Write("DB9");
            r1.Write("A570N0006JHGKHKLK876RERLNJVC32");
            r1.Write(6.0);
            r1.Write(2005);
            r1.Write(24);
            r1.Write(true);
            r1.Write("Power. Beauty. Soul.");
            r1.Write("41000");
            r1.Write(450);

            r1.Write("Ferrari");
            r1.Write("FF");
            r1.Write("FFRI0006JHGKHKLK876RERLNJVC32");
            r1.Write(6.3);
            r1.Write(2011);
            r1.Write(30);
            r1.Write(true);
            r1.Write("Forta Rossa Italia");
            r1.Write("41000");
            r1.Write(445);

            r1.Write("Audi");
            r1.Write("A7");
            r1.Write("ADI000N6JHGKHKLK876RERLNJVC32");
            r1.Write(3.5);
            r1.Write(2012);
            r1.Write(8);
            r1.Write(true);
            r1.Write("Vorsprung Durch Technik");
            r1.Write("11000");
            r1.Write(300);

            r1.Write("Porsche");
            r1.Write("Carrera 4S");
            r1.Write("PRSCH0N6JHGKHKLK3256RLN67C32");
            r1.Write(3.8);
            r1.Write(2013);
            r1.Write(9);
            r1.Write(true);
            r1.Write("There Is No Substitute");
            r1.Write("14500");
            r1.Write(350);

            r1.Write("Maseratti");
            r1.Write("GranTursimo Sport");
            r1.Write("MSRT09876389KHKLK3256RLN67C32");
            r1.Write(4.7);
            r1.Write(2013);
            r1.Write(19);
            r1.Write(true);
            r1.Write("Excellence Through Passion");
            r1.Write("64500");
            r1.Write(250);

            r1.Write("Dacia");
            r1.Write("Logan");
            r1.Write("GHFASB3B21UG5BFDKSHE3BFHSDFANBJC");
            r1.Write(1.4);
            r1.Write(2007);
            r1.Write(7);
            r1.Write(true);
            r1.Write("Cheder luneta desprins");
            r1.Write("168000");
            r1.Write(20);


            r1.Write("Renault");
            r1.Write("Clio");
            r1.Write("ASDWQ3V8560321NVHSFGDSG");
            r1.Write(1.6);
            r1.Write(2005);
            r1.Write(7);
            r1.Write(true);
            r1.Write("Subwoofer in portbagaj");
            r1.Write("234000");
            r1.Write(20);


            r1.Write("Fisker");
            r1.Write("Karma");
            r1.Write("KKK666QWERTYUIOP");
            r1.Write(2.0);
            r1.Write(2012);
            r1.Write(4);
            r1.Write(true);
            r1.Write("Doua motoare electrice de 161 cp");
            r1.Write("12000");
            r1.Write(320);

            r1.Write("Ford");
            r1.Write("Fiesta");
            r1.Write("ADT342AFDNGOJIRA54TYVXCB");
            r1.Write(1.4);
            r1.Write(2005);
            r1.Write(5);
            r1.Write(true);
            r1.Write("Interior roz");
            r1.Write("54000");
            r1.Write(30);


            r1.Write("Lada");
            r1.Write("Niva");
            r1.Write("RUSS4RDSVIAAVFG46323T");
            r1.Write(1.6);
            r1.Write(1979);
            r1.Write(12);
            r1.Write(true);
            r1.Write("Chick magnet");
            r1.Write("363000");
            r1.Write(100);

            r1.Close();
            fs1.Close();

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
                //resultList.Items.Add(vehicleList[i].getMake());
            }



            r.Close();
            fs.Close(); 
                   
            
            
         
            

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

            public String getMake() {
                return make;
            }
            public String getModel() {
                return model;
            }
            public String getVIN() {
                return vin;
            }
            public double getEngine() {
                return engine_size;
            }
            public int getYear() {
                return manufacturing_year;
            }
            public int getGas() {
                return gas_cunsumption;
            }
            public bool getVacant() {
                return vacant;
            }
            public string getObs() {
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
            public void setMake(string x) {
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
            public void setMilage(string x) {
                milage = x;
            }
            public void setPrice(int x) {
                price = x;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Array.Clear(searchResultIndex, 0, 20);

            resultList.Items.Clear();
            if (searchOption.SelectedIndex == 1) {
                for (int i = 0; i < 13; i++)
                {
                    if (vehicleList[i].getPrice() <= Convert.ToInt32(searchBox.Text))
                    {
                        resultList.Items.Add(vehicleList[i].getMake() + "  " + vehicleList[i].getModel());
                        searchResultIndex[i] = i;
                    }
                    else
                    {
                        searchResultIndex[i] = 0;
                    }

                }
            }

            if (searchOption.SelectedIndex == 2)
            {
                for (int i = 0; i < 13; i++)
                {
                    if (vehicleList[i].getGas() <= Convert.ToInt32(searchBox.Text))
                    {
                        resultList.Items.Add(vehicleList[i].getMake() + "  " + vehicleList[i].getModel());
                        searchResultIndex[i] = i;
                    }
                    else
                    {
                        searchResultIndex[i] = 0;
                    }

                }
            }

            if (searchOption.SelectedIndex == 0) {
                for (int i = 0; i < 13; i++)
                {
                    if (vehicleList[i].getMake().Contains(searchBox.Text))
                    {
                        resultList.Items.Add(vehicleList[i].getMake() + "  " + vehicleList[i].getModel());
                        searchResultIndex[i] = i;
                    }
                    else
                    {
                        searchResultIndex[i] = 0;
                    }

                }
            }
           
        }
    }
}
