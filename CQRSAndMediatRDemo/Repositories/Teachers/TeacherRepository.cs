using CQRSAndMediatRDemo.Data;
using CQRSAndMediatRDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSAndMediatRDemo.Repositories.Teachers
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly DbContextClass _dbContext;
        public TeacherRepository(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<TeacherDetails> AddTeacherAsync(TeacherDetails teacherDetails)
        {
           var result = _dbContext.Teachers.Add(teacherDetails);
            _dbContext.SaveChanges();
            return Task.FromResult(result.Entity);
        }

        public Task<int> DeleteTeacherAsync(int Id)
        {
          var filteredData = _dbContext.Teachers.Where(x => x.Id == Id).FirstOrDefault();
            _dbContext.Teachers.Remove(filteredData);
            return Task.FromResult(_dbContext.SaveChanges());
        }

        public async Task<TeacherDetails> GetTeacherByIdAsync(int Id)
        {
            return await _dbContext.Teachers.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public Task<List<TeacherDetails>> GetTeacherListAsync()
        {
            return  _dbContext.Teachers
            .FromSqlRaw("EXEC GetAllTeachers")
            .ToListAsync();
            //return _dbContext.Teachers.ToListAsync();
        }

        public Task<int> UpdateTeacherAsync(TeacherDetails teacherDetails)
        {
           _dbContext.Teachers.Update(teacherDetails);
            return Task.FromResult(_dbContext.SaveChanges());

        }
    }
}
