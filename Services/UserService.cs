namespace logistics_system_back.Services
{
    using Abstractions;
    using DataTransferObjects;
    using Models;

    public class UserService : IUserService
    { 
        private readonly ApplicationContext _db;

        public UserService(ApplicationContext context)
        {
            _db = context;
        }

        /// <inheritdoc/>
        public User? GetUser(string login, string password)
        {
            return _db.Users.Where(x => x.Login == login && x.Password == password).FirstOrDefault();
        }

    }
}
