using CQRSAndMediatRDemo.Models;
using MediatR;

namespace CQRSAndMediatRDemo.Queries.Teachers
{
    public class GetTeacherListQuery : IRequest<List<TeacherDetails>>
    {
        
    }
}
