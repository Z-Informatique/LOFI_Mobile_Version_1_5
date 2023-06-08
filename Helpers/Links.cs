using System.Text;

namespace LOFI.Helpers
{
    public class Links
    {
        //public const string BaseUrl = "https://lobima.infraone-group.com/api/";
        public const string BaseUrl = "http://192.168.100.245:90/api/";
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
        public const string ApproColor = "#4CAF50";
        public const string RetraitColor = "#FF5252";
        public const string TransfertColor = "#FFA000";
        public const string PayementColor = "#00796B";

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
        /**
         * API Key Suscription for MTN
         */
        public const string urlBasic = "https://sandbox.momodeveloper.mtn.com/";
        public const string urlVers = urlBasic + "v1_0/";

        public const string urlBcAuth = urlVers + "bc-authorize";
        public const string urlApiUser = urlVers + "apiuser";

        public const string targetEnvironment = "sandbox";

        /**
         * API DISBURSEMENT
         */
        public const string subscription_key_disbursement = "d080fb63fef44fb29a77ce17497023b8";

        /**
         * API REMITTANCE
         */
        public const string subscription_key_remittance = "c174255f76d347eaabd6d3b4216f2c52";
        public const string r_basic_auth =  $"{urlBasic}remittance/v1_0/bc-authorize";
        public const string r_token =  $"{urlBasic}remittance/token/";
        /**
         * API COLLECTION
         */
        public const string subscription_key_collection = "dc748fbca5fc4c018f44f6e0e78f218c";
























        public static string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes = Encoding.ASCII.GetBytes(toEncode);
            string one =  Convert.ToBase64String(toEncodeAsBytes);
            string two = Convert.ToBase64String(Encoding.UTF8.GetBytes(toEncode));
            return two;
        }

        public static string DecodeFrom64(string encodedData)
        {
            byte[] encodedDataAsBytes = Convert.FromBase64String(encodedData);
            return Encoding.ASCII.GetString(encodedDataAsBytes);
        }

    }
}
