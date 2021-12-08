using System.ComponentModel.DataAnnotations;

namespace MiNIAPi.Entites
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
