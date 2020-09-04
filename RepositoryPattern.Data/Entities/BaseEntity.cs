using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern.Data.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
