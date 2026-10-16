using System.Collections.Generic;

namespace YoutubeDownloader.Localization;

public partial class LocalizationManager
{
    private static readonly IReadOnlyDictionary<string, string> RussianLocalization =
        new Dictionary<string, string>
        {
            // Dashboard
            [nameof(QueryPlaceholderText)] = "Ссылка или поисковый запрос",
            [nameof(QueryTooltip)] =
                "Введите ссылку или идентификатор видео YouTube. Чтобы искать по тексту, добавьте в начало вопросительный знак (?).",
            [nameof(ProcessQueryTooltip)] = "Обработать запрос (Enter)",
            [nameof(AuthTooltip)] = "Авторизация",
            [nameof(SettingsTooltip)] = "Настройки",
            [nameof(DashboardPlaceholder)] = """
                Вставьте **ссылку** или введите **поисковый запрос**, чтобы начать загрузку
                Нажмите **Shift+Enter**, чтобы добавить несколько элементов
                """,
            [nameof(DownloadsFileColumnHeader)] = "Файл",
            [nameof(DownloadsSizeColumnHeader)] = "Размер",
            [nameof(DownloadsStatusColumnHeader)] = "Состояние",
            [nameof(ContextMenuRemoveSuccessful)] = "Убрать завершённые загрузки",
            [nameof(ContextMenuRemoveInactive)] = "Убрать неактивные загрузки",
            [nameof(ContextMenuRestartFailed)] = "Повторить неудачные загрузки",
            [nameof(ContextMenuCancelAll)] = "Отменить все загрузки",
            [nameof(DownloadStatusEnqueued)] = "В очереди...",
            [nameof(DownloadStatusCompleted)] = "Готово",
            [nameof(DownloadStatusCanceled)] = "Отменено",
            [nameof(DownloadStatusFailed)] = "Ошибка",
            [nameof(ClickToCopyErrorTooltip)] = "Нажмите, чтобы скопировать сообщение об ошибке",
            [nameof(ShowFileTooltip)] = "Показать файл",
            [nameof(PlayTooltip)] = "Воспроизвести",
            [nameof(CancelDownloadTooltip)] = "Отменить загрузку",
            [nameof(RestartDownloadTooltip)] = "Повторить загрузку",
            // Settings
            [nameof(SettingsTitle)] = "Настройки",
            [nameof(ThemeLabel)] = "Тема",
            [nameof(ThemeTooltip)] = "Оформление интерфейса",
            [nameof(LanguageLabel)] = "Язык",
            [nameof(LanguageTooltip)] = "Язык интерфейса",
            [nameof(ProxyEnabledLabel)] = "Использовать SOCKS5-прокси",
            [nameof(ProxyEnabledTooltip)] =
                "Направлять загрузки, поиск, изображения и другие запросы приложения через SOCKS5. В Windows прокси действует и для окна входа.",
            [nameof(ProxyIpAddressLabel)] = "IP-адрес прокси",
            [nameof(ProxyIpAddressTooltip)] = "IP-адрес сервера SOCKS5-прокси",
            [nameof(ProxyInvalidIpMessage)] = "Введите корректный IP-адрес",
            [nameof(ProxyPortLabel)] = "Порт прокси",
            [nameof(ProxyPortTooltip)] = "Порт сервера SOCKS5-прокси",
            [nameof(PersistAuthLabel)] = "Сохранять авторизацию",
            [nameof(PersistAuthTooltip)] = """
                Сохранять файлы cookie для авторизации между запусками приложения.
                **Предупреждение**: файлы cookie хранятся в зашифрованном виде, но злоумышленник с доступом к вашему компьютеру может их восстановить.
                """,
            [nameof(InjectAltLanguagesLabel)] = "Добавлять другие языковые дорожки",
            [nameof(InjectAltLanguagesTooltip)] =
                "Добавлять доступные звуковые дорожки на других языках в загруженные файлы",
            [nameof(InjectSubtitlesLabel)] = "Добавлять субтитры",
            [nameof(InjectSubtitlesTooltip)] = "Добавлять доступные субтитры в загруженные файлы",
            [nameof(InjectTagsLabel)] = "Добавлять метаданные",
            [nameof(InjectTagsTooltip)] = "Добавлять доступные метаданные в загруженные файлы",
            [nameof(SkipExistingFilesLabel)] = "Пропускать существующие файлы",
            [nameof(SkipExistingFilesTooltip)] =
                "При загрузке нескольких видео пропускать те, для которых файлы уже есть в папке назначения",
            [nameof(FileNameTemplateLabel)] = "Шаблон имени файла",
            [nameof(FileNameTemplateTooltip)] = """
                Шаблон для имён загружаемых видеофайлов.

                Доступные переменные:
                **$num** — номер видео в списке (если есть)
                **$id** — идентификатор видео
                **$title** — название видео
                **$author** — автор видео
                """,
            [nameof(ParallelLimitLabel)] = "Одновременные загрузки",
            [nameof(ParallelLimitTooltip)] = "Максимальное число одновременных загрузок",
            [nameof(FFmpegPathLabel)] = "Путь к FFmpeg",
            [nameof(FFmpegPathTooltip)] =
                "Путь к исполняемому файлу FFmpeg. Оставьте пустым для автоматического поиска.",
            [nameof(FFmpegPathPlaceholderText)] = "Автоматический поиск",
            [nameof(FFmpegPathResetTooltip)] = "Вернуть автоматический поиск",
            [nameof(FFmpegPathBrowseTooltip)] = "Выбрать исполняемый файл FFmpeg",
            // Auth Setup
            [nameof(AuthenticationTitle)] = "Авторизация",
            [nameof(AuthenticatedText)] = "Вы авторизованы",
            [nameof(LogOutButton)] = "Выйти",
            [nameof(LoadingText)] = "Загрузка...",
            // Download Single Setup
            [nameof(CopyMenuItem)] = "Копировать",
            [nameof(LiveLabel)] = "Трансляция",
            [nameof(AudioLabel)] = "Аудио",
            [nameof(UpscaledLabel)] = "Улучшенное разрешение",
            [nameof(FormatLabel)] = "Формат",
            // Download Multiple Setup
            [nameof(ContainerLabel)] = "Контейнер",
            [nameof(VideoQualityLabel)] = "Качество видео",
            // Common buttons
            [nameof(CloseButton)] = "ЗАКРЫТЬ",
            [nameof(DownloadButton)] = "СКАЧАТЬ",
            [nameof(CancelButton)] = "ОТМЕНА",
            // Dialog messages
            [nameof(UnstableBuildTitle)] = "Предупреждение о нестабильной сборке",
            [nameof(UnstableBuildMessage)] = """
                Вы используете тестовую сборку {0}. Такие сборки недостаточно проверены и могут содержать ошибки.

                Автоматические обновления для тестовых сборок отключены.

                Чтобы скачать стабильную версию, нажмите «ПЕРЕЙТИ К ВЫПУСКАМ».
                """,
            [nameof(SeeReleasesButton)] = "ПЕРЕЙТИ К ВЫПУСКАМ",
            [nameof(FFmpegMissingTitle)] = "FFmpeg не найден",
            [nameof(FFmpegMissingMessage)] = """
                FFmpeg не найден на вашем компьютере. Он необходим для работы {0}. Скачать его сейчас?

                Вы также можете закрыть это окно и указать путь к FFmpeg в настройках.
                """,
            [nameof(FFmpegDownloadingTitle)] = "Загрузка FFmpeg...",
            [nameof(FFmpegDownloadCompletedTitle)] = "FFmpeg загружен",
            [nameof(NothingFoundTitle)] = "Ничего не найдено",
            [nameof(NothingFoundMessage)] =
                "По указанному запросу или ссылке не удалось найти видео",
            [nameof(ErrorTitle)] = "Ошибка",
        };
}
