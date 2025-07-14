namespace CQRSAndMediatRDemo.Models
{
    public class ClassTeacherMapping
    {
        public int Id { get; set; }

        public int ClassId { get; set; }
        public ClassDetails Class { get; set; }

        public int TeacherId { get; set; }
        public TeacherDetails Teacher { get; set; }
    }
}
