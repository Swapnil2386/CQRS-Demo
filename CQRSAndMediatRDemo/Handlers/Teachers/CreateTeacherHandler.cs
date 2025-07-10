using CQRSAndMediatRDemo.Commands.Teachers;
using CQRSAndMediatRDemo.Models;
using CQRSAndMediatRDemo.Repositories.Teachers;
using MediatR;

namespace CQRSAndMediatRDemo.Handlers.Teachers
{
    public class CreateTeacherHandler : IRequestHandler<CreateTeacherCommand, TeacherDetails>
    {
        private ITeacherRepository _teacherRepository;
        public CreateTeacherHandler(ITeacherRepository  teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public async Task<TeacherDetails> Handle(CreateTeacherCommand command, CancellationToken cancellationToken)
        {
            var teacherDetails = new TeacherDetails()
            {
                TeacherName = command.TeacherName,
                TeacherEmail = command.TeacherEmail,
                TeacherAddress = command.TeacherAddress,

            };
            return await _teacherRepository.AddTeacherAsync(teacherDetails);
        }
    }
}
