using AutoMapper;
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
        private readonly IMapper _mapper;

        public GetMyTaskQueryHandler(IMyTaskRepository myTaskRepository, IMapper mapper)
        {
            _myTaskRepository = myTaskRepository;
            _mapper = mapper;
        }
        public async Task<List<MyTaskVM>> Handle(GetMyTaskQuery request, CancellationToken cancellationToken)
        {
            var myTask = await _myTaskRepository.GetAllTasks();
            
            //Temporary till using IMapper
            /*var myTaskList = myTask.Select(x => new MyTaskVM { Id = x.Id, Name = x.Name, 
                Description = x.Description, Category =  x.Category, CreatedBy = x.CreatedBy, CreatedDate = x.CreatedDate }).ToList();*/
            var myTaskList = _mapper.Map<List<MyTaskVM>>(myTask);
            return myTaskList;
        }
    }
}
