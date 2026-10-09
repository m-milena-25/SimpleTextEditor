using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextEditor
{
    class Dokument
    {
        string imeF;
        string text;

        public Dokument(string ime)
        {imeF=ime;}
        public Dokument()
        { }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public string ImeF
        {
            get { return ImeF; }
            set { imeF = value; }
        }

     

        public void Save()
        {
            StreamWriter sw = new StreamWriter(imeF,true);
            sw.Write(text);
            sw.Close();
           
        }

        public void Open()
        {
            text = "";
            StreamReader sr = new StreamReader(imeF,true);
            text = sr.ReadToEnd();
            sr.Close();
        }
        public void zameni_rec_za_rec(string s1, string s2)
        {
              text.Replace(s1,s2);
        }

        public int Br_reci()
        {
            string[] niz = text.Split(' ');
            return niz.Length;
        }

        

    }
}
