namespace ConsoleForum
{
    using ConsoleForum.Contracts;
    using ConsoleForum.Entities.Users;

    public class Administrator : User, IAdministrator
    {
        public Administrator(int id, string name, string password, string email)
            : base(id, name, password, email)
        {
        }
    }
}
