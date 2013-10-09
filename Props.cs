using System;
using System.Xml.Serialization;
using System.IO;

namespace MikrotikSSHBackup
{
    public class PropsFields
    {
        public String EmailServer = @"test";
        public Boolean EnableEmail = false;        
        public String EmailPort = @"test";
        public Boolean EnableEmailSSL = false;
        public String EmailUser = @"test";
        public String EmailPassowrd = @"test";
        public String EmailAddress = @"test";
    }

  //Класс работы с настройками
    public class Props
    {
        public PropsFields Fields;

        public Props()
        {
            Fields = new PropsFields();
        }

        //Запист настроек в файл
        public void WriteXml()
        {
            XmlSerializer ser = new XmlSerializer(typeof(PropsFields));
            TextWriter writer = new StreamWriter(System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("MikrotikSSHBackup.exe", "") + "settings.xml");
            ser.Serialize(writer, Fields);
            writer.Close();
        }

        //Чтение настроек из файла
        public void ReadXml()
        {
            if (File.Exists(System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("MikrotikSSHBackup.exe", "") + "settings.xml"))
            {
                XmlSerializer ser = new XmlSerializer(typeof(PropsFields));
                TextReader reader = new StreamReader(System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("MikrotikSSHBackup.exe", "") + "settings.xml");
                Fields = ser.Deserialize(reader) as PropsFields;
                reader.Close();
            }
            else { }
        }
    }



 }

