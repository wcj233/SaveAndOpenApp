
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SaveAndOpenApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page3 : Page
    {
        public Page3()
        {
            this.InitializeComponent();
            if (App.lists.Count > 2)
            {
                VM = App.lists[2];
            }
            else
            {
                VM = new MyVIewModel();
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            if (App.lists.Count > 2)
            {
                App.lists.RemoveAt(2);
            }
            App.lists.Insert(2, VM);
        }

        private MyVIewModel VM { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (App.lists.Count > 2)
            {
                App.lists.RemoveAt(2);
            }
            App.lists.Insert(2, VM);
            
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            string json = Serializer.Serialize(App.lists);
            localSettings.Values["MyList"] = json;
        }
    }
}
