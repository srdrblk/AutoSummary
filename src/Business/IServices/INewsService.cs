using Contract.Dtos.News;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.IServices
{
    public interface INewsService
    {
        List<GetNewsForListDto> GetAll();

        GetNewsDto Get(int? id);

        void Create(CreateNewsDto news);

        void Edit(GetNewsDto news);

        void Delete(int id);
    }
}
