using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace DAL.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUserEntity>
    {
        public ApplicationUserManager(IUserStore<ApplicationUserEntity> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<ApplicationUserEntity> passwordHasher,
            IEnumerable<IUserValidator<ApplicationUserEntity>> userValidators,
            IEnumerable<IPasswordValidator<ApplicationUserEntity>> passwordValidators, 
            ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, 
            IServiceProvider services, ILogger<UserManager<ApplicationUserEntity>> logger) : base(
            store, optionsAccessor, passwordHasher, userValidators, passwordValidators, 
            keyNormalizer, errors, services, logger)
        {
        }
    }
}
