using MediatR;

namespace CQRSAndMediatRDemo.Commands.Teachers
{
    public class DeleteTeacherCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
