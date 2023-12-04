using MediatR;
using MyTaskManagement.Application.MyTasks.Queries.GetTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskManagement.Application.MyTasks.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<MyTaskVM>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? CreatedBy { get; set; }
    }
}
