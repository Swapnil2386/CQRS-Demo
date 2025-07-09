using MediatR;

namespace CQRSAndMediatRDemo.Commands.Students
{
    public class DeleteStudentCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}

