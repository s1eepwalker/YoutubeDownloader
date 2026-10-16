using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading;
using PowerKit.Extensions;

namespace YoutubeDownloader.Core.Utils;

public static class Http
{
    private static readonly SwitchableProxy Proxy = new();

    public static HttpClient Client { get; } =
        new(new SocketsHttpHandler { Proxy = Proxy })
        {
            DefaultRequestHeaders =
            {
                // Required by some of the services we're using
                UserAgent =
                {
                    new ProductInfoHeaderValue(
                        "YoutubeDownloader",
                        Assembly.GetExecutingAssembly().TryGetVersionString()
                    ),
                },
            },
        };

    public static Uri? ProxyUri => Proxy.Current;

    public static void ConfigureProxy(bool enabled, string ipAddress, int port)
    {
        if (!enabled)
        {
            Proxy.Current = null;
            return;
        }

        if (!IPAddress.TryParse(ipAddress, out var address))
            throw new ArgumentException("Enter a valid proxy IP address.", nameof(ipAddress));

        if (port is < 1 or > 65535)
            throw new ArgumentOutOfRangeException(nameof(port));

        Proxy.Current = new UriBuilder("socks5", address.ToString(), port).Uri;
    }

    private sealed class SwitchableProxy : IWebProxy
    {
        private readonly IWebProxy _systemProxy = HttpClient.DefaultProxy;
        private Uri? _current;

        public Uri? Current
        {
            get => Volatile.Read(ref _current);
            set => Volatile.Write(ref _current, value);
        }

        public ICredentials? Credentials
        {
            get => Current is null ? _systemProxy.Credentials : null;
            set => _systemProxy.Credentials = value;
        }

        public Uri GetProxy(Uri destination) =>
            Current ?? _systemProxy.GetProxy(destination) ?? destination;

        public bool IsBypassed(Uri destination) =>
            Current is null && _systemProxy.IsBypassed(destination);
    }
}
