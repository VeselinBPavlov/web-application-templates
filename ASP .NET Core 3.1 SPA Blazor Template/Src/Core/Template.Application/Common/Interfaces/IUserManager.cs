﻿namespace Template.Application.Common.Interfaces
{
    using System.Threading.Tasks;

    using Common.Models;

    public interface IUserManager
    {
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
    }
}
