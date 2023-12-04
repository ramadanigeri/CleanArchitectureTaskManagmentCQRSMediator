using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskManagement.Application.MyTasks.Queries.GetTasks
{
    public class GetMyTaskQuery : IRequest<List<MyTaskVM>>
    {

    }
}
