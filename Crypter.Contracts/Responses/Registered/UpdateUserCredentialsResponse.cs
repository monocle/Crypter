﻿using Crypter.Contracts.Enum;

namespace Crypter.Contracts.Responses.Registered
{
    public class UpdateUserCredentialsResponse : BaseResponse
    {
        /// <summary>
        /// Do not use!
        /// For deserialization purposes only.
        /// </summary>
        public UpdateUserCredentialsResponse()
        { }

        /// <summary>
        /// Error response
        /// </summary>
        /// <param name="status"></param>
        public UpdateUserCredentialsResponse(ResponseCode status) : base(status)
        { }
    }
}