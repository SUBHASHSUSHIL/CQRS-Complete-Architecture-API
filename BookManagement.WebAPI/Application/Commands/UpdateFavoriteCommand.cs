﻿using BookManagement.WebAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands
{
    public class UpdateFavoriteCommand : IRequest<Favorite>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public UpdateFavoriteCommand(Guid id, Guid userId, Guid bookId, bool isDeleted)
        {
            Id = id;
            UserId = userId;
            BookId = bookId;
            IsDeleted = isDeleted;
        }
    }
}
