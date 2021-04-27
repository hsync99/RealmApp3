using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RealmApp3.ViewModels;

namespace RealmApp3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage1 : ContentPage
    {
        public ItemViewModels itemViewModels = new ItemViewModels();
        
        
        public ICommand Delcmd => new Command(DelCmd);
        
        public ListPage1()
        {
            InitializeComponent();
            DeleteBySerialButton.IsEnabled = false;
            RemoveField.Text = "";
        }
        static private void DelCmd()
        {
            
        }
        async private void Button_Clicked(object sender, EventArgs e)
        {
            //await DisplayAlert("Alert", "You have been alerted", "OK");
            bool action = await Application.Current.MainPage.DisplayAlert("Delete", "Are you sure want to Delete : ", "Delete", "Cancel");
            if(action==true)
            {
                itemViewModels.delbool = true;
                itemViewModels.Delete();
                //delbool
            }
            else
            {

            }
        }

        private void RemoveField_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (RemoveField.Text == "") 
            {
                DeleteBySerialButton.IsEnabled = false;
            }
            else
            {
                DeleteBySerialButton.IsEnabled = true;
            }
           
        }


        //async private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    await Navigation.PushModalAsync(new MainPage());
        //}
    }
}