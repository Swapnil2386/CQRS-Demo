using CQRSAndMediatRDemo.Commands.Teachers;
using CQRSAndMediatRDemo.Repositories.Teachers;
using MediatR;

namespace CQRSAndMediatRDemo.Handlers.Teachers
{
    public class UpdateTeacherHandler : IRequestHandler<UpdateTeacherCommand, int>
    {
        private readonly ITeacherRepository _teacherRepository;
        public UpdateTeacherHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<int> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
           var teacherDetails = await  _teacherRepository.GetTeacherByIdAsync(request.Id);
            if (teacherDetails == null)
                return default;

            teacherDetails.TeacherName = request.TeacherName;
            teacherDetails.TeacherEmail = request.TeacherEmail;
            teacherDetails.TeacherAddress = request.TeacherAddress;
          
            return await _teacherRepository.UpdateTeacherAsync(teacherDetails);
        }
    }
}
