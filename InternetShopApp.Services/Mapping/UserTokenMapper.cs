using System;

namespace InternetShopApp.Services.Mapping
{
    public static class UserTokenMapper
    {
        public static Domain.Entities.UserToken MapToDomain(Data.Entities.UserToken dataUserToken)
        {
            return new Domain.Entities.UserToken
            {
                Id = dataUserToken.Id,
                UserId = dataUserToken.UserId,
                Token = dataUserToken.Token,
                ExpiresAt = dataUserToken.ExpiresAt,
                CreatedAt = dataUserToken.CreatedAt,
                CreatedByIp = dataUserToken.CreatedByIp,
                RevokedAt = dataUserToken.RevokedAt,
                RevokedByIp = dataUserToken.RevokedByIp
            };
        }

        public static Data.Entities.UserToken MapToData(Domain.Entities.UserToken domainUserToken)
        {
            return new Data.Entities.UserToken
            {
                Id = domainUserToken.Id,
                UserId = domainUserToken.UserId,
                Token = domainUserToken.Token,
                ExpiresAt = domainUserToken.ExpiresAt,
                CreatedAt = domainUserToken.CreatedAt,
                CreatedByIp = domainUserToken.CreatedByIp,
                RevokedAt = domainUserToken.RevokedAt,
                RevokedByIp = domainUserToken.RevokedByIp
            };
        }
    }
}

