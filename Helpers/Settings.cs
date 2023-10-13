using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace LOFI.Helpers
{
    public class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;

        #endregion

        public static string Token
        {
            get => AppSettings.GetValueOrDefault("Token", SettingsDefault);
            set => AppSettings.AddOrUpdateValue("Token", value);
        }
        public static string User
        {
            get => AppSettings.GetValueOrDefault("User", SettingsDefault);
            set => AppSettings.AddOrUpdateValue("User", value);
        }
        public static string Compte
        {
            get => AppSettings.GetValueOrDefault("Compte", SettingsDefault);
            set => AppSettings.AddOrUpdateValue("Compte", value);
        }
        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }
    }
}
