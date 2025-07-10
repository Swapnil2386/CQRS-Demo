using CQRSAndMediatRDemo.Models;
using MediatR;

namespace CQRSAndMediatRDemo.Queries.Teachers
{
    public class GetTeacherByIdQuery : IRequest<TeacherDetails>
    {
        public int Id { get; set; }
        
    }   
   
}
