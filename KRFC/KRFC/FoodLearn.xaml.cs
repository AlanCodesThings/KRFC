using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace KRFC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodLearn : ContentPage
    {
        public FoodLearn()
        {
            InitializeComponent();
        }
        public void createfoodView()
        {
            
            ObservableCollection<string> food = new ObservableCollection<string>(FoodPage.getlistFood());
            foodlistView.ItemsSource = food;

            ObservableCollection<string> korfood = new ObservableCollection<string>(FoodPage.getlistkorFood());
            korlistView.ItemsSource = korfood;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            FoodPage.emptyLists();
            createfoodView();
            
        }
        async private void Button_Clicked2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FoodPage());
        }
    }
}