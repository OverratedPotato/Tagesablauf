using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tagesablauf
{
    public class Node
    {
        public bool isChecked;
        public string name;
        public int anzahl;
        public object obj;

    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public EatManager eatManager =new EatManager();
        public FileManager FileManager=new FileManager();
        public AppManager AppManager = new AppManager();
        public TimeManager TimeManager = new TimeManager();
        public List<List<Node>> list = new List<List<Node>>();
        public List<List<string>> DataList = new List<List<string>>();

        public MainWindow()
        {
            InitializeComponent();
             eatManager.MainWindow =  (this);
             FileManager.MainWindow =  (this);
            TimeManager.MainWindow =  (this);
            AppManager.MainWindow =  (this);
            eatManager.SetEatSetCount();
            AppManager.ini();
            //  FileManager.WriteTest(list);
            //var bla= FileManager.ReadTest( "WriteTest");
            //  eatManager.NewEat(false,"","",GridEatList);
            eatManager.DeleteEatSet();
        }

        private void TextEatSetName_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnNewEatset_Click(object sender, RoutedEventArgs e)
        {

            eatManager.DeleteEatSet();
        }

        private void btnSaveEatset_Copy_Click(object sender, RoutedEventArgs e)
        {

            eatManager.SaveEatSet();
        }

        private void btnDeleteEatset_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNewEat_Click(object sender, RoutedEventArgs e)
        {
            List<Node> n = new List<Node>();
            list.Add(n);
            eatManager.NewEat(false, "", "", GridEatList,n);

        }

        private void btnSaveDataset_Click(object sender, RoutedEventArgs e)
        {
            TimeManager.SaveData();
        }

        private void calendar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Calendar Calendar = (Calendar)sender;
            eatManager.TestText(Calendar.SelectedDate.Value.ToShortDateString());
           TimeManager.LoadDate();
        }

        private void TextEatSetName_Copy_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void dropdownEatSet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox _sender = (ComboBox)sender;
            // var bla = FileManager.ReadTest("WriteTest");
            if (_sender.SelectedIndex >=0)
            {
                list = FileManager.ReadTest(_sender.SelectedValue + "-EatSet");
                eatManager.SetEatSet();

            }
        }
    }
}
