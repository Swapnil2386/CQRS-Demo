using CQRSAndMediatRDemo.Commands.Teachers;
using CQRSAndMediatRDemo.Repositories.Teachers;
using MediatR;

namespace CQRSAndMediatRDemo.Handlers.Teachers
{
    public class DeleteTeacherHandler : IRequestHandler<DeleteTeacherCommand, int>
    {
       private readonly ITeacherRepository _teacherRepository;

        public DeleteTeacherHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public Task<int> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacherDetails = _teacherRepository.GetTeacherByIdAsync(request.Id);
            if (teacherDetails == null)
                return Task.FromResult(default(int));
            
            return _teacherRepository.DeleteTeacherAsync(teacherDetails.Id);
        }
    }
}
