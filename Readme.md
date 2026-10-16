# YoutubeDownloader

[![Build](https://img.shields.io/github/actions/workflow/status/s1eepwalker/YoutubeDownloader/main.yml?branch=prime)](https://github.com/s1eepwalker/YoutubeDownloader/actions)
[![Release](https://img.shields.io/github/release/s1eepwalker/YoutubeDownloader.svg)](https://github.com/s1eepwalker/YoutubeDownloader/releases)
[![Downloads](https://img.shields.io/github/downloads/s1eepwalker/YoutubeDownloader/total.svg)](https://github.com/s1eepwalker/YoutubeDownloader/releases)
[![Discord](https://img.shields.io/discord/869237470565392384?label=discord)](https://discord.gg/2SUWKFnHSm)

<table>
    <tr>
        <td width="99999" align="center">Development of this project is entirely funded by the community. <b><a href="https://tyrrrz.me/donate">Consider donating to support!</a></b></td>
    </tr>
</table>

<p align="center">
    <img src="favicon.png" alt="Icon" />
</p>

**YoutubeDownloader** is an application that lets you download videos from YouTube.
You can copy-paste URL of any video, playlist or channel and download it directly in a format of your choice.
It also supports searching by keywords, which is helpful if you want to quickly look up and download videos.

> [!NOTE]
> This application uses [**YoutubeExplode**](https://github.com/Tyrrrz/YoutubeExplode) under the hood to interact with YouTube.
> You can [read this article](https://tyrrrz.me/blog/reverse-engineering-youtube-revisited) to learn more about how it works.

## Download

- 🟢 **[Stable release](https://github.com/s1eepwalker/YoutubeDownloader/releases/latest)**
- 🟠 [CI build](https://github.com/s1eepwalker/YoutubeDownloader/actions/workflows/main.yml)
- 📦 [Scoop](https://scoop.sh/#/apps?q=YoutubeDownloader&p=1&id=2c0182d9ff5edefc525a57d50ead470d8f02184f): `scoop install extras/youtubedownloader` (community-maintained)
- 📦 [AUR](https://aur.archlinux.org/packages/youtubedownloader): `yay -S youtubedownloader` (community-maintained)

> [!IMPORTANT]
> To launch the app on MacOS, you may need to first remove the downloaded file from quarantine.
> You can do that by running the following command in the terminal: `xattr -rd com.apple.quarantine YoutubeDownloader.app`.

> [!NOTE]
> Community-maintained packages are published independently from this repository and may not always be up to date with the latest release.

> [!NOTE]
> If you're unsure which build is right for your system, consult with [this page](https://useragent.cc) to determine your OS and CPU architecture.

## Features

- Cross-platform graphical user interface
- Download videos by URL
- Download videos from playlists or channels
- Download videos by search query
- Selectable video quality and format
- Automatically embed audio tracks in alternative languages
- Automatically embed subtitles
- Automatically inject media tags
- Log in with a YouTube account to access private content
- Route network requests through a SOCKS5 proxy

## SOCKS5 proxy

Enable **Use SOCKS5 proxy** in Settings and enter the proxy IP address and port. The defaults are `127.0.0.1` and `5555`; the proxy is off until you enable it. For an SSH tunnel, run `ssh -D 5555 your-host` and keep that session open while using the app.

The proxy applies to downloads, search, thumbnails, metadata, and the FFmpeg download. On Windows, it also applies to the built-in sign-in browser. Reopen the sign-in window after changing the proxy settings.

## Screenshots

![list](.assets/list.png)
![single](.assets/single.png)
![multiple](.assets/multiple.png)
