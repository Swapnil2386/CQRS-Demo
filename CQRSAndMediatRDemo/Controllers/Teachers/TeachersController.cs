using CQRSAndMediatRDemo.Commands.Teachers;
using CQRSAndMediatRDemo.Models;
using CQRSAndMediatRDemo.Queries.Teachers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAndMediatRDemo.Controllers.Teachers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TeachersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<List<TeacherDetails>> GetTeacherListAsync()
        {
            var teacherDetails = await _mediator.Send(new GetTeacherListQuery());
            return teacherDetails;
        }
        [HttpGet("teacherId")]
        public async Task<TeacherDetails> GetTeacherByIdAsync(int teacherId)
        {
            var teacherDetails = await _mediator.Send(new GetTeacherByIdQuery() { Id = teacherId });
            return teacherDetails;
        }
        [HttpPost]
        public async Task<TeacherDetails> AddTeacherAsync(TeacherDetails teacherDetails)
        {
            var teacherDetail = await _mediator.Send(new CreateTeacherCommand(
                teacherDetails.TeacherName,
                teacherDetails.TeacherEmail,
                teacherDetails.TeacherAddress));
            return teacherDetail;
        }
        [HttpPut]
        public async Task<int> UpdateTeacherAsync(TeacherDetails teacherDetails)
        {
            var isTeacherDetailUpdated = await _mediator.Send(new UpdateTeacherCommand(
               teacherDetails.Id,
               teacherDetails.TeacherName,
               teacherDetails.TeacherEmail,
               teacherDetails.TeacherAddress));
            return isTeacherDetailUpdated;
        }
        [HttpDelete]
        public async Task<int> DeleteTeacherAsync(int Id)
        {
            var isDeleted = await _mediator.Send(new DeleteTeacherCommand() { Id = Id });
            return isDeleted;
        }
    }
}
