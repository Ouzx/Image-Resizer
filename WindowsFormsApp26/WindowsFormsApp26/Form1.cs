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

        Bitmap changed;
        string tempPath;
        private void button2_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(filepath);
            FileInfo[] fi = di.GetFiles();

            //Klasördeki tüm dosyaları dolaşır.
            for(int i = 0; i < fi.Length; i++)
            {
                try
                {
                    tempPath = filepath + "\\" + fi[i].Name; //Sıradaki dosyanın dosya yolu.
                    //çözünürlüğü değiştirilmiş resim
                    changed = new Bitmap(new Bitmap(tempPath), WIDTH, HEIGHT); //Çöznürlüğü değiştirilmiş resim.
                    progress++;
                    label2.Text = "İşlenen Dosya Sayısı: " + progress.ToString();
                    changed.Save(destpath + "\\" + progress.ToString() + ".jpg");
                }
                catch
                {
                    GC.Collect();
                }/*
                finally
                {
                    //Değişkenleri boşalt.
                    fi[i] = null;
                    tempPath = null;
                    if (changed != null)
                    {
                        changed = null;
                    }
                }*/
            }
            GC.Collect();
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
            di = null;
            fi = null;
        }


    }
}
