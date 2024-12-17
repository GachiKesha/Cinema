namespace Films.CCL.Security.Identity
{
    public class Admin : User
    {
        public Admin(int UserID, string FirstName, string MiddleName, string LastName, string Email)
            : base(UserID, FirstName, MiddleName, LastName, Email, nameof(Admin))
        {
        }
    }
}
