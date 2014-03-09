using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DigitalResourcesLibrary.SqlContext.Scheme
{
    public class CreateDB
    {
        private List<String> fileNames = new List<string>
            {
                "1DropTable.sql",
                "2StartTable.sql",
                "3user.sql",
                "4tagloc.sql",
                "5category.sql",
                "6article.sql",
                "7store.sql"
            };

        private string pathFolder = @"E:\Diplom\GrodnoOnlineLibrary\DigitalResourcesLibrary\DigitalResourcesLibrary.SqlContext\Scheme\Scripts";

        public string ConnectingString = "server=localhost;user id=root;password=root;persistsecurityinfo=True;database=digitalresourceslibrary";
        public string ConnectingString1 = "server=0c0a44d5-38e4-485f-a805-a2d7015a8542.mysql.sequelizer.com;database=db0c0a44d538e4485fa805a2d7015a8542;uid=gjasovdawjqgvvkf;pwd=kAamz7vSCsKcFfokpeWgvcUr8PUsUyRK4HnMMM3rbqpppgBWgBaUbrYhNQmSkc6e";

        public void RunScript()
        {
            MySqlConnection connection = new MySqlConnection(ConnectingString);

            foreach (var fileName in fileNames)
            {
                string pathFile = pathFolder + "\\" + fileName;
                FileInfo file = new FileInfo(pathFile);
                string scriptFile = file.OpenText().ReadToEnd();

                MySqlScript script = new MySqlScript(connection, scriptFile);
                script.Delimiter = "$$";
                script.Execute();
            }
        }
    }
}
