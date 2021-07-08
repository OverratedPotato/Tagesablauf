using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Tagesablauf
{
    public class EatManager
    {
        public int counter = 0;
        public MainWindow MainWindow;
        public void NewEatSet()
        {
            MainWindow.GridEatList.Children.Clear();
            MainWindow.GridEatList.RowDefinitions.Clear();
            MainWindow.GridEatList.ColumnDefinitions.Clear();

        }
        public void DeleteEatSet()
        {

            MainWindow.GridEatList.Children.Clear();
            MainWindow.GridEatList.RowDefinitions.Clear();
            MainWindow.GridEatList.ColumnDefinitions.Clear();

            //SetEatSetCount();
        }
        public void SaveEatSet()
        {



           // ItemCollection ic = MainWindow.dropdownEatSet.Items;
            MainWindow.FileManager.WriteTest(MainWindow.list, DateTime.Now.ToShortDateString().Replace(".", "") + DateTime.Now.ToShortTimeString().Replace(":","") + "-EatSet");

            SetEatSetCount();
        }
        public void SetEatSetCount()
        {
            MainWindow.dropdownEatSet.Items.Clear();
            string dir = System.IO.Directory.GetCurrentDirectory();
            DirectoryInfo di = new DirectoryInfo(dir);
            string[] dirs = new string[10];

            //   dirs = di.GetFiles("*-EatSet.csv").ToArray();
            // dirs = Directory.GetDirectories(dir);
            //    dirs = //Directory.GetCurrentDirectory();
            FileInfo[] fileInfo = di.GetFiles("*-EatSet.csv");
            for (int i = 0; i < fileInfo.Length; i++)
            {
                MainWindow.dropdownEatSet.Items.Add( fileInfo[i].Name.Replace("-EatSet.csv", ""));
                //  Console.WriteLine(fi.Name);
            }
            //foreach (var fi in di.GetFiles("*-EatSet.csv"))
            //{

            //}
        }
        public void SetEatSet()
        {
            DeleteEatSet();
            if (MainWindow.dropdownEatSet.SelectedIndex >= 0)
            {
                List<List<Node>> list = MainWindow.list;
                for (int i = 0; i < list.Count; i++)
                {
                    

                    if (list[i][0].name.ToLower() == "false")
                    {
                        NewEat(false, list[i][1].name, list[i][2].name, MainWindow.GridEatList, list[i]);
                    }
                    else
                    {
                        NewEat(true, list[i][1].name, list[i][2].name, MainWindow.GridEatList, list[i]);
                        }
                   
                }
            }
        }
        public void NewEat(bool isChecked, string Anzahl, string name, Grid myGrid, List<Node> nList)
        {
            if (myGrid.ColumnDefinitions.Count < 2)
            {
                ColumnDefinition colDef1 = new ColumnDefinition();
                colDef1.Width = new GridLength(0.1, GridUnitType.Star);
                ColumnDefinition colDef3 = new ColumnDefinition();
                colDef3.Width = new GridLength(0.3, GridUnitType.Star);
                ColumnDefinition colDef2 = new ColumnDefinition();
                myGrid.ColumnDefinitions.Add(colDef1);
                myGrid.ColumnDefinitions.Add(colDef3);
                myGrid.ColumnDefinitions.Add(colDef2);
                myGrid.Height = 0;

            }
            if (nList.Count == 0)
            {
                nList.Add(new Node());
                nList.Add(new Node());
                nList.Add(new Node());
            }
            myGrid.Height = myGrid.Height + 20;
            RowDefinition rowDef1 = new RowDefinition();
            myGrid.RowDefinitions.Add(rowDef1);

            CheckBox txt2 = new CheckBox();
            txt2.IsChecked = isChecked;
            Grid.SetRow(txt2, myGrid.RowDefinitions.Count - 1);
            Grid.SetColumn(txt2, 0);

            TextBox txt3 = new TextBox();
            txt3.Text = Anzahl + "";
            txt3.FontSize = 12;
            txt3.FontWeight = FontWeights.Bold;
            Grid.SetRow(txt3, myGrid.RowDefinitions.Count - 1);
            Grid.SetColumn(txt3, 1);

            TextBox txt4 = new TextBox();
            txt4.Text = name + "";
            txt4.FontSize = 12;
            txt4.FontWeight = FontWeights.Bold;
            Grid.SetRow(txt4, myGrid.RowDefinitions.Count - 1);
            Grid.SetColumn(txt4, 2);

            //List<Node> list = nList[0];
            Node n = nList[0];
            n.name = txt2.IsChecked.ToString();
            n.obj = txt2;
          //  list.Add(n);

            Node n1 = nList[1];
            n1.name = txt3.Text;
            n1.obj = txt3;
           // list.Add(n1);

            Node n2 = nList[2];
            n2.name = txt4.Text;
            n2.obj = txt4;
          //  list.Add(n2);

            //MainWindow.list.Add(list);

            myGrid.Children.Add(txt2);
            myGrid.Children.Add(txt3);
            myGrid.Children.Add(txt4);
        }
        public void TestText(string s)
        {
            MainWindow.TextEatSetName.Text = "" + s;

        }
    }
}
