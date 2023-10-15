using System.ComponentModel.DataAnnotations.Schema;

namespace TestCaseRestApi.Objects
{
    public abstract class AbstractObject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
