namespace Films.CCL.Security.Identity
{    
    public class Director : User
    {
        public Director(int UserID, string FirstName, string MiddleName, string LastName, string Email)
            : base(UserID, FirstName, MiddleName, LastName, Email, nameof(Director))
        {
        }
    }
}
