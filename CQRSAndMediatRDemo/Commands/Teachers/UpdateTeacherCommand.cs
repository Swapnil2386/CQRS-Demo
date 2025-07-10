using MediatR;

namespace CQRSAndMediatRDemo.Commands.Teachers
{
    public class UpdateTeacherCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string TeacherName { get; set; }
        public string TeacherEmail { get; set; }
        public string TeacherAddress { get; set; }
        public int TeacherAge { get; set; }
        public UpdateTeacherCommand(int id, string teacherName, string teacherEmail, string teacherAddress)
        {
            Id = id;
            TeacherName = teacherName;
            TeacherEmail = teacherEmail;
            TeacherAddress = teacherAddress;
        }

    }
}
