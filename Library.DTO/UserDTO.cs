namespace Library.DTO
{
    public class UserDTO : IEntity
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte RecordStatusId { get; set; }
    }
}
