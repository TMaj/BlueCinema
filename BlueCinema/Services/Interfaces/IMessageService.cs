using System.Threading.Tasks;

namespace BlueCinema.Services.Interfaces
{
    public interface IMessageService
    {
        Task Send(string email, string subject, string message);
    }
}
