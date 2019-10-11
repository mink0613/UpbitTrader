using CommonLibrary;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace UpbitTrader.UpbitAPI
{
    public class HttpAPI
    {
        private static readonly string _accessKey = "0GERxwf9zwW9uhXVsXC7REr5x4xZAVo6yxGFLnHK";

        private static readonly string _secretKey = "zxtAAMkbozDAIt4XnIYpr37esa0CAjLQsugshXcE";

        private static string _jwtToken;

        private static string GetJWTToken()
        {
            var payload = new JwtPayload
                {
                    { "access_key", _accessKey },
                    { "nonce", Guid.NewGuid().ToString() },
                };

            byte[] keyBytes = Encoding.Default.GetBytes(_secretKey);
            var securityKey = new SymmetricSecurityKey(keyBytes);
            var credentials = new SigningCredentials(securityKey, "HS256");
            var header = new JwtHeader(credentials);
            var secToken = new JwtSecurityToken(header, payload);

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(secToken);
            return "Bearer " + jwtToken;
        }

        private static string GetJWTToken(List<KeyValuePair<string, string>> parameters)
        {
            StringBuilder builder = new StringBuilder();
            foreach (KeyValuePair<string, string> pair in parameters)
            {
                builder.Append(pair.Key).Append("=").Append(pair.Value).Append("&");
            }
            string queryString = builder.ToString().TrimEnd('&');

            SHA512 sha512 = SHA512.Create();
            byte[] queryHashByteArray = sha512.ComputeHash(Encoding.UTF8.GetBytes(queryString));
            string queryHash = BitConverter.ToString(queryHashByteArray).Replace("-", "").ToLower();

            var payload = new JwtPayload
                {
                    { "access_key", _accessKey },
                    { "nonce", Guid.NewGuid().ToString() },
                    { "query_hash", queryHash },
                    { "query_hash_alg", "SHA512" }
                };

            byte[] keyBytes = Encoding.Default.GetBytes(_secretKey);
            var securityKey = new SymmetricSecurityKey(keyBytes);
            var credentials = new SigningCredentials(securityKey, "HS256");
            var header = new JwtHeader(credentials);
            var secToken = new JwtSecurityToken(header, payload);

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(secToken);
            return "Bearer " + jwtToken;
        }

        public static string GetAccount()
        {
            return Http.HttpRequestGet("https://api.upbit.com/v1/accounts", true, GetJWTToken());
        }

        public static string GetOrderChance(string[] markets)
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            foreach (string market in markets)
            {
                parameters.Add(new KeyValuePair<string, string>("market", market));
            }

            string param = "";
            foreach (string market in markets)
            {
                param += "market=" + market + "&";
            }

            param = param.TrimEnd('&');

            return Http.HttpRequestGet("https://api.upbit.com/v1/orders/chance?" + param, true, GetJWTToken(parameters));
        }

        public static string GetMarketAll()
        {
            return Http.HttpRequestGet("https://api.upbit.com/v1/market/all");
        }

        public static string GetTicker(string[] markets)
        {
            string param = "";
            foreach (string market in markets)
            {
                param += "markets=" + market + "&";
            }

            param = param.TrimEnd('&');

            return Http.HttpRequestGet("https://api.upbit.com/v1/ticker?" + param);
        }
    }
}
