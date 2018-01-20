using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.Views.XamlControls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class XamlControlPage : ContentPage
	{
		public XamlControlPage ()
		{
			InitializeComponent ();
            var platform = Device.OS.ToString();
            Title = platform;

        }
	}
}