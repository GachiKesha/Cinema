namespace Films.CCL.Security.Identity
{
    public class Accountant : User
    {
        public Accountant(int UserID, string FirstName, string MiddleName, string LastName, string Email)
            : base(UserID, FirstName, MiddleName, LastName, Email, nameof(Accountant))
        {
        }
    }
}
