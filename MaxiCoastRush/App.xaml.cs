using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MaxiCoastRush
{
    sealed partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // Xbox: no virtual mouse - controllers go straight to the game's Gamepad API
            RequiresPointerMode = ApplicationRequiresPointerMode.WhenRequested;
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            // Xbox: use the whole screen, ignore TV safe-area borders
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView()
                .SetDesiredBoundsMode(Windows.UI.ViewManagement.ApplicationViewBoundsMode.UseCoreWindow);

            var root = Window.Current.Content as Frame;
            if (root == null)
            {
                root = new Frame();
                Window.Current.Content = root;
            }
            if (root.Content == null) root.Navigate(typeof(MainPage), e.Arguments);
            Window.Current.Activate();

            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TryEnterFullScreenMode();
        }
    }
}
