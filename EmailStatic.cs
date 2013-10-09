using System;

namespace MikrotikSSHBackup
{
    static class EmailStatic
    {
        public static Boolean EnableEmail { get; set; }
        public static String EmailServer { get; set; }
        public static String EmailPort { get; set; }
        public static Boolean EnableEmailSSL { get; set; }
        public static String EmailUser { get; set; }
        public static String EmailPassowrd { get; set; }
        public static String EmailAddress { get; set; }
    }
}