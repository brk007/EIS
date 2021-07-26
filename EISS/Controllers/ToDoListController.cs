using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EIS.Models;

namespace EIS.Controllers
{
    public class ToDoListController : Controller
    {
        [Route("api/[controller]")]
        public class TodoController : Controller
        {
            public TodoController(ITodoRepository todoItems)
            {
                TodoItems = todoItems;
            }
            public ITodoRepository TodoItems { get; set; }
        
            public IEnumerable<ToDoViewModel> GetAll()
            {
                return TodoItems.GetAll();
            }

            [HttpGet("{id}", Name = "GetTodo")]
            public IActionResult GetById(string id)
            {
                var item = TodoItems.Find(id);
                if (item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }
        }   
    }
}
