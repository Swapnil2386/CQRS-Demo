using CQRSAndMediatRDemo.Models;
using MediatR;

namespace CQRSAndMediatRDemo.Commands.Teachers
{
    public class CreateTeacherCommand : IRequest<TeacherDetails>
    {
        public string TeacherName { get; set; }
        public string TeacherEmail { get; set; }
        public string TeacherAddress { get; set; }
        public int TeacherAge { get; set; }
        public CreateTeacherCommand(string teacherName, string teacherEmail, string teacherAddress)
        {
            TeacherName = teacherName;
            TeacherEmail = teacherEmail;
            TeacherAddress = teacherAddress;
        }
    }
}
