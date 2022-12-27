using System.ComponentModel.DataAnnotations.Schema;

namespace Rocket.Elevators.RestApi.Model
{
    [Table("employees")]
    public class Employee
    {
        [Column("id")]
        public long Id { get; set; }
        
        [Column("last_name")]
        public string LastName { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

		[Column("user_id")]
		public long UserId { get; set; }

	}
}
