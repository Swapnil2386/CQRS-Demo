namespace CQRSAndMediatRDemo.Models
{
    public class ClassDetails
    {
        public int Id { get; set; }
        public string ClassName { get; set; }

        public ICollection<StudentDetails> Students { get; set; }
        public ICollection<ClassTeacherMapping> ClassTeacherMappings { get; set; }
    }
}
