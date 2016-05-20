using System.Threading.Tasks;

using Analytics.Web.Api.Models;

namespace Analytics.Web.Api.InquiryProcessing
{
    public interface ILoginInquiryProcessor
    {
        Task<User> Login(string login, string password);
    }
}
