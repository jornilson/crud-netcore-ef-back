using System.ComponentModel.DataAnnotations;

namespace Api_Crud_.NetCore_Pessoa.Helper
{
    public static class Utils
    {
        public static bool ValidarEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }
            if (new EmailAddressAttribute().IsValid(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
