﻿using LabPreTest.Shared.Messages;
using System.Net;

namespace LabPreTest.Frontend.Repositories
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Response = response;
            Error = error;
            HttpResponseMessage = httpResponseMessage;
        }

        public T? Response { get; }
        public bool Error { get; }
        public HttpResponseMessage HttpResponseMessage { get; }

        public async Task<string?> GetErrorMessageAsync()
        {
            if (!Error)
            {
                return null;
            }

            var statusCode = HttpResponseMessage.StatusCode;
            if (statusCode == HttpStatusCode.NotFound)
            {
                return FrontendMessages.HttpNotFoundMessage;
            }
            if (statusCode == HttpStatusCode.BadRequest)
            {
                return await HttpResponseMessage.Content.ReadAsStringAsync();
            }
            if (statusCode == HttpStatusCode.Unauthorized)
            {
                return FrontendMessages.HttpUnauthorizedMessage;
            }
            if (statusCode == HttpStatusCode.Forbidden)
            {
                return FrontendMessages.HttpForbiddenMessage;
            }

            return FrontendMessages.HttpUnexpectedMessage;
        }
    }
}
