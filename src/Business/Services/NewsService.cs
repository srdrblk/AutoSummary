using Business.IServices;
using Contract;
using Contract.Dtos.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Services
{
    public class NewsService : INewsService
    {
        private List<News> News { get; set; }

        public NewsService()
        {
            News = new List<News>();
        }
        public List<GetNewsForListDto> GetAll()
        {
            return News.Select(n => new GetNewsForListDto()
            {
                Id= n.Id,
                Title = n.Title,
                Content = n.Content
            }).ToList();
        }
        public GetNewsDto Get(int? id)
        {
            var news = News.FirstOrDefault(n => n.Id == id);
            if (news == null)
            {
                return null;
            }
            news.CreateSummary();
            return new GetNewsDto()
            {
                Id = news.Id,
                Title = news.Title,
                Content = news.Content,
                Summary = news.Summary,
                SummaryByWordRate = news.SummaryByWordRate
            };
        }
        public void Create(CreateNewsDto news)
        {
            var lastId = News.Any() ? News.OrderByDescending(n => n.Id).FirstOrDefault().Id : 0;
         
            News.Add(new News(lastId+1,news.Title, news.Content));
        }
        public void Edit(GetNewsDto news)
        {
            var newsForEdit = News.FirstOrDefault(n=>n.Id ==news.Id);

            newsForEdit.ChangeTitle(news.Title);
            newsForEdit.ChangeContent(news.Content);
        }
        public void Delete(int id)
        {
            var news = News.FirstOrDefault(n => n.Id == id);
            if (news != null)
            {
                News.Remove(news);
            }

        }
    }
}
