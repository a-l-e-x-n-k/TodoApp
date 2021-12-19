﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Handlers.TodoItems.Commands.UpdateTodoItemDetails
{
    public class UpdateTodoItemDetailsCommand : IRequest<ActionResult>
    {
        public int ListId { get; set; }
        public int ItemId { get; set; }
        public string? Note { get; set; }
    }
}
