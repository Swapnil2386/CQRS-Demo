using CQRSAndMediatRDemo.Models;
using CQRSAndMediatRDemo.Queries.Teachers;
using CQRSAndMediatRDemo.Repositories.Teachers;
using MediatR;

namespace CQRSAndMediatRDemo.Handlers.Teachers
{
    public class GetTeacherListHandler : IRequestHandler<GetTeacherListQuery, List<TeacherDetails>>
    {
        private readonly ITeacherRepository _teacherRepository;
        public GetTeacherListHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public async Task<List<TeacherDetails>> Handle(GetTeacherListQuery request, CancellationToken cancellationToken)
        {
            return await _teacherRepository.GetTeacherListAsync();
        }
    }
}
