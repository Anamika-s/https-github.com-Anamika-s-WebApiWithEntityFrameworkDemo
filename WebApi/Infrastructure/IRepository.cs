using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Infrastructure
{
    public interface IRepository
    {
        List<Batch> GetAllBatches();
        Batch GetBatchDetailsById(int id);
        Batch CreateNewBatch(Batch batch);
        Batch EditBatchDetails(int id, Batch batch);
        Batch DeleteBatch(int id);
       
    }
}
