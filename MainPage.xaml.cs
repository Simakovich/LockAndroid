using System.Windows.Input;

namespace LockScreen
{
    public partial class MainPage : ContentPage
    {
        public ICommand LockScreenCommand { get; private set; }

        public MainPage()
	    {
		    InitializeComponent();

            BindingContext = this;
            Environment.Exit(0);
        }
    }
}
