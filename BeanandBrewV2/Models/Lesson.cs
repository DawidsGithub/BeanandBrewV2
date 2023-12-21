using System.ComponentModel.DataAnnotations;

namespace BeanandBrewV2.Models
{
    public class Lesson
    {
        [Key]
        public int Id { get; set; }
        public int LessonId { get; set; }
        public DateTime LessonDate { get; set; } //This should include time


    }
}
