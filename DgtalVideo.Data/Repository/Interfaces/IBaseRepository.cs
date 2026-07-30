using DgtalVideo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DgtalVideo.Data.Repository.Interfaces
{
    public interface IBaseRepository<DataModel>
        where DataModel : BaseModel
    {
        void Add(DataModel model);
        void Delete(int id);
        DataModel? Get(int id);
        List<DataModel> GetAll();
        void Remove(DataModel model);
        void Update(DataModel model);
    }
}