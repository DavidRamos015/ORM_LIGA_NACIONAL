using System;
using LigaNacional.Domain;


namespace LigaNacional.Data.Helper
{
    public class ResponseMessage : IResponseMessage
    {
        public virtual char Successfully { get; set; }
        public virtual string Message { get; set; }
        public virtual string TechnicalError { get; set; }
        public virtual string StackTrace { get; set; }
        public virtual string RequestToken { get; set; }
        public virtual string AccessToken { get; set; }

        private static ResponseMessage CreateResponseMessage(ExecutionResponse executionResponse, string message, string technicalError, string stackTrace, string requestToken, string accessToken)
        {
            var response = new ResponseMessage
            {
                Successfully = executionResponse == ExecutionResponse.Successfully ? 'S' : 'N',
                Message = message,
                TechnicalError = technicalError,
                StackTrace = stackTrace,
                RequestToken = requestToken,
                AccessToken = accessToken
            };

            return response;
        }

        public static ResponseMessage CreateResponseMessageError(string customMessage, string requestToken, string accessToken)
        {
            return CreateResponseMessage(ExecutionResponse.Failed, customMessage, "", "", requestToken, accessToken);
        }

        public static ResponseMessage CreateResponseMessageError(string customMessage, IBaseModel model)
        {
            if (model.IsNullOrEmpty())
                return CreateResponseMessage(ExecutionResponse.Failed, customMessage, "", "", "", "");

            return CreateResponseMessage(ExecutionResponse.Failed, customMessage, "", "", model.RequestToken, model.AccessToken);
        }

        public static ResponseMessage CreateResponseMessageError(Exception exception, string requestToken, string accessToken)
        {
            return CreateResponseMessage(ExecutionResponse.Failed, "Error", exception.Message, exception.StackTrace, requestToken, accessToken);
        }

        public static ResponseMessage CreateResponseMessageError(string customMessage, Exception exception, string requestToken, string accessToken)
        {
            return CreateResponseMessage(ExecutionResponse.Failed, customMessage, exception.Message, exception.StackTrace, requestToken, accessToken);
        }

        public static ResponseMessage CreateResponseMessageOk(string customMessage, string requestToken, string accessToken)
        {
            return CreateResponseMessage(ExecutionResponse.Successfully, customMessage, "", "", requestToken, accessToken);
        }

        public static ResponseMessage CreateResponseMessageOk(string requestToken, string accessToken)
        {
            return CreateResponseMessage(ExecutionResponse.Successfully, "", "", "", requestToken, accessToken);
        }

        public static ResponseMessage CreateResponseMessageLoginRequired(IToken model)
        {
            var msj = Utility.MsjNeedToLogin;

            if (model.IsNullOrEmpty())
                return CreateResponseMessage(ExecutionResponse.LoginRequired, msj, "", "", "", "");

            return CreateResponseMessage(ExecutionResponse.LoginRequired, msj, "", "", model.RequestToken, model.AccessToken);
        }



    }
}