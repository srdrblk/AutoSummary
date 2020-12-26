using System;
using System.Collections.Generic;
using System.Text;

namespace Contract.Dtos.News
{
    public class GetNewsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public string Summary { get; set; }

        public string SummaryByWordRate { get; set; }
    }
}
