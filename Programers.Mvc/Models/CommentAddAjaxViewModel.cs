﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Programers.Entities.Dtos;

namespace Programers.Mvc.Models
{
    public class CommentAddAjaxViewModel
    {
        public CommentAddDto CommentAddDto { get; set; }
        public string CommentAddPartial { get; set; }
        public CommentDto CommentDto { get; set; }
    }
}
