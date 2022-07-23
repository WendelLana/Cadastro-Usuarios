using wendel_d3_avaliacao.Models;

namespace wendel_d3_avaliacao.Interfaces
{
    internal interface IUser
    {
        User? Login(String email, String password);

        void Create(User product);
    }
}
