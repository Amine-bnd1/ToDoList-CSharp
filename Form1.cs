using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoListApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            checkedListBox1.Items.Add(textBox1.Text);
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(checkedListBox1.SelectedIndex != -1)
            {
                checkedListBox1.Items.RemoveAt(checkedListBox1.SelectedIndex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                checkedListBox1.Items.Clear();
                string[] lines = File.ReadAllLines(openFileDialog.FileName);
                foreach(string line in lines)
                {
                    checkedListBox1.Items.Add(line); 
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files|*.txt";
            saveFileDialog.Title = "Save Task List";

            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] tasksToSave = new string[checkedListBox1.Items.Count];
                
                for(int i = 0; i < checkedListBox1.Items.Count; i++) {
                    tasksToSave[i] = checkedListBox1.Items[i].ToString();
                }

                System.IO.File.WriteAllLines(saveFileDialog.FileName, tasksToSave);

                MessageBox.Show("List exported successfully!");
            }



        }
    }  
}
