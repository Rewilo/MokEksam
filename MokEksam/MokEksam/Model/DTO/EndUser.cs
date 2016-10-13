namespace MokEksam.Model.DTO
{
    class EndUser
    {
        public string user_name { get; set; }

        public string user_password { get; set; }

        public string user_email { get; set; }

        public EndUser(string userName, string userPassword, string userEmail)
        {
            user_name = userName;
            user_password = userPassword;
            user_email = userEmail;
        }
    }
}
