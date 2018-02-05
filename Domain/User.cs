using Dapper.Contrib.Extensions;

namespace Domain
{
    [Table("tb_User")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
