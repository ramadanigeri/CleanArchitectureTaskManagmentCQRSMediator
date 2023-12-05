using Microsoft.AspNetCore.Mvc;
using MyTaskManagement.Application.MyTasks.Commands.CreateTask;
using MyTaskManagement.Application.MyTasks.Commands.DeleteTask;
using MyTaskManagement.Application.MyTasks.Commands.UpdateTask;
using MyTaskManagement.Application.MyTasks.Queries.GetTasks;
using MyTaskManagement.Application.MyTasks.Queries.GetTasksById;

namespace MyTaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyTaskController : APIControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var myTask = await Mediator.Send(new GetMyTaskQuery());
            return Ok(myTask);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var myTask = await Mediator.Send(new GetMyTaskByIdQuery() { MyTaskId = id });
            if(myTask == null)
            {
                return NotFound();
            }
            return Ok(myTask);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMyTask(CreateTaskCommand command)
        {
            var createTask = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetTaskById), new {id = createTask.Id}, createTask);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, UpdateMyTaskCommand command)
        {
            if (id == command.Id)
            {
                await Mediator.Send(command);
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var result = await Mediator.Send(new DeleteMyTaskCommand { Id = id});
            if(result ==0)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
