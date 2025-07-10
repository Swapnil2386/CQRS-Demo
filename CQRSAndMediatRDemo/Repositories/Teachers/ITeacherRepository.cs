using CQRSAndMediatRDemo.Models;

namespace CQRSAndMediatRDemo.Repositories.Teachers
{
    public interface ITeacherRepository
    {
        public Task<List<TeacherDetails>> GetTeacherListAsync();
        public Task<TeacherDetails> GetTeacherByIdAsync(int Id);
        public Task<TeacherDetails> AddTeacherAsync(TeacherDetails teacherDetails);
        public Task<int> UpdateTeacherAsync(TeacherDetails teacherDetails);
        public Task<int> DeleteTeacherAsync(int Id);
    }
}
