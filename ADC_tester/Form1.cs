using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;
using System.Threading.Tasks;

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
            comboBoxPorts.Items.Clear();

            // Get the updated list of ports
            string[] ports = SerialPort.GetPortNames();

            // Populate ComboBox
            foreach (string port in ports)
            {
                comboBoxPorts.Items.Add(port);
            }

            // Select the first port if available
            if (comboBoxPorts.Items.Count > 0)
            {
                comboBoxPorts.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No serial ports found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                String response = serialPort1.ReadExisting();
                this.Invoke((MethodInvoker)delegate
                {
                    textBox1.AppendText(response.Replace("\r", "") + Environment.NewLine);
                });
            }
            catch (Exception ex)
            {
                // Safely show error message on the UI thread
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show($"Error reading serial port: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
            }
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

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            this.serialPort1.Close();
            this.serialPort1.PortName = comboBoxPorts.SelectedItem.ToString();
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
            button9.Text = "$017+0" + numericUpDown2.Value + ".000";
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

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                "Are you sure?",
                "Confirmation",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    serialPort1.Write("%0102080680" + "\r");
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Write("#02" + "\r");
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Write("$022" + "\r");
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void buttonListPorts_Click(object sender, EventArgs e)
        {
            // Get the updated list of ports
            string[] ports = SerialPort.GetPortNames();
            // Populate ComboBox
            foreach (string port in ports)
            {
                textBox1.AppendText(port + Environment.NewLine);
                //BasicText.AppendText(ports[i] + (i < ports.Length - 1 ? Environment.NewLine : ""));
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                String command = button15.Text;
                serialPort1.Write(command + "\r");
                this.Invoke((MethodInvoker)delegate
                {
                    textBox1.AppendText($"Sent: {command}" + Environment.NewLine);
                });
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                String command = "ADR 6";
                serialPort1.Write(command + "\r");
                this.Invoke((MethodInvoker)delegate
                {
                    textBox1.AppendText($"Sent: {command}" + Environment.NewLine);
                });

            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                String command = button17.Text;
                serialPort1.Write(command + "\r");
                this.Invoke((MethodInvoker)delegate
                {
                    textBox1.AppendText($"Sent: {command}" + Environment.NewLine);
                });
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                String command = button18.Text;
                serialPort1.Write(command + "\r");
                this.Invoke((MethodInvoker)delegate
                {
                    textBox1.AppendText($"Sent: {command}" + Environment.NewLine);
                });
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }


        private async void button19_Click(object sender, EventArgs e)
        {
            try
            {
                button19.Enabled = false;
                for (int i = 1; i <= 8; i++)
                {
                    string command = "#0" + i ;
                    serialPort1.Write(command + "\r");
                    this.Invoke((MethodInvoker)delegate
                    {
                        textBox1.AppendText($"Sent: {command}" + Environment.NewLine);
                    });
                    // Wait for 500ms between commands (adjust delay as needed)
                    await Task.Delay(500);
                }
                // Re-enable the button
                this.Invoke((MethodInvoker)delegate
                {
                    button19.Enabled = true;
                });
            }
            catch (Exception ex)
            {
                // Re-enable the button and show error
                this.Invoke((MethodInvoker)delegate
                {
                    button19.Enabled = true;
                    MessageBox.Show($"Error sending commands: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text.Trim();
            button20.Text = textBox3.Text;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                String command = button20.Text;
                serialPort1.Write(command + "\r");
                this.Invoke((MethodInvoker)delegate
                {
                    textBox1.AppendText($"Sent: {command}" + Environment.NewLine);
                });
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }

}