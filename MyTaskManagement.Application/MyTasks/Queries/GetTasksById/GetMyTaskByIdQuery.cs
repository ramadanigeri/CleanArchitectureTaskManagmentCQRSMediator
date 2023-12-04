using MediatR;
using MyTaskManagement.Application.MyTasks.Queries.GetTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskManagement.Application.MyTasks.Queries.GetTasksById
{
    public class GetMyTaskByIdQuery : IRequest<MyTaskVM>
    {
        public int MyTaskId { get; set; }
    }
}
