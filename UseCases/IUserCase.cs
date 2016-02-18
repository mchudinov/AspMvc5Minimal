using System;

namespace UseCases
{
    public interface IUserCase
    {
        Guid CreateUser(string nickaname, string email);

        void DeleteUser(Guid id);
    }
}
