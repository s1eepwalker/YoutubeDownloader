using System;
using System.Linq;
using System.Net;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform;
using YoutubeDownloader.Framework;
using YoutubeDownloader.ViewModels.Dialogs;

namespace YoutubeDownloader.Views.Dialogs;

public partial class AuthSetupView : UserControl<AuthSetupViewModel>
{
    private static readonly Uri HomePageUri = new("https://www.youtube.com");
    private static readonly Uri LoginPageUri = new(
        $"https://accounts.google.com/ServiceLogin?continue={Uri.EscapeDataString(HomePageUri.AbsoluteUri)}"
    );

    public AuthSetupView()
    {
        InitializeComponent();

        // GTK supports an ephemeral cookie store; WPE remains a fallback when GTK is unavailable.
        if (OperatingSystem.IsLinux())
            WebBrowser.AdapterPreference =
            [
                WebViewAdapterType.WebKitGtk,
                WebViewAdapterType.WpeWebKit,
            ];
    }

    private void NavigateToLoginPage() => WebBrowser.Source = LoginPageUri;

    private async void LogOutButton_OnClick(object sender, RoutedEventArgs args)
    {
        DataContext.Cookies = null;

        if (WebBrowser.TryGetCookieManager() is { } cookieManager)
        {
            foreach (var cookie in await cookieManager.GetCookiesAsync())
                cookieManager.DeleteCookie(cookie);
        }

        NavigateToLoginPage();
    }

    private void WebBrowser_OnLoaded(object sender, RoutedEventArgs args) => NavigateToLoginPage();

    private void WebBrowser_OnEnvironmentRequested(
        object? sender,
        WebViewEnvironmentRequestedEventArgs args
    )
    {
        args.EnableDevTools = false;

        switch (args)
        {
            case WindowsWebView2EnvironmentRequestedEventArgs windows:
                windows.IsInPrivateModeEnabled = true;
                break;
            case AppleWKWebViewEnvironmentRequestedEventArgs apple:
                apple.NonPersistentDataStore = true;
                break;
            case GtkWebViewEnvironmentRequestedEventArgs gtk:
                gtk.EphemeralDataManager = true;
                break;
        }
    }

    private static bool IsYoutubeCookie(Cookie cookie)
    {
        var domain = cookie.Domain.TrimStart('.');

        return !string.IsNullOrEmpty(domain)
            && (
                string.Equals(HomePageUri.Host, domain, StringComparison.OrdinalIgnoreCase)
                || HomePageUri.Host.EndsWith($".{domain}", StringComparison.OrdinalIgnoreCase)
            );
    }

    private async void WebBrowser_OnNavigationCompleted(
        object? sender,
        WebViewNavigationCompletedEventArgs args
    )
    {
        if (!args.IsSuccess || WebBrowser.TryGetCookieManager() is not { } cookieManager)
            return;

        // Extract YouTube cookies after the login redirects to the home page.
        if (
            args.Request is { } url
            && string.Equals(url.Scheme, HomePageUri.Scheme, StringComparison.OrdinalIgnoreCase)
            && string.Equals(url.Host, HomePageUri.Host, StringComparison.OrdinalIgnoreCase)
        )
        {
            var cookies = await cookieManager.GetCookiesAsync();
            DataContext.Cookies = cookies.Where(IsYoutubeCookie).ToArray();
        }
    }
}
