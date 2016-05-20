using System.Threading.Tasks;

using Analytics.Common.TypeMapping;

using Analytics.Data.Exceptions;
using Analytics.Data.QueryProcessors;

using Analytics.Web.Api.Models;

namespace Analytics.Web.Api.InquiryProcessing
{
    public class LoginInquiryProcessor : ILoginInquiryProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IUserByLoginQueryProcessor _queryProcessor;

        public LoginInquiryProcessor(IAutoMapper autoMapper, IUserByLoginQueryProcessor queryProcessor)
        {
            _autoMapper = autoMapper;
            _queryProcessor = queryProcessor;
        }

        public async Task<Models.User> Login(string login, string password)
        {
            var userEntity = await _queryProcessor.GetUserAsync(login);

            if (userEntity != null && string.Compare(userEntity.Password, password) == 0)
            {
                var user = _autoMapper.Map<Models.User>(userEntity);
                return user;
            }
            else
            {
                throw new RootObjectNotFoundException("User not found");
            }
        }
    }
}