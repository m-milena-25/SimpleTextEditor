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


namespace TextEditor
{
    public partial class Form1 : Form
    {
        //Dokument novi=new Dokument();
        Dokument novi=new Dokument(); 

        public Form1()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) //pravi novi dokument
        {
            richTextBox1.Clear(); novi = new Dokument();
            textBox1.Text = "0";
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)//otvara vec postojeci dokument
        {
            openFileDialog1.Title = "Izaberi fajl";
            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = "Text Files(.txt)|*.txt|All Files(.)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string ime = openFileDialog1.FileName;
                    novi.ImeF = "";
                    novi.ImeF = ime;
                    novi.Open();
                    richTextBox1.Text = novi.Text;

                    /*  StreamReader sr = new StreamReader(openFileDialog1.FileName);
                       richTextBox1.Text = sr.ReadToEnd();
                       sr.Close();*/
                    textBox1.Text = novi.Br_reci().ToString();
                }
                catch (Exception greska)
                { MessageBox.Show(greska.Message); }
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)//cuva novi dokument
        {
           saveFileDialog1.Title = "Sacuvaj svoj dokument";
            saveFileDialog1.Filter = "Text Files(.txt)|*.txt|Rich text file|*rtf|WordDocument|*.docx";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ime = saveFileDialog1.FileName;
                novi.ImeF = "";
                novi.ImeF=ime;
                
                novi.Text = richTextBox1.Text;
                
                novi.Save();
                /*StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                sw.Write(richTextBox1.Text);
                sw.Close();*/
                textBox1.Text = novi.Br_reci().ToString();
            }
        
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            saveFileDialog1.Title = "Sacuvaj svoj dokument";
            saveFileDialog1.Filter = "All Files(.)|*.*|Text Files(.txt)|*.txt";
            
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            { 
               string ime = saveFileDialog1.FileName;
               novi.ImeF = "";
               novi.ImeF = ime;
               novi.Text = "";
                novi.Text = richTextBox1.Text;

                novi.Save();
                textBox1.Text = novi.Br_reci().ToString();
                /*StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                sw.Write(richTextBox1.Text);
                sw.Close();*/
            }
            else throw new Exception("ne");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dobro dosli u SimpleTextEditor. Imate mogucnosti da cuvate, obradjujete, otvarate i doradjujete razna dokumenta. Sve je slicno Microsoft-ovom Word-u.");                                        //ispisi ukratko uputstvo
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor=colorDialog1.Color;
            }
        }

        private void fontStyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;
            }
        }

        

       

       

      
       
       


    }
}
