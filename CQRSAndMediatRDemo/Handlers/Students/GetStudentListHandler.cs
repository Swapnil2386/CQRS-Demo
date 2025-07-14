using CQRSAndMediatRDemo.Models;
using CQRSAndMediatRDemo.Queries.Students;
using CQRSAndMediatRDemo.Repositories.Students;
using MediatR;
using System.Numerics;

namespace CQRSAndMediatRDemo.Handlers.Students
{
    public class GetStudentListHandler :  IRequestHandler<GetStudentListQuery, List<StudentDetails>>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentListHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentDetails>> Handle(GetStudentListQuery query, CancellationToken cancellationToken)
        {
            //throw new Exception("An error occurred while fetching the student list.");
            return await _studentRepository.GetStudentListAsync();
        }
    }
}
