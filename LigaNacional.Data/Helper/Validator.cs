using System;
using System.Text.RegularExpressions;
using LigaNacional.Data.Logger;

namespace LigaNacional.Data.Helper
{
    public class Validator
    {
        public static bool IsValidEmail(string email)
        {
            try
            {
                if (email.IsNullOrEmpty())
                    return false;

                if (email.ToSafeString().ToUpper().Contains("Ñ"))
                    return false;

                var regex = new Regex("^((([a-z]|\\d|[!#\\$%&'\\*\\+\\-\\/=\\?\\^_`{\\|}~]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])+(\\.([a-z]|\\d|[!#\\$%&'\\*\\+\\-\\/=\\?\\^_`{\\|}~]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])+)*)|((\\x22)((((\\x20|\\x09)*(\\x0d\\x0a))?(\\x20|\\x09)+)?(([\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x7f]|\\x21|[\\x23-\\x5b]|[\\x5d-\\x7e]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])|(\\\\([\\x01-\\x09\\x0b\\x0c\\x0d-\\x7f]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF]))))*(((\\x20|\\x09)*(\\x0d\\x0a))?(\\x20|\\x09)+)?(\\x22)))@((([a-z]|\\d|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])|(([a-z]|\\d|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])([a-z]|\\d|-|\\.|_|~|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])*([a-z]|\\d|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])))\\.)+(([a-z]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])|(([a-z]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])([a-z]|\\d|-|\\.|_|~|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])*([a-z]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])))\\.?$", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled);

                return regex.IsMatch(email);
            }
            catch (Exception exception)
            {
                Log.WriteError(exception);
                return false;
            }
        }


        public static bool IsValidPassword(string clave, string claveConfirmacion)
        {
            if (clave.IsNullOrEmpty() || clave.Length < 6)
            {
                return false;
            }

            if (clave != claveConfirmacion)
            {
                return false;
            }

            return true;
        }

        public static ResponseMessage IsValidPassword_ResponseMessage(string password, string passwordConfirmation, string requestToken, string accessToken)
        {
            if (password.IsNullOrEmpty() || password.Length < 6)
            {
                return ResponseMessage.CreateResponseMessageError("You must specify a password. \nThe Password must be at least 6 characters.", requestToken, accessToken);
            }

            if (password != passwordConfirmation)
            {
                return ResponseMessage.CreateResponseMessageError("Passwords does not match.", requestToken, accessToken);
            }

            return null;
        }
    }
}