using CQRSAndMediatRDemo.Models;
using CQRSAndMediatRDemo.Queries.Teachers;
using CQRSAndMediatRDemo.Repositories.Teachers;
using MediatR;

namespace CQRSAndMediatRDemo.Handlers.Teachers
{
    public class GetTeacherByIdHandler: IRequestHandler<GetTeacherByIdQuery, TeacherDetails>
    {
        private readonly ITeacherRepository _teacherRepository;
        public GetTeacherByIdHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public async Task<TeacherDetails> Handle(GetTeacherByIdQuery query, CancellationToken cancellationToken)
        {
           return await _teacherRepository.GetTeacherByIdAsync(query.Id);
        }

    }
}
