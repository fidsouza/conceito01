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

namespace conceito01.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            Xamarin.FormsMaps.Init("oIxiGsQlXEGxNC5Oz2vn~J55VugDKOfAXsMG7SJ4pOQ~AmLE3_8qcmGgh3eOUsv5iKxfsrc9hfR56S5dFMayq54CCzb0i-rmdlUSBtQu-rcw");
            LoadApplication(new conceito01.App());
        }
    }
}
