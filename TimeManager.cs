using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tagesablauf
{
    public class TimeManager
    {
        public int counter = 0;
        public MainWindow MainWindow;
        public void DeleteEatSet()
        {

            MainWindow.GridDayValueView.Children.Clear();
            MainWindow.GridDayValueView.RowDefinitions.Clear();
            MainWindow.GridDayValueView.ColumnDefinitions.Clear();

            //SetEatSetCount();
        }
        public void SaveData()
        {

            string Time =  MainWindow.TextTime.Text;

            for (int i = Time.Length; i < 4; i++)
            {
                Time = "0"+Time;
            }
            int leng = Time.Length;
            Time = Time.Substring(leng - 4, 4);
            string duration=  MainWindow.TextDuration.Text;
            List<string> list = new List<string>();
            list.Add(Time);
            list.Add(duration);
            list.Add(MainWindow.dropdownEatSet.SelectedValue.ToString());
            MainWindow.DataList.Add(list);
            if (MainWindow.calendar.SelectedDate!=null)
            {
                string date = MainWindow.calendar.SelectedDate.Value.ToShortDateString().Replace(".", "");

                // ItemCollection ic = MainWindow.dropdownEatSet.Items;
                MainWindow.FileManager.WriteTest(MainWindow.DataList, date + "-DataSet");
            }

        }
       
        public void LoadDate()
        {
            MainWindow.DataList = new List<List<string>>();
            Grid myGrid = MainWindow.GridDayValueView;
            string dir = System.IO.Directory.GetCurrentDirectory();
            DirectoryInfo di = new DirectoryInfo(dir);
            string[] dirs = new string[10];

            //   dirs = di.GetFiles("*-EatSet.csv").ToArray();
            // dirs = Directory.GetDirectories(dir);
            //    dirs = //Directory.GetCurrentDirectory();
            FileInfo[] fileInfo = di.GetFiles(MainWindow.calendar.SelectedDate.Value.ToShortDateString().Replace(".","")+"*-DataSet.csv");
            for (int i = 0; i < fileInfo.Length; i++)
            {
                MainWindow.DataList = MainWindow.FileManager.ReadDataCSV(fileInfo[i].Name.Replace(".csv", ""));
                //MainWindow.dropdownEatSet.Items.Add(fileInfo[i].Name.Replace("-EatSet.csv", ""));
                //  Console.WriteLine(fi.Name);
            }
            SetDateGrid();
        }

        public void SetDateGrid()
        {
            MainWindow.DataList[6].Sort();
           Grid myGrid = MainWindow.GridDayValueView;

           TextBox txt= (TextBox)myGrid.Children[2];
            txt.Background = new SolidColorBrush(Colors.Green);

            txt.Text ="";



            TextBox txt2 = (TextBox)myGrid.Children[40];
            
            txt2.Background = new SolidColorBrush(Colors.Green);


            //string dir = System.IO.Directory.GetCurrentDirectory();
            //DirectoryInfo di = new DirectoryInfo(dir);
            //string[] dirs = new string[10];

            ////   dirs = di.GetFiles("*-EatSet.csv").ToArray();
            //// dirs = Directory.GetDirectories(dir);
            ////    dirs = //Directory.GetCurrentDirectory();
            //FileInfo[] fileInfo = di.GetFiles(MainWindow.calendar.SelectedDate.Value.ToShortDateString().Replace(".", "") + "*-DataSet.csv");
            //for (int i = 0; i < fileInfo.Length; i++)
            //{
            //    MainWindow.DataList = MainWindow.FileManager.ReadDataCSV(fileInfo[i].Name.Replace(".csv", ""));
            //    //MainWindow.dropdownEatSet.Items.Add(fileInfo[i].Name.Replace("-EatSet.csv", ""));
            //    //  Console.WriteLine(fi.Name);
            //}

        }
    }
}
