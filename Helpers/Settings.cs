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
        public static string IdUser
        {
            get => AppSettings.GetValueOrDefault("IdUser", SettingsDefault);
            set => AppSettings.AddOrUpdateValue("IdUser", value);
        }
        public static string Compte
        {
            get => AppSettings.GetValueOrDefault("Compte", SettingsDefault);
            set => AppSettings.AddOrUpdateValue("Compte", value);
        }
        public static string Nom
        {
            get => AppSettings.GetValueOrDefault("Nom", SettingsDefault);
            set => AppSettings.AddOrUpdateValue("Nom", value);
        }
        public static string Prenom
        {
            get => AppSettings.GetValueOrDefault("Prenom", SettingsDefault);
            set => AppSettings.AddOrUpdateValue("Prenom", value);
        }
        public static string UserRole
        {
            get => AppSettings.GetValueOrDefault("UserRole", SettingsDefault);
            set => AppSettings.AddOrUpdateValue("UserRole", value);
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
