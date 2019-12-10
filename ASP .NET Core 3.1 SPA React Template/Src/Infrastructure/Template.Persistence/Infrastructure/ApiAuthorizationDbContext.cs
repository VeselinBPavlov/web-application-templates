﻿namespace Template.Persistence.Infrastructure
{
    using IdentityServer4.EntityFramework.Options;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;

    /// <summary>
    /// Database abstraction for a combined <see cref="DbContext"/> using ASP.NET Identity and Identity Server.
    /// </summary>
    /// <typeparam name="TUser"></typeparam>
    public class ApiAuthorizationDbContext<TUser, TRole> : KeyApiAuthorizationDbContext<TUser, TRole, string>
        where TUser : IdentityUser
        where TRole : IdentityRole
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ApiAuthorizationDbContext{TUser}"/>.
        /// </summary>
        /// <param name="options">The <see cref="DbContextOptions"/>.</param>
        /// <param name="operationalStoreOptions">The <see cref="IOptions{OperationalStoreOptions}"/>.</param>
        public ApiAuthorizationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
        }
    }
}
