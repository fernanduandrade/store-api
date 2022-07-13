﻿using RestApiDDD.Domain.Entities;

namespace RestApiDDD.Domain.Core.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUser(string email, string password);
    }
}