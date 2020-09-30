﻿using System.Threading.Tasks;
using Template.WebUI.Shared.Common.Models;

namespace Template.WebUI.Shared.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
    }
}