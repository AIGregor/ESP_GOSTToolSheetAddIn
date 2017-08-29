using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Reflection;

namespace ESP_GOSTToolSheetAddIn
{
    class SecurityFile
    {
        private string md5LicCode = "";

        private string generateLicCode(string resString)
        {
            MD5 md5Lic = new MD5CryptoServiceProvider();
            Connect.logger.Info("Генерация лицензии");

            byte[] checkSum = md5Lic.ComputeHash(Encoding.UTF8.GetBytes(resString));
            string md5Code = BitConverter.ToString(checkSum).Replace("-", String.Empty);
            return md5Code;
        }

        // Сравнение файла лицензии и лицензии документа
        public bool mergeLicFiles()
        {
            bool result = false;            
            md5LicCode = generateLicCode(Connect.sEspApp.LicenseKey);
            // eal - esprit addin license
            Connect.logger.Info("Чтение файла лицензии");

            try
            {
                using (StreamReader fl = new StreamReader(Connect.assemblyFolder + @"\Resources\lic.eal"))
                {
                    while (true)
                    {
                        // Читаем строку из файла во временную переменную.
                        string temp = fl.ReadLine();
                        // Если достигнут конец файла, прерываем считывание. 
                        if (temp == null)
                            break; 

                        if (string.Equals(temp, md5LicCode))
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception E)
            {
                Connect.logger.Error("Ошибка при проверке лицензии " + E.Message);
            }

            return result;
        }
    }

}