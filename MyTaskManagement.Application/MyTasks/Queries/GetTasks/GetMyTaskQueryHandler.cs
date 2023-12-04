using MediatR;
using MyTaskManagement.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskManagement.Application.MyTasks.Queries.GetTasks
{
    public class GetMyTaskQueryHandler : IRequestHandler<GetMyTaskQuery, List<MyTaskVM>>
    {
        private readonly IMyTaskRepository _myTaskRepository;

        public GetMyTaskQueryHandler(IMyTaskRepository myTaskRepository)
        {
            _myTaskRepository = myTaskRepository;
        }
        public async Task<List<MyTaskVM>> Handle(GetMyTaskQuery request, CancellationToken cancellationToken)
        {
            var myTask = await _myTaskRepository.GetAllTasks();
            
            //Temporary till using IMapper
            var myTaskList = myTask.Select(x => new MyTaskVM { Id = x.Id, Name = x.Name, 
                Description = x.Description, Category =  x.Category, CreatedBy = x.CreatedBy, CreatedDate = x.CreatedDate }).ToList();
            
            return myTaskList;
        }
    }
}
