using RealmApp3.Models;
using RealmApp3.ViewModels;
using RealmApp3.Views;
using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RealmApp3.ViewModels
{
    public class ItemViewModels : INotifyPropertyChanged
    {
        Realm _getRealmInstance = Realm.GetInstance();
        public ICommand DeleteCommand => new Command(Delete);
        public List<ItemObject> _listOfItems;
        public List<Manufactorer> _listOfManufactorers;
        
        public ItemObject itmObj;
        public bool delbool = false;
        private ObservableCollection<ItemObject> _observableObjects;
        public ObservableCollection<ItemObject> ObservableObjects
        {
            get => _observableObjects;
            set
            {
                _observableObjects = value;
                OnPropertyChanged();
            }
        }
        public List<ItemObject> ListOfItems
        {
            get { return _listOfItems; }
            set
            {
                _listOfItems = value;
                OnPropertyChanged();
            }
        }
        public List<Manufactorer> ListOfManufacorers
        {
            get { return _listOfManufactorers; ; }
            set
            {
                _listOfManufactorers = value;
                OnPropertyChanged();
            }
        }
        private Manufactorer _manufactorer = new Manufactorer();
        private ItemObject _itemObject = new ItemObject();
        private ItemType _itemType = new ItemType();
        private Param _param = new Param();
        public Param Param
        {
            get { return _param; }
            set
            {
                _param = value;
                OnPropertyChanged();
            }
        }
        public ItemType ItemType
        {
            get { return _itemType; }
            set
            {
                _itemType = value;
                OnPropertyChanged();
            }
        }
        public Manufactorer Manufactorer
        {
            get { return _manufactorer; }
            set
            {
                _manufactorer = value;
                OnPropertyChanged();
            }
        }
        public ItemObject ItemObject
        {
            get { return _itemObject; }
            set
            {
                _itemObject = value;
                OnPropertyChanged();
            }
        }

         public Command CreateCommand
        {
            get
            {
                return new Command(() =>
                {                                        
                    ItemObject.type = _itemType;
                    ItemObject.manufactorer = _manufactorer;                                     
                    _getRealmInstance.Write(() =>
                    {                      
                        _getRealmInstance.Add(_manufactorer);
                        _getRealmInstance.Add(_itemType);                    
                        _getRealmInstance.Add(_itemObject);
                    });
                });
                
            }
        }
        public ItemViewModels()
        {
            this.ListOfItems = _getRealmInstance.All<ItemObject>().ToList();
            this.ListOfManufacorers = _getRealmInstance.All<Manufactorer>().ToList();
            List<ItemObject> itemObjects = _getRealmInstance.All<ItemObject>().ToList();
            ObservableObjects = new ObservableCollection<ItemObject>(itemObjects);
        }
        public Command NavToListCommand
        {
            get
            {
                return new Command(async () =>
                {

                    await App.Current.MainPage.Navigation.PushModalAsync(new ListPage1());

                });
            }
        }
        public Command NavToMainPage
        {
            get
            {
                return new Command(async () =>
                {

                    await App.Current.MainPage.Navigation.PushModalAsync(new MainPage());

                });
            }
        }
        public Command NavToDeletePage
        {
            get
            {
                return new Command(async () =>
                {

                    await App.Current.MainPage.Navigation.PushModalAsync(new DeletePage());

                });
            }
        }
        public Command NavToBarcodePage
        {
            get
            {
                return new Command(async () =>
                {

                    await App.Current.MainPage.Navigation.PushModalAsync(new BarcodePage());

                });
            }
        }

        public void Delete()
        {   
            if (delbool == true)
            {

                int i = _getRealmInstance.All<ItemObject>().Count() - 1;

                ItemObject obobj = ObservableObjects[i];
                using (Transaction transact = _getRealmInstance.BeginWrite())
                {
                    _getRealmInstance.Remove(obobj);
                    transact.Commit();
                }

                ObservableObjects.Remove(obobj);
                App.Current.MainPage.Navigation.PushModalAsync(new ListPage1());
            }
            else { }
        }       
        public Command Removecmd
        {
            get
            {
                return new Command(() =>
                {   
                    var getAllBySerial = _getRealmInstance.All<ItemObject>().FirstOrDefault(x => x.serial  == ItemObject.serial);
                  

                   

                    using (var transaction = _getRealmInstance.BeginWrite())
                    {

                        _getRealmInstance.Remove(getAllBySerial);
                        transaction.Commit();
                        App.Current.MainPage.Navigation.PushModalAsync(new ListPage1());
                    }; 
                });
            }
        }
        public Command AddNewParam
        {
            get
            {
                return new Command(() =>
                {
                    _getRealmInstance.Write(() =>
                    {
                        var p = new Param();
                        
                        p.name = Param.name;
                        p.value = Param.value;
                        _getRealmInstance.Add(p);
                        _getRealmInstance.Add(_itemObject);
                        ItemObject.values.Add(p);
                    });
                     

                });
            }
        }
  
        public List<ItemObject> SearchItems(string searchText)
        {
            return _getRealmInstance.All<ItemObject>().Where(p => p.name.Contains(searchText)).ToList();
        }

        //============================================================================================
        //INOTIFYPROPERTYCHAGED///////////////////////////////////////////////////////////////////////
        //============================================================================================
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
