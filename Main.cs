using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using Community.PowerToys.Run.Plugin.DeepLTranslator.Enums;
using Community.PowerToys.Run.Plugin.DeepLTranslator.Models;

using ManagedCommon;

using Microsoft.PowerToys.Settings.UI.Library;

using Wox.Infrastructure.Storage;
using Wox.Plugin;

using static Microsoft.PowerToys.Settings.UI.Library.PluginAdditionalOption;

namespace Community.PowerToys.Run.Plugin.DeepLTranslator
{
    public class Main : IPlugin, IPluginI18n, ISavable, IContextMenu, IDisposable, ISettingProvider
    {
        private const string DeeplAPIKey = nameof(DeeplAPIKey);

        private static readonly PluginJsonStorage<DeepLTranslatorSetting> Storage = new PluginJsonStorage<DeepLTranslatorSetting>();
        private static readonly DeepLTranslatorSetting Settings = Storage.Load();

        public static string PluginID => "a26e662baee34320bf1e288543240c66";

        public string Name => Properties.Resources.plugin_name;

        public string Description => Properties.Resources.plugin_description;

        private static string iconPath;

        private PluginInitContext context;

        private bool disposed;

        public void Init(PluginInitContext context)
        {
            ArgumentNullException.ThrowIfNull(context);
            this.context = context;
            this.context.API.ThemeChanged += OnThemeChanged;
            UpdateIconPath(this.context.API.GetCurrentTheme());
        }

        public IEnumerable<PluginAdditionalOption> AdditionalOptions => new List<PluginAdditionalOption>()
        {
            new PluginAdditionalOption()
            {
                TextValue = Settings.DeeplAPIKey,
                PluginOptionType = AdditionalOptionType.Textbox,
                Key = DeeplAPIKey,
                DisplayLabel = "ClientId",
                DisplayDescription = Properties.Resources.deepL_api_key_description,
            },
        };

        public List<ContextMenuResult> LoadContextMenus(Result selectedResult)
        {
            if (!(selectedResult?.ContextData is TranslationResult))
            {
                return new List<ContextMenuResult>();
            }

            List<ContextMenuResult> contextResults = new List<ContextMenuResult>();
            TranslationResult result = selectedResult.ContextData as TranslationResult;
            if (result != null)
            {
                contextResults.Add(this.CreateContextMenuEntry(result));
            }
            else
            {
                contextResults.Add(CreateContextMenuEntry(
                    new TranslationResult
                    {
                        Translations =
                            [
                                new Translation{
                                    DetectedSourceLanguage = LangCodeEnums.ToString(LangCodeEnums.Code.UNK),
                                    Text = Properties.Resources.error_message_during_translation
                                }
                            ],
                        TargetLangCode = LangCodeEnums.ToString(LangCodeEnums.Code.UNK)
                    }));
            }

            return contextResults;
        }

        public List<Result> Query(Query query)
        {
            ArgumentNullException.ThrowIfNull(query);

            var (targetCode, text) = InputInterpreter.Parse(query);

            if (targetCode == LangCodeEnums.Code.UNK)
            {
                return new List<Result>();
            }

            return TranslationHandler.Convert(targetCode, text, Settings)
                .Select(this.GetResult)
                .ToList();
        }

        public Control CreateSettingPanel()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            Storage.Save();
        }

        public void UpdateSettings(PowerLauncherPluginSettings settings)
        {
            if (settings.AdditionalOptions != null)
            {
                var apiKey = settings.AdditionalOptions.FirstOrDefault(x => x.Key == DeeplAPIKey)?.TextValue ?? string.Empty;

                Main.Settings.DeeplAPIKey = apiKey;
            }
        }

        public string GetTranslatedPluginTitle()
        {
            return Properties.Resources.plugin_name;
        }

        public string GetTranslatedPluginDescription()
        {
            return Properties.Resources.plugin_description;
        }

        public void Dispose()
        {
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (this.context != null && this.context.API != null)
                    {
                        this.context.API.ThemeChanged -= OnThemeChanged;
                    }

                    this.disposed = true;
                }
            }
        }

        private static void UpdateIconPath(Theme theme)
        {
            if (theme == Theme.Light || theme == Theme.HighContrastWhite)
            {
                iconPath = "Images/DeepL_Logo.png";
            }
            else
            {
                iconPath = "Images/DeepL_Logo.png";
            }
        }

        private static void OnThemeChanged(Theme oldTheme, Theme newTheme)
        {
            UpdateIconPath(newTheme);
        }

        private ContextMenuResult CreateContextMenuEntry(TranslationResult result)
        {
            return new ContextMenuResult
            {
                PluginName = this.Name,
                Title = Properties.Resources.context_menu_copy,
                Glyph = "\xE8C8",
                FontFamily = "Segoe MDL2 Assets",
                AcceleratorKey = Key.Enter,
                Action = _ =>
                {
                    bool ret = false;
                    var thread = new Thread(() =>
                    {
                        try
                        {
                            if (result.Translations != null)
                            {
                                Clipboard.SetText(result.Translations[0].Text);
                                ret = true;
                            }
                        }
                        catch (ExternalException)
                        {
                        }
                    });
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                    thread.Join();
                    return ret;
                },
            };
        }

        private Result GetResult(TranslationResult result)
        {
            if (Settings.DeeplAPIKey == string.Empty)
            {
                return new Result
                {
                    Title = Properties.Resources.invalid_api_key,
                    IcoPath = iconPath,
                    Score = 300,
                    SubTitle = string.Empty,
                };
            }

            return new Result
            {
                ContextData = result,
                Title = $"{result.Translations[0].DetectedSourceLanguage} -> {result.TargetLangCode} : {result.Translations[0].Text}",
                IcoPath = iconPath,
                Score = 300,
                SubTitle = Properties.Resources.copy_to_clipboard,
                Action = c =>
                {
                    var ret = false;
                    var thread = new Thread(() =>
                    {
                        try
                        {
                            Clipboard.SetText(result.Translations[0].Text);
                            ret = true;
                        }
                        catch (ExternalException e)
                        {
                            MessageBox.Show(e.Message);
                        }
                    });
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                    thread.Join();
                    return ret;
                },
            };
        }
    }
}
