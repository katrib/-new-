using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace course_work
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        List<imgOBJECT> allPic = new List<imgOBJECT>();

        List<imgOBJECT> selectedPic = new List<imgOBJECT>();

        JSON j = new JSON();

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string category;

            AddDialog parametr = new AddDialog();
            if (parametr.ShowDialog() == true)
            {
                List<string> tags = parametr.listtags.Items.Cast<string>().ToList();
                category = parametr.categorycombo.Text;

                imgOBJECT a = new imgOBJECT(parametr.fn.Text, parametr.fileName.Text, parametr.fileURL.Text, category, tags);

                string tagi = "";
                foreach (string tag in tags)
                {
                    tagi += tag + "; ";
                }


                allPic.Add(a);
                selectedPic.Add(a);
                list.Items.Add(a.name + ": " + tagi);
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            list.Items.Clear();
            selectedPic.Clear();

            ComboBoxItem comboBox = (ComboBoxItem)kategoria.SelectedItem;
            string category = comboBox.Content.ToString();

            if (category == "All")
            {
                foreach (imgOBJECT a in allPic)
                {
                    string tagi = "";
                    foreach (string tag in a.tags)
                    {
                        tagi += tag + "; ";
                    }

                    list.Items.Add(a.name + ": " + tagi);
                    selectedPic.Add(a);
                }
            }
            else
            {
                foreach (imgOBJECT a in allPic)
                {
                    if (a.category == category)
                    {
                        string tagi = "";
                        foreach (string tag in a.tags)
                        {
                            tagi += tag + "; ";
                        }

                        list.Items.Add(a.name + ": " + tagi);
                        selectedPic.Add(a);
                    }
                }
            }
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (list.SelectedIndex > -1)
            {
                imgOBJECT p;

                p = selectedPic[list.SelectedIndex];

                if (p.url == "")
                    img.Source = new BitmapImage(new Uri(p.path));
                else
                {
                    var fullFilePath = p.url;
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
                    bitmap.EndInit();

                    img.Source = bitmap;
                }
            }
        }

        private void FindName_Click(object sender, RoutedEventArgs e)
        {
            list.Items.Clear();
            selectedPic.Clear();

            string name = findbyname.Text;

            foreach (imgOBJECT el in allPic)
            {
                string tagi = "";
                foreach (string tag in el.tags)
                {
                    tagi += tag + "; ";
                }

                string name1 = el.name;
                if (name1.Contains(name) == true)
                {
                    list.Items.Add(name1 + ": " + tagi);
                    selectedPic.Add(el);
                }


                foreach (string tag in el.tags)
                {
                    string name2 = tag;
                    string name3;
                    if (name2.Contains(name) == true)
                    {
                        name3 = el.name;
                        list.Items.Add(name3 + ": " + tagi);
                        selectedPic.Add(el);
                    }

                }
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (list.SelectedIndex > -1)
            {
                selectedPic.Remove(selectedPic[list.SelectedIndex]);
                allPic.Remove(allPic[list.SelectedIndex]);
                list.Items.Remove(list.SelectedValue);
                img.Source = null;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            j.SaveFile(allPic);
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            list.Items.Clear();
            allPic = j.LoadFile();


            foreach (imgOBJECT a in allPic)
            {
                selectedPic.Add(a);
                string tagi = "";

                List<string> tagis = a.tags;
                if (tagis != null)
                {
                    foreach (string tag in tagis)
                    {
                        tagi += tag + "; ";
                    }

                }

                list.Items.Add(a.name + ": " + tagi);
               
            }
        }

    }
}
