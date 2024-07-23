using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace RingoMedia.Web.Authentication.JwtBearer
{
    public class AsyncJwtBearerOptions : JwtBearerOptions
    {
        public readonly List<IAsyncSecurityTokenValidator> AsyncSecurityTokenValidators;
        
        private readonly RingoMediaAsyncJwtSecurityTokenHandler _defaultAsyncHandler = new RingoMediaAsyncJwtSecurityTokenHandler();

        public AsyncJwtBearerOptions()
        {
            AsyncSecurityTokenValidators = new List<IAsyncSecurityTokenValidator>() {_defaultAsyncHandler};
        }
    }

}
