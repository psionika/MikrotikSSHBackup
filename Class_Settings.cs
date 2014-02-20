using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Soap;


namespace MikrotikSSHBackup
{
    static class Settings
    {
        public static Boolean EnableEmail = false;

        public static Boolean EncryptEnable = false;
        public static String EncryptPassword = "";
    }

    static class SettingAction
    {
        public static void WriteXml()
        {
            var static_class = typeof(Settings);
            const string filename = "settings.xml";

            try
            {
                var fields = static_class.GetFields(BindingFlags.Static | BindingFlags.Public);

                object[,] a = new object[fields.Length, 2];
                var i = 0;
                foreach (var field in fields)
                {
                    a[i, 0] = field.Name;
                    a[i, 1] = field.GetValue(null);
                    i++;
                }
                Stream f = File.Open(filename, FileMode.Create);
                SoapFormatter formatter = new SoapFormatter();
                formatter.Serialize(f, a);
                f.Close();
            }
            catch
            {
            }
        }

        public static void ReadXml()
        {
            var static_class = typeof(Settings);
            const string filename = "settings.xml";

            try
            {
                var fields = static_class.GetFields(BindingFlags.Static | BindingFlags.Public);
                Stream f = File.Open(filename, FileMode.Open);
                SoapFormatter formatter = new SoapFormatter();
                object[,] a = formatter.Deserialize(f) as object[,];
                f.Close();
                if (a != null && a.GetLength(0) != fields.Length) return;
                var i = 0;
                foreach (var field in fields)
                {
                    if (a != null && field.Name == (a[i, 0] as string))
                    {
                        if (a[i, 1] != null)
                            field.SetValue(null, a[i, 1]);
                    }
                    i++;
                }
            }
            catch
            {
            }
        }
    }

}
