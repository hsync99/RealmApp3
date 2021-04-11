using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Realms;
using System.Windows.Input;
using RealmApp3.Models;

namespace RealmApp3
{
    public partial class MainPage : ContentPage
    {   int i;
        int x;
        
        bool auf = false;
        public MainPage()
        {
            InitializeComponent();
            SERIAL.Text = "";
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            auf = true;
            Random rnd = new Random();
            i = rnd.Next(0,1000);//Рандомное число для автозаполнения
            Random ser = new Random();
            x = ser.Next(10000, 99999);//Рандомный серийный номер
            NAME.Text = "(" + i + ")" + " " + "NAME";
            MODEL.Text = "(" + i + ")" + " " + "MODEL";
            TYPE.Text = "(" + i + ")" + " " + "TYPE";
            SERIAL.Text = x.ToString();
            MANUFACTORER.Text = "(" + i + ")" + " " + "MANUFACTORER";
            PARAMETER.Text = "(" + i + ")" + " " + "PARAMETER";
            
            
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            
         
            
            Entry prm = new Entry();//Это новый параметр
            Entry entr = new Entry();//Это новое значение параметра
            Param _param = new Param();
            
            prm.Placeholder = "Param";
            entr.Placeholder = "Value";
            stackLayout.Children.Add(prm);
            stackLayout.Children.Add(entr);
            Binding binding = new Binding { Source = prm, Path = "Text", Mode = BindingMode.TwoWay };
            prm.SetBinding(Entry.TextProperty,binding);
            if (auf == true)
            {
                prm.Text = "(" + i + ")" + " " + "PARAMETER";
                entr.Text = "(" + i + ")" + " " + "VALUE";
            }
           

        }

       
       
    }
}
