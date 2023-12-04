using MediatR;
using MyTaskManagement.Domain.Entity;
using MyTaskManagement.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskManagement.Application.MyTasks.Commands.UpdateTask
{
    public class UpdateMyTaskCommandHandler : IRequestHandler<UpdateMyTaskCommand, int>
    {
        private readonly IMyTaskRepository _myTaskRepository;

        public UpdateMyTaskCommandHandler(IMyTaskRepository myTaskRepository) 
        {
            _myTaskRepository = myTaskRepository;
        }
        public async Task<int> Handle(UpdateMyTaskCommand request, CancellationToken cancellationToken)
        {
            var updateMyTaskEntity = new MyTask()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Category = request.Category,
                CreatedBy = request.CreatedBy,
            };
            return await _myTaskRepository.UpdateTask(request.Id, updateMyTaskEntity);
        }
    }
}
