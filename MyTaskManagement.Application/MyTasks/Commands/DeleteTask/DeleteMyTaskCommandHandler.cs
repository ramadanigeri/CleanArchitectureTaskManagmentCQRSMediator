using MediatR;
using MyTaskManagement.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskManagement.Application.MyTasks.Commands.DeleteTask
{
    public class DeleteMyTaskCommandHandler : IRequestHandler<DeleteMyTaskCommand, int>
    {
        private readonly IMyTaskRepository _myTaskRepository;

        public DeleteMyTaskCommandHandler(IMyTaskRepository myTaskRepository) 
        {
            _myTaskRepository = myTaskRepository;
        }
        public async Task<int> Handle(DeleteMyTaskCommand request, CancellationToken cancellationToken)
        {
            return await _myTaskRepository.DeleteTask(request.Id);
        }
    }
}
