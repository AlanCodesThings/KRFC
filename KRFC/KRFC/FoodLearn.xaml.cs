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
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            createfoodView();
            
        }
    }
}