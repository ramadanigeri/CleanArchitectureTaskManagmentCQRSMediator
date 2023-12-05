using Microsoft.EntityFrameworkCore;
using MyTaskManagement.Domain.Entity;
using MyTaskManagement.Domain.Repository;
using MyTaskManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskManagement.Infrastructure.Repository
{
    public class MyTaskRepository : IMyTaskRepository
    {
        private readonly MyTaskDbContext _myTaskDbContext;

        public MyTaskRepository(MyTaskDbContext myTaskDbContext)
        {
            _myTaskDbContext = myTaskDbContext;
        }
        public async Task<MyTask> CreateTask(MyTask myTask)
        {
            await _myTaskDbContext.MyTasks.AddAsync(myTask);
            await _myTaskDbContext.SaveChangesAsync();
            return myTask;
        }

        public async Task<int> DeleteTask(int id)
        {
            return await _myTaskDbContext.MyTasks
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<List<MyTask>> GetAllTasks()
        {
            return await _myTaskDbContext.MyTasks.ToListAsync();
        }

        public async Task<MyTask> GetTaskById(int id)
        {
            return await _myTaskDbContext.MyTasks.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> UpdateTask(int id, MyTask myTask)
        {
            return await _myTaskDbContext.MyTasks
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Name, myTask.Name)
                    .SetProperty(m => m.Description, myTask.Description)
                    .SetProperty(m => m.Category, myTask.Category)
                    .SetProperty(m => m.CreatedBy, myTask.CreatedBy)
                );
        }
    }
}
