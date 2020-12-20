using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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

        private List<imgOBJECT> allPic = new List<imgOBJECT>();
        private List<imgOBJECT> selectedPic = new List<imgOBJECT>();
        private JSON j = new JSON();

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddDialog parametr = new AddDialog();
            if (parametr.ShowDialog() == true)
            {
                List<string> tags = parametr.listtags.Items.Cast<string>().ToList();
                string category = parametr.categorycombo.Text;
                imgOBJECT a = new imgOBJECT(parametr.fn.Text, parametr.fileName.Text, parametr.fileURL.Text, category, tags);

                allPic.Add(a);
                addToListBox(a);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            list.Items.Clear();
            selectedPic.Clear();

            ComboBoxItem comboBox = (ComboBoxItem)kategoria.SelectedItem;
            string category = comboBox.Content.ToString();

            foreach (imgOBJECT a in allPic)
            {
                if (category == "All" || a.category == category)
                {
                    addToListBox(a);
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
                if (el.name.Contains(name))
                {
                    addToListBox(el);
                }

                foreach (string tag in el.tags)
                {
                    if (tag.Contains(name))
                    {
                        addToListBox(el);
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

            foreach (imgOBJECT a in allPic) addToListBox(a);
        }

        private void addToListBox(imgOBJECT obj)
        {
            string tagi = JoinTags(obj.tags);
            list.Items.Add($"{obj.name}: {tagi}");
            selectedPic.Add(obj);
        }

        private string JoinTags(List<string> tags)
        {
            return string.Join("; ", tags);
        }
    }
}
