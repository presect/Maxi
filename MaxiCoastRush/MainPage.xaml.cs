using System;
using Windows.UI.Xaml.Controls;

namespace MaxiCoastRush
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            Loaded += async (_, __) =>
            {
                await Web.EnsureCoreWebView2Async();
                var s = Web.CoreWebView2.Settings;
                s.AreDefaultContextMenusEnabled = false;
                s.AreDevToolsEnabled = false;
                s.IsStatusBarEnabled = false;
                s.IsZoomControlEnabled = false;
                // serve the packaged game 100% locally
                var gameDir = System.IO.Path.Combine(
                    Windows.ApplicationModel.Package.Current.InstalledLocation.Path, "GameFiles");
                Web.CoreWebView2.SetVirtualHostNameToFolderMapping(
                    "app.local", gameDir,
                    Microsoft.Web.WebView2.Core.CoreWebView2HostResourceAccessKind.Allow);
                Web.CoreWebView2.Navigate("https://app.local/index.html");
            };
        }
    }
}
