using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Analytics.Web.Api.Models;
using Analytics.Web.Api.InquiryProcessing;

namespace Analytics.Web.Api.Controllers
{
    public class UserController : ApiController
    {
        private readonly ILoginInquiryProcessor _loginProcessor;
        private readonly IUserByIdInquiryProcessor _userProcessor;

        public UserController(ILoginInquiryProcessor loginProcessor, IUserByIdInquiryProcessor userProcessor)
        {
            _loginProcessor = loginProcessor;
            _userProcessor = userProcessor;
        }

        //[Route("{login:string}", Name = "GetUserRoute")]
        public async Task<User> GetUser(int id)
        {
            //var user = await _loginProcessor.Login(id, "test");
            var user = await _userProcessor.GetUser(id);

            return user;
        }
    }
}
