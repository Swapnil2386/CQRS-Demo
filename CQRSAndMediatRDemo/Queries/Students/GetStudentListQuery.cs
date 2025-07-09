using CQRSAndMediatRDemo.Models;
using MediatR;

namespace CQRSAndMediatRDemo.Queries.Students
{
    public class GetStudentListQuery :  IRequest<List<StudentDetails>>
    {
    }
}
