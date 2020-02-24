
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SaveAndOpenApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

  

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder LocalStorageFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await LocalStorageFolder.CreateFileAsync("MyData.txt",CreationCollisionOption.OpenIfExists);
            string jsonValue = await FileIO.ReadTextAsync(file);
            if (jsonValue.Length>0) {

                App.lists = Serializer.Deserialize<List<MyVIewModel>>(jsonValue.ToString());
            }
        }
        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Page1));
        }
    }
}
