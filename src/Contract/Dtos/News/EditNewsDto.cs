﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Contract.Dtos.News
{
    public class EditNewsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }
    }
}
