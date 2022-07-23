using wendel_d3_avaliacao.Interfaces;
using wendel_d3_avaliacao.Models;
using System.Text;

namespace wendel_d3_avaliacao.Repositories
{
    internal class LogRepository : ILog
    {
        private const string path = "database/log.txt";
        private readonly FileStream fileStream;

        public LogRepository(FileStream fileStream)
        {
            CreateFolderAndFile(path);
            this.fileStream = fileStream;
        }

        public static void CreateFolderAndFile(string path)
        {
            string folder = path.Split("/")[0];

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if (!File.Exists(path))
            {
                File.Create(path);
            }
        }

        public void RegisterLogin(User user)
        {
            string line = $"O usuário {user.Name} ({user.IdUser}) acessou o sistema às {DateTime.Now.Hour.ToString("D2")}:{DateTime.Now.Minute.ToString("D2")}:{DateTime.Now.Second.ToString("D2")} do dia {DateTime.Now.Day.ToString("D2")}/{DateTime.Now.Month.ToString("D2")}/{DateTime.Now.Year} \n";
            byte[] info = new UTF8Encoding(true).GetBytes(line);
            fileStream.Write(info);
        }

        public void RegisterLogout(User user)
        {
            string line = $"O usuário {user.Name} ({user.IdUser}) deslogou do sistema às {DateTime.Now.Hour.ToString("D2")}:{DateTime.Now.Minute.ToString("D2")}:{DateTime.Now.Second.ToString("D2")} do dia {DateTime.Now.Day.ToString("D2")}/{DateTime.Now.Month.ToString("D2")}/{DateTime.Now.Year} \n";
            byte[] info = new UTF8Encoding(true).GetBytes(line);
            fileStream.Write(info);
        }
    }
}
