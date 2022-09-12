namespace LOFI.Helpers
{
    public class Links
    {
        public const string BaseUrl = "http://192.168.100.14:89/api/";
        public const string users = BaseUrl + "Users";
        public const string mouchars = BaseUrl + "Mouchars";
        public static string priceList = BaseUrl + "PriceLists";
        public static string pays = BaseUrl + "Pays";
        public static string categories = BaseUrl + "Categories";
        public static string Operateurs = BaseUrl + "Operateurs";
        public static string Methodes = BaseUrl + "Methodes";
        public static string Configs = BaseUrl + "Configs";
        public static string beneficiaires = BaseUrl + "Beneficiaires";
        public static string expediteurs = BaseUrl + "Expediteurs";
        public static string transactions = BaseUrl + "Transactions";
        public static string depenses = BaseUrl + "Depenses";
        public static string recettes = BaseUrl + "Recettes";
        public static string bilans = BaseUrl + "Bilans";
        public static string comptes = BaseUrl + "Comptes";
        public static string transferts = BaseUrl + "Transferts";
        public static string historiques = BaseUrl + "Historiques";

        /**
         * Type d'opération
         */
        public const string Appro = "Approvisionnement";
        public const string Retrait = "Retrait";
        public const string Transfert = "Transfert";
        public const string Transfert_recu = "Transfert reçu";
        public const string Transfert_sortant = "Transfert sortant";

        /**
         * Color
         */
        public const string ApproColor = "#72ACF1";
        public const string RetraitColor = "#fbc304";
        public const string TransfertColor = "#28C2D1";
        public const string PayementColor = "#4b5f60";

        /**
         * Titre Operation
         */

        public const string OpAppro = "recharge";
        public const string OpRetrait = "retiré";
        public const string OpTransfert_recu = "reçu";
        public const string OpTransfert_sortant = "envoye";
        /**
         * Type de transfert domestique
         */
        public const string Mtn_mtn = "MM";
        public const string Mtn_airtel = "MA";
        public const string Airtel_Mtn = "AM";
        public const string Airtel_Airtel = "AA";
        public const string Orange_Mtn = "OM";
        public const string Mtn_Orange = "MO";
        public const string Orange_Orange = "OO";

    }
}
