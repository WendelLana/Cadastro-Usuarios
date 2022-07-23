using wendel_d3_avaliacao.Models;

namespace wendel_d3_avaliacao.Interfaces
{
    internal interface ILog
    {
        void RegisterLogin(User user);
        void RegisterLogout(User user);
    }
}
