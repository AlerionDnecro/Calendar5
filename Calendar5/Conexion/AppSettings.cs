using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calendar5.Conexion
{
    public static class AppSettings
    {

        static AppEnvironment Environment = AppEnvironment.Develop;

        public static string AppUrl =
            Environment == AppEnvironment.Production ? "https://datosmedix.net" :
            Environment == AppEnvironment.Staging ? "http://osbellugo-001-site2.gtempurl.com" :
            Environment == AppEnvironment.Develop ? "https://datosmedixv1-staging.gear.host" :
            Environment == AppEnvironment.Localhost ? "https://localhost:44357" :
            "https://localhost:44357";

        public static string DirectoryURL =
          Environment == AppEnvironment.Production ? $"http://osbellugo-001-site4.gtempurl.com" :
          Environment == AppEnvironment.Staging ? $"http://osbellugo-001-site1.gtempurl.com" :
          Environment == AppEnvironment.Develop ? $"http://osbellugo-001-site3.gtempurl.com" :
          Environment == AppEnvironment.Localhost ? $"https://localhost:44367" :
          $"https://localhost:44367";

        public static string DbHost =
            Environment == AppEnvironment.Production ? "den1.mssql3.gear.host" :
            Environment == AppEnvironment.Staging ? "sql5053.site4now.net" :
            Environment == AppEnvironment.Develop ? "den1.mssql7.gear.host" :
            Environment == AppEnvironment.Localhost ? "localhost" :
            "localhost";

        public static string DbName =
            Environment == AppEnvironment.Production ? "med" :
            Environment == AppEnvironment.Staging ? "db_a7bae2_medtest" :
            Environment == AppEnvironment.Develop ? "medtest" :
            Environment == AppEnvironment.Localhost ? "MED" :
            "MED2";

        public static string DbUser =
            Environment == AppEnvironment.Production ? "med" :
            Environment == AppEnvironment.Staging ? "db_a7bae2_medtest_admin" :
            Environment == AppEnvironment.Develop ? "medtest" :
            Environment == AppEnvironment.Localhost ? "sa" :
            "sa";

        public static string DbPassword =
            Environment == AppEnvironment.Production ? "Xh5e~A1Y_HuP" :
            Environment == AppEnvironment.Staging ? "Rb29-O0q62!q" :
            Environment == AppEnvironment.Develop ? "Vy1r!qM~Qk1z" :
            Environment == AppEnvironment.Localhost ? "130485" :
            "130485";

        public static string CnnStr =
            Environment == AppEnvironment.Production ? $"Data Source={DbHost};User ID={DbUser};Password={DbPassword};Initial Catalog={DbName};Connection Timeout=100;Persist Security Info=True;Connect Timeout=100" :
            Environment == AppEnvironment.Staging ? $"Server={DbHost};Database={DbName};User={DbUser};Password={DbPassword};" :
            Environment == AppEnvironment.Develop ? $"Server={DbHost};Initial Catalog={DbName};Persist Security Info=False;User ID={DbUser};Password={DbPassword};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;" :
            Environment == AppEnvironment.Localhost ? $"Data Source={DbHost};User ID={DbUser};Password={DbPassword};Initial Catalog={DbName};Connection Timeout=100;Persist Security Info=True;Connect Timeout=100" :
            $"Data Source={DbHost};User ID={DbUser};Password={DbPassword};Initial Catalog={DbName};Connection Timeout=100;Persist Security Info=True;Connect Timeout=100";

        public static string StrIdDB =
            Environment == AppEnvironment.Production ? "PRO" :
            Environment == AppEnvironment.Staging ? "STAG" :
            Environment == AppEnvironment.Develop ? "DEV" :
            Environment == AppEnvironment.Localhost ? "LOC" :
            "LOC2";

        public static string ResetPasswordURL =
            Environment == AppEnvironment.Production ? $"http://osbellugo-001-site4.gtempurl.com/api/account/resetpasswordapp" :
            Environment == AppEnvironment.Staging ? $"http://osbellugo-001-site1.gtempurl.com/api/account/resetpasswordapp" :
            Environment == AppEnvironment.Develop ? $"http://osbellugo-001-site3.gtempurl.com/api/account/resetpasswordapp" :
            Environment == AppEnvironment.Localhost ? $"https://localhost:44367/api/account/resetpasswordapp" :
            $"https://localhost:44367/api/account/resetpasswordapp";

        public static string InvoicePublicViewURL =
            Environment == AppEnvironment.Production ? $"http://osbellugo-001-site4.gtempurl.com/note-view/" :
            Environment == AppEnvironment.Staging ? $"http://osbellugo-001-site1.gtempurl.com/note-view/" :
            Environment == AppEnvironment.Develop ? $"http://osbellugo-001-site3.gtempurl.com/note-view/" :
            Environment == AppEnvironment.Localhost ? $"https://localhost:44367/note-view/" :
            $"https://localhost:44367/note-view/";

        public static string AccountStatementURL =
            Environment == AppEnvironment.Production ? $"http://osbellugo-001-site4.gtempurl.com/account-statement/" :
            Environment == AppEnvironment.Staging ? $"http://osbellugo-001-site1.gtempurl.com/account-statement/" :
            Environment == AppEnvironment.Develop ? $"http://osbellugo-001-site3.gtempurl.com/account-statement/" :
            Environment == AppEnvironment.Localhost ? $"https://localhost:44367/account-statement/" :
            $"https://localhost:44367/account-statement/";

        public static string DirectorioUrl =
            Environment == AppEnvironment.Production ? "http://osbellugo-001-site4.gtempurl.com" :
            Environment == AppEnvironment.Staging ? "http://osbellugo-001-site1.gtempurl.com" :
            Environment == AppEnvironment.Develop ? "http://osbellugo-001-site3.gtempurl.com" :
            Environment == AppEnvironment.Localhost ? "http://localhost:44869" :
            "http://localhost:44869";

        #region Configuraciones API gearhost (Email)

        public static string EmailHost =
            Environment == AppEnvironment.Production ? "mail.datosmedix.com" :
            Environment == AppEnvironment.Staging ? "mail.datosmedix.com" :
            Environment == AppEnvironment.Develop ? "mail.datosmedix.com" :
            Environment == AppEnvironment.Localhost ? "mail.datosmedix.com" :
            "mail.datosmedix.com";

        public static string EmailFrom =
            Environment == AppEnvironment.Production ? "info@datosmedix.com" :
            Environment == AppEnvironment.Staging ? "info@datosmedix.com" :
            Environment == AppEnvironment.Develop ? "info@datosmedix.com" :
            Environment == AppEnvironment.Localhost ? "info@datosmedix.com" :
            "info@datosmedix.com";

        public static string EmailPassword =
            Environment == AppEnvironment.Production ? "Support@24h" :
            Environment == AppEnvironment.Staging ? "Support@24h" :
            Environment == AppEnvironment.Develop ? "Support@24h" :
            Environment == AppEnvironment.Localhost ? "Support@24h" :
            "Support@24h";

        public static bool EmailIsBodyHtml =
            Environment == AppEnvironment.Production ? true :
            Environment == AppEnvironment.Staging ? true :
            Environment == AppEnvironment.Develop ? true :
            Environment == AppEnvironment.Localhost ? true :
            true;

        public static bool EmailEnableSsl =
            Environment == AppEnvironment.Production ? false :
            Environment == AppEnvironment.Staging ? false :
            Environment == AppEnvironment.Develop ? false :
            Environment == AppEnvironment.Localhost ? false :
            false;

        public static bool EmailUseDefaultCredentials =
            Environment == AppEnvironment.Production ? true :
            Environment == AppEnvironment.Staging ? true :
            Environment == AppEnvironment.Develop ? true :
            Environment == AppEnvironment.Localhost ? true :
            true;

        public static int EmailPort =
            Environment == AppEnvironment.Production ? 25 :
            Environment == AppEnvironment.Staging ? 25 :
            Environment == AppEnvironment.Develop ? 25 :
            Environment == AppEnvironment.Localhost ? 25 :
            25;

        #endregion Configuraciones API gearhost (Email)
    }

}
