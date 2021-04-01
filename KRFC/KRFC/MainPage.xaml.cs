using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KRFC
{
    public partial class MainPage : ContentPage
    {
        static string category;
        public MainPage()
        {
            InitializeComponent();
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            
            var button = (Button)sender;
            var buttonType = button.ClassId;

            switch (buttonType)
            {
                case "foodButton":
                    category = "food";
                    break;
                case "transButton":
                    category = "transportation";
                    break;
                case "objButton":
                    category = "objects";
                    break;
                case "placeButton":
                    category = "places";
                    break;
                case "greetButton":
                    category = "greetings";
                    break;
            }
            await Navigation.PushAsync(new FoodLearn());
        }

        static public string getCategory()
        {
            return category;
        }
    }
}
