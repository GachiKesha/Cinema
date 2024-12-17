namespace Films.CCL.Security.Identity
{
    public abstract class User
    {
        public User(int UserID, string FirstName, string MiddleName, string LastName, string Email, string UserType)
        {
            this.UserID = UserID;
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.LastName = LastName;
            this.Email = Email;
            this.UserType = UserType;
        }
        public int UserID{ get; }
        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }
        public string Email { get; }
        protected string UserType { get; }
    }

}
