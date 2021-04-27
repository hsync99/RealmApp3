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
using RealmApp3.Views;

namespace RealmApp3
{
    public partial class MainPage : ContentPage
    {
        int i;
        int x;

        bool auf = false;
        public MainPage()
        {
            InitializeComponent();
            SERIAL.Text = "";
            PARAMETER.IsVisible = false;
            PARAMVALUE.IsVisible = false;
            addnewParam.IsEnabled = false;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            auf = true;
            Random rnd = new Random();
            i = rnd.Next(0, 1000);//Рандомное число для автозаполнения
            Random ser = new Random();
            x = ser.Next(10000, 99999);//Рандомный серийный номер
            NAME.Text = "(" + i + ")" + " " + "NAME";
            MODEL.Text = "(" + i + ")" + " " + "MODEL";
            TYPE.Text = "(" + i + ")" + " " + "TYPE";
            SERIAL.Text = x.ToString();
            MANUFACTORER.Text = "(" + i + ")" + " " + "MANUFACTORER";



        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            addnewParam.IsEnabled = true;
            addnewParam.IsVisible = true;
            NAME.IsEnabled = false;
            MODEL.IsEnabled = false;
            TYPE.IsEnabled = false;
            SERIAL.IsEnabled = false;
            MANUFACTORER.IsEnabled = false;
            PARAMETER.IsVisible = true;
            PARAMVALUE.IsVisible = true;
            createButton.IsEnabled = false;
            addnewParam.IsEnabled = true;
            //addimg.IsVisible = true;
            //paramframe.IsVisible = true;
            //paramvalueframe.IsVisible = true;


        }

        private void addnewParam_Clicked(object sender, EventArgs e)
        {
            PARAMETER.Text = "";
            PARAMVALUE.Text = "";
        }

        private void Finish_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushModalAsync(new ListPage1());
        }
    }
}
