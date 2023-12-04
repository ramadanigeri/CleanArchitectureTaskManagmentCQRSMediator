using AutoMapper;
using MediatR;
using MyTaskManagement.Application.MyTasks.Queries.GetTasks;
using MyTaskManagement.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskManagement.Application.MyTasks.Queries.GetTasksById
{
    public class GetMyTaskByIdQueryHandler : IRequestHandler<GetMyTaskByIdQuery, MyTaskVM>
    {
        private readonly IMyTaskRepository _myTaskRepository;
        private readonly IMapper _mapper;

        public GetMyTaskByIdQueryHandler(IMyTaskRepository myTaskRepository, IMapper mapper)
        {
            _myTaskRepository = myTaskRepository;
            _mapper = mapper;
        }
        public async Task<MyTaskVM> Handle(GetMyTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var myTask = await _myTaskRepository.GetTaskById(request.MyTaskId);
                return _mapper.Map<MyTaskVM>(myTask);
        }
    }
}
