using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp26
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0";
        }

        const int WIDTH = 800; //En
        const int HEIGHT = 600; //Boy

        string filepath = ""; // Kaynak Dosya Yolu
        string destpath =""; //Hedef Dosya Yolu
        int fileCounter = 0; //Klasördeki Dosya Sayacı
        int progress = 0; //İlerleme(değiştirilen dosya sayısı)
        int i = 0; int j = 0;
        Bitmap changed;
        string tempPath;
        FileInfo[] fi;
        private void button2_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(filepath);
            fi = di.GetFiles();
            j = fi.Length;
            if(textBox1.Text != "") progress = Convert.ToInt32(textBox1.Text);
            //Klasördeki tüm dosyaları dolaşır.
            i = 0;
            done = false;
            timer1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            MessageBox.Show("Kaynak Dosya Yolunu Seçiniz:");
            fbd.ShowDialog();
            filepath = fbd.SelectedPath;
            label1.Text = "Kaynak Dosya Yolu: " + filepath;

            MessageBox.Show("Hedef Dosya Yolunu Seçiniz:");
            fbd.ShowDialog();
            destpath = fbd.SelectedPath;
            label4.Text = "Hedef Dosya Konumu: " + destpath;

            DirectoryInfo di = new DirectoryInfo(filepath);
            FileInfo[] fi = di.GetFiles();
            fileCounter = fi.Length;
            label2.Text = "Dosya Sayısı: " + fileCounter.ToString();
            di = null;
            fi = null;
        }

        bool done = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i < j)
            {

                try
                {
                    tempPath = filepath + "\\" + fi[i].Name; //Sıradaki dosyanın dosya yolu.
                                                             //çözünürlüğü değiştirilmiş resim
                    changed = new Bitmap(new Bitmap(tempPath), WIDTH, HEIGHT); //Çöznürlüğü değiştirilmiş resim.
                    label5.Text = "İşlenen Dosya Sayısı: " + progress.ToString();
                    changed.Save(destpath + "\\" + progress.ToString() + ".jpg");
                    progress++;

                }
                catch(Exception ex)
                {
                    richTextBox1.AppendText(ex.ToString());
                    GC.Collect();
                }
                i++;
            }
            else if(!done)
            {
                GC.Collect(); MessageBox.Show("İşlem Tamamlandı!");
                timer1.Enabled = false;
                done = true;
            }
        }

      
    }
}
