using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskManagement.Application.MyTasks.Commands.DeleteTask
{
    public class DeleteMyTaskCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
