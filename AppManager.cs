using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tagesablauf
{
    public class AppManager
    {
        public MainWindow MainWindow;

        public void ini()
        {
            ComboBox minute = MainWindow.dropdownMin;
            ComboBox hour = MainWindow.dropdownHour;
            for (int i = 0; i < 60; i++)
            {
                if (i<10)
                {
                    minute.Items.Add("0"+i);
                }
                else
                {
                    minute.Items.Add("" + i);
                }
            }
            Grid myGrid = MainWindow.GridDayValueView;
            myGrid.ShowGridLines = true;

            myGrid.Height = 0;
            RowDefinition rowDef2 = new RowDefinition();
            for (int i2 = 0; i2 < 3; i2++)
            {
                myGrid.Height = myGrid.Height + 20;
                rowDef2 = new RowDefinition();
                myGrid.RowDefinitions.Add(rowDef2);
                for (int i = 0; i < 12; i++)
                {
                    if (i2==0)
                    {
                        ColumnDefinition colDef1 = new ColumnDefinition();
                        colDef1.Width = new GridLength(0.1, GridUnitType.Star);
                        myGrid.ColumnDefinitions.Add(colDef1); 

                    }
                    TextBox txt3 = new TextBox();
                    txt3.Text = i+1 + "";
                    txt3.FontSize = 12;
                    txt3.FontWeight = FontWeights.Bold;


                    if (i2==0)
                    {
                        txt3.Background = new SolidColorBrush(Colors.LightGray);
                    }
                    else if (i2 == 1)
                    {

                    }
                    else if (i2 == 2)
                    {

                    }


                    Grid.SetRow(txt3, i2);
                    Grid.SetColumn(txt3, i);
                    myGrid.Children.Add(txt3);
                }
            }
            
            for (int i2 = 3; i2 < 6; i2++)
            {
                myGrid.Height = myGrid.Height + 20;
                 rowDef2 = new RowDefinition();
                myGrid.RowDefinitions.Add(rowDef2);
                for (int i = 0; i < 12; i++)
                {
                    TextBox txt3 = new TextBox();
                    txt3.Text = i+13 + "" ;
                    txt3.FontSize = 12;
                    txt3.FontWeight = FontWeights.Bold;

                    if (i2 == 3)
                    {
                        txt3.Background = new SolidColorBrush(Colors.LightGray);
                    }
                    else if (i2 == 4)
                    {

                    }
                    else if (i2 == 5)
                    {

                    }


                    Grid.SetRow(txt3, i2);
                    
                    Grid.SetColumn(txt3, i);
                    myGrid.Children.Add(txt3);
                }
            }
            //if (myGrid.ColumnDefinitions.Count < 2)
            //{

            //    colDef1.Width = new GridLength(0.1, GridUnitType.Star);
            //    ColumnDefinition colDef3 = new ColumnDefinition();
            //    colDef3.Width = new GridLength(0.3, GridUnitType.Star);
            //    ColumnDefinition colDef2 = new ColumnDefinition();

            //    myGrid.ColumnDefinitions.Add(colDef3);
            //    myGrid.ColumnDefinitions.Add(colDef2);
            //    myGrid.Height = 0;

            //}

            //CheckBox txt2 = new CheckBox();
            //txt2.IsChecked = isChecked;
            //Grid.SetRow(txt2, myGrid.RowDefinitions.Count - 1);
            //Grid.SetColumn(txt2, 0);



            //TextBox txt4 = new TextBox();
            //txt4.Text = name + "";
            //txt4.FontSize = 12;
            //txt4.FontWeight = FontWeights.Bold;
            //Grid.SetRow(txt4, myGrid.RowDefinitions.Count - 1);
            //Grid.SetColumn(txt4, 2);

            ////  list.Add(n2);

            ////MainWindow.list.Add(list);

            //myGrid.Children.Add(txt2);
            //myGrid.Children.Add(txt3);
            //myGrid.Children.Add(txt4);
        }
    }
}
