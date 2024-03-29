﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MetriFit;

    public class JwtProvider : IJwtProvider
    {
        private readonly AccessOptions _jwtAccessOptions;
        private readonly RefreshOptions _jwtRefreshTokenOptions;
        public JwtProvider(IOptions<AccessOptions> jwtAccessOptions, IOptions<RefreshOptions> jwtRefreshOptions)
        {
            _jwtAccessOptions = jwtAccessOptions.Value;
            _jwtRefreshTokenOptions = jwtRefreshOptions.Value;
        }
        private string TokenGenerator(
            string secretKey,
            List<Claim>? claims,
            String? issuer,
            String? audiance,
            DateTime ExDate)
        {
            var SigningCredential = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)), SecurityAlgorithms.HmacSha256
            );
            var token = new JwtSecurityToken(
                issuer,
                audiance,
                claims,
                null,
                ExDate,
                SigningCredential);

            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue;
        }
        public string GetAccessToken(User user)
        {
            if( user == null || user.Role == null )
            {
                throw new ArgumentNullException("user");
            }
            var claims = new List<Claim>()
            {
                new ("Id", user.Id.ToString()),
                new(JwtRegisteredClaimNames.Name, $"{ user.FirstName }{ user.LastName}"),
                new (ClaimTypes.Role, user.Role),
            };

            if (string.IsNullOrEmpty(_jwtAccessOptions.SecretKey))
                throw new ArgumentNullException("invalid Access options");

            string token = TokenGenerator(
                _jwtAccessOptions.SecretKey,
                claims,
                 null,
                null,
                DateTime.UtcNow.AddMinutes(_jwtAccessOptions.ExpireTimeInMintes));
            return token;
        }

        public string GetRefreshtoken()
        {
            if (string.IsNullOrEmpty(_jwtRefreshTokenOptions.SecretKey))
            {
                throw new InvalidOperationException("JWT refresh token configuration is invalid");
            }
           
            string token = TokenGenerator(
                _jwtRefreshTokenOptions.SecretKey,
                null,
                null,
                null,
                DateTime.UtcNow.AddMonths(_jwtRefreshTokenOptions.ExpireTimeInMonths));
            return token;
        }

    }

