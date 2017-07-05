using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace _20170705Aufgabe
{
    class Text
    {
        private string _Inhalt;
        public string Inhalt
        {
            get { return _Inhalt; }
            set { _Inhalt = value; }
        }

        private string _Dateiname;
        public string Dateiname
        {
            get { return _Dateiname; }
            set { _Dateiname = value; }
        }

        private string _PFadangabe;
        public string Pfadangabe
        {
            get { return _PFadangabe; }
            set { _PFadangabe = value; }
        }
        
        public Text(string Inhalt, string Dateiname)
        {
            this.Inhalt = Inhalt;
            this.Dateiname = Dateiname;
        }

        public string TextLesen()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Alle Dateien(*.*)|*.*|Textdateien(*.txt)|*.txt";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo FileInfo = new FileInfo(ofd.FileName);
                Pfadangabe = FileInfo.DirectoryName.ToString();
                Dateiname = FileInfo.Name;
                Inhalt = File.ReadAllText(Pfadangabe + '\\' + Dateiname);
            }
            else
            {
                Inhalt = "Inhalt konnte nicht gelesen werden, oder Aktion wurde abgebrochen...";
            }

            return Inhalt;
        }

        public int TextSpeichern(string T)
        {
            Inhalt = T;

            using (var sfd = new SaveFileDialog())
            {
                string today = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");

                sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                sfd.FilterIndex = 2;
                sfd.FileName = today;
                sfd.DefaultExt = "txt";
                sfd.AddExtension = true;
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, Inhalt);

                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }
    }
}
