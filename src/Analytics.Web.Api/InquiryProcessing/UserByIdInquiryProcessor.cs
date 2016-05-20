using System.Threading.Tasks;

using Analytics.Common.TypeMapping;

using Analytics.Data.Exceptions;
using Analytics.Data.QueryProcessors;


namespace Analytics.Web.Api.InquiryProcessing
{
    public class UserByIdInquiryProcessor : IUserByIdInquiryProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IUserByIdQueryProcessor _queryProcessor;

        public UserByIdInquiryProcessor(IAutoMapper autoMapper, IUserByIdQueryProcessor queryProcessor)
        {
            _autoMapper = autoMapper;
            _queryProcessor = queryProcessor;
        }

        public async Task<Models.User> GetUser(int id)
        {
            var userEntity = await _queryProcessor.GetUserAsync(id);

            if (userEntity != null)
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