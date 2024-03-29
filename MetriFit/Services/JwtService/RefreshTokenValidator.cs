﻿using System.IdentityModel.Tokens.Jwt;

namespace MetriFit;

    public class RefreshTokenValidator
    {
       private readonly RefreshOptions _refreshOptions;

        public RefreshTokenValidator(IOptions<RefreshOptions> refreshOption)
        {
            _refreshOptions = refreshOption.Value;

        }
        public bool Validate(string refreshToken)
        {
            if(_refreshOptions.SecretKey == null)
                throw new ArgumentNullException(nameof(refreshToken));

            TokenValidationParameters validationParameter = new TokenValidationParameters()
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_refreshOptions.SecretKey))
                , ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false
            };
            JwtSecurityTokenHandler jwtTokenHandler = new JwtSecurityTokenHandler();

            try
            {
                jwtTokenHandler.ValidateToken(refreshToken, validationParameter, out SecurityToken validatedToken);
                    return true;
            }
            catch
            {
                return false;
            }
        }
    }

