using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace course_work
{
    /// <summary>
    /// Логика взаимодействия для AddDialog.xaml
    /// </summary>
    public partial class AddDialog : Window
    {
        public AddDialog()
        {
            InitializeComponent();
        }

        //происходит назначение имени, выбор пути к файлу и определение его в категорию 
        private void FindWay_Click(object sender, RoutedEventArgs e)
        {
            //выбор медиа файла, например, в формате .mp3
            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult dlgres = dlg.ShowDialog();

            if (dlgres == System.Windows.Forms.DialogResult.OK)
            {
                string FileName = dlg.FileName;
                fileName.Text = FileName;
            }
        }

        private void Ok_Click_1(object sender, RoutedEventArgs e)
        {
           
            if (fn == null)
                System.Windows.MessageBox.Show("У вас не задано имя файла");
            else
                this.DialogResult = true;
        }

        private void addTags_Click(object sender, RoutedEventArgs e)
        {
            listtags.Items.Add(ftags.Text);
        }

        //окно создания , окно добавления (наим.)
    }
}
