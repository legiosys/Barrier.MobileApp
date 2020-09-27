using Barrier.AndroidApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Barrier.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        private readonly BarrierLayerFacade _barrier;

        public Register()
        {
            InitializeComponent();
            _barrier = new BarrierLayerFacade();
        }

        private async void Reg_Button_Clicked(object sender, EventArgs e)
        {
            SetControlEnabled(false);
            ai_reg.IsRunning = true;
            lbl_reg.IsVisible = true;
            var id = await _barrier.RegisterApp(ed_phone.Text, ed_key.Text);
            if (id.HasValue) 
            {
                Preferences.Set("userKey", id.ToString());
                App.Current.MainPage = new MainPage();
            }
            ai_reg.IsRunning = false;
            lbl_reg.Text = "Проблема c регистрацией";
            SetControlEnabled(true);
        }

        private void SetControlEnabled(bool enabled)
        {
            btn_reg.IsEnabled = enabled;
            ed_phone.IsEnabled = enabled;
            ed_key.IsEnabled = enabled;
        }
    }
}