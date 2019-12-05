namespace Minimal.Core.Models
{
    public class Movie : EntityBase
    {
        public string Name { get; set; }
        public double Rating { get; set; }
        public int AgeGroup { get; set; }
        public bool IsDeleted { get; set; }
    }
}