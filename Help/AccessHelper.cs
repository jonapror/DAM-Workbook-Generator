
using System;
using System.Text;

namespace Aprimo.ConfigurationWorkbookGenerator.Helpers
{
    public class AccessHelper
    {
        private string userName;
        private string clientToken;
        private string encodedToken;
        private string tokenEndpoint;
        private string clientId;
        private string accessToken;
        private string refreshToken;

        public AccessHelper(string userName, string clientToken, string tokenEndpoint, string clientId, string password = "", string registration = "")
        {
            this.userName = userName;
            this.clientToken = clientToken;
            this.clientId = clientId;
            this.tokenEndpoint = tokenEndpoint;
        }
        public string GetToken()
        {
            if (!string.IsNullOrEmpty(accessToken))
            {
                return accessToken;
            }

            encodedToken = Convert.ToBase64String(
            Encoding.UTF8.GetBytes(string.Format("{0}:{1}", userName, clientToken)));
            try
            {
                accessToken = JsonHelper.GetAccessToken(encodedToken, tokenEndpoint, clientId, ref refreshToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return accessToken;
        }

        public string GetRefreshedToken()
        {
            try
            {
                accessToken = JsonHelper.RefreshToken(encodedToken, tokenEndpoint, clientId, refreshToken);
            }
            catch (Exception)
            {
                //if exception happens when refresshing token, then the original token has expired, get a new one
                accessToken = JsonHelper.GetAccessToken(encodedToken, tokenEndpoint, clientId, ref refreshToken);
            }
            return accessToken;
        }
    }
}
