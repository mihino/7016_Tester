using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ADC_tester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            /*
            while (serialPort1.BytesToRead > 0)
            {
                int ch = serialPort1.ReadChar();
                String response = Convert.ToString((char)ch) + " " + Convert.ToString(ch) +"\n";
                this.textBox1.AppendText(response.Replace("\r", "\n"));
            }
            
            while (serialPort1.BytesToRead > 0)
            {
                byte[] data = new byte[serialPort1.BytesToRead];
                serialPort1.Read(data, 0, data.Length);
                //String response = serialPort1.ReadExisting();
                String response = Encoding.UTF8.GetString(data);
                this.textBox1.AppendText(response.Replace("\r", "\n"));
                System.Threading.Thread.Sleep(50);
            }
             */
            String response = serialPort1.ReadExisting();
            this.textBox1.AppendText(response.Replace("\r", "\n"));
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            try
            {
                serialPort1.ReadExisting();
                serialPort1.Write("#012" + "\r");
               
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.buttonOpen.Text = "Open COM " + this.numericUpDown1.Value;
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            this.serialPort1.Close();
            this.serialPort1.PortName = "COM" + this.numericUpDown1.Value;
            try
            {
                this.serialPort1.Open();
                this.buttonOpen.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception excep)
            {
                this.buttonOpen.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show(excep.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Write("#$01332" + "\r");
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Write("$012" + "\r");
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                
                serialPort1.Write("$01F" + "\r");
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                
                serialPort1.Write("$01M" + "\r");
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

                serialPort1.Write("$016" + "\r");
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {

                serialPort1.Write("$017+05.000" + "\r");
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {

                serialPort1.Write("$017+00.000" + "\r");
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            button9.Text = "$017+0" + numericUpDown2.Value +".000";
                   }

        private void button9_Click(object sender, EventArgs e)
        {
            
            try
            {

                serialPort1.Write("$017+0" + numericUpDown2.Value + ".000" + "\r");
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text.Trim();
            button10.Text = textBox2.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
             try
            {

                serialPort1.Write(textBox2.Text + "\r");
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        
        }
    }
}
