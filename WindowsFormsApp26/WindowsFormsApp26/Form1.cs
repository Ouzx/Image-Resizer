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
        }

        const int WIDTH = 800; //En
        const int HEIGHT = 600; //Boy

        string filepath = ""; // Kaynak Dosya Yolu
        string destpath =""; //Hedef Dosya Yolu
        int fileCounter = 0; //Klasördeki Dosya Sayacı
        int progress = 0; //İlerleme(değiştirilen dosya sayısı)

        private void button2_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(filepath);
            FileInfo[] fi = di.GetFiles();

            //Klasördeki tüm dosyaları dolaşır.
            for(int i = 0; i < fi.Length; i++)
            {
                string tempPath = filepath +"\\"+ fi[i].Name; //Sıradaki dosyanın dosya yolu.

                //çözünürlüğü değiştirilmiş resim
                Bitmap changed = new Bitmap(new Bitmap(tempPath), WIDTH, HEIGHT); //Çöznürlüğü değiştirilmiş resim.
                progress++;
                label2.Text = "İşlenen Dosya Sayısı: " + progress.ToString();
                changed.Save(destpath + "\\" + progress.ToString() + ".png");

                //Değişkenleri boşalt.
                fi[i] = null;
                changed = null;
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            MessageBox.Show("Kaynak Dosya Yolunu Seçiniz:");
            fbd.ShowDialog();
            filepath = fbd.SelectedPath;
            label1.Text = filepath;

            MessageBox.Show("Hedef Dosya Yolunu Seçiniz:");
            fbd.ShowDialog();
            destpath = fbd.SelectedPath;
            label4.Text = "Hedef Dosya Konumu: " + destpath;

            DirectoryInfo di = new DirectoryInfo(filepath);
            FileInfo[] fi = di.GetFiles();
            fileCounter = fi.Length;
            label2.Text = "Dosya Sayısı: " + fileCounter.ToString();

            fi = null;
        }


    }
}
