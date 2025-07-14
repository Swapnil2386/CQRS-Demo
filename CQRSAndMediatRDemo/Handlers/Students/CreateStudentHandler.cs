using CQRSAndMediatRDemo.Commands.Students;
using CQRSAndMediatRDemo.Models;
using CQRSAndMediatRDemo.Repositories.Students;
using MediatR;
using System.Numerics;

namespace CQRSAndMediatRDemo.Handlers.Students
{
    public class CreateStudentHandler: IRequestHandler<CreateStudentCommand, StudentDetails>
    {
        private readonly IStudentRepository _studentRepository;

        public CreateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<StudentDetails> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
        {
            //throw new Exception("This is test exception");
            var studentDetails = new StudentDetails()
            {
                StudentName = command.StudentName,
                StudentEmail = command.StudentEmail,
                StudentAddress = command.StudentAddress,
                StudentAge = command.StudentAge
            };

            return await _studentRepository.AddStudentAsync(studentDetails);
        }
    }
}
