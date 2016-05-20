using System.Threading.Tasks;

using Analytics.Web.Api.Models;

namespace Analytics.Web.Api.InquiryProcessing
{
    public interface IUserByIdInquiryProcessor
    {
        Task<User> GetUser(int id);
    }
}
