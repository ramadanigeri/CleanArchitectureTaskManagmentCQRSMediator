using AutoMapper;
using MediatR;
using MyTaskManagement.Application.MyTasks.Queries.GetTasks;
using MyTaskManagement.Domain.Entity;
using MyTaskManagement.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskManagement.Application.MyTasks.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, MyTaskVM>
    {
        private readonly IMyTaskRepository _myTaskRepository;
        private readonly IMapper _mapper;

        public CreateTaskCommandHandler(IMyTaskRepository myTaskRepository, IMapper mapper) 
        {
            _myTaskRepository = myTaskRepository;
            _mapper = mapper;
        }

        public async Task<MyTaskVM> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var taskEntity = new MyTask() {  Name = request.Name, Description = request.Description, Category = request.Category, CreatedBy = request.CreatedBy, CreatedDate = request.CreatedDate };
            var Result = await _myTaskRepository.CreateTask(taskEntity);
            return _mapper.Map<MyTaskVM>(Result);

        }
    }
}
