using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DataContext;
using WebApi.Infrastructure;
using WebApi.Models;

namespace WebApi.Repository
{
    public class BatchRepository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public BatchRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Batch CreateNewBatch(Batch batch)
        {
            _context.Batches.Add(batch);
            _context.SaveChanges();
            return batch;
        }

        private Batch SearchBatch(int id)
        {
           var batch= _context.Batches.FirstOrDefault(x => x.Id == id);

            return batch;
        }

        public Batch DeleteBatch(int id)
        {
            var batch = SearchBatch(id);
            if (batch != null)
                _context.Batches.Remove(batch);
            _context.SaveChanges();
            return batch; 
        }

        public Batch EditBatchDetails(int id, Batch batch)
        {
            var temp = SearchBatch(id);
            if (temp != null)
            {
               foreach(var obj in _context.Batches)

                {
                    if(obj.Id== batch.Id)
                    {
                        obj.Name = batch.Name;
                        obj.Count = batch.Count;
                    }
                }

                _context.SaveChanges();
            }
            return batch;
        }

        public List<Batch> GetAllBatches()
        {
            return _context.Batches.ToList();
        }

        public Batch GetBatchDetailsById(int id)
        {
            return SearchBatch(id);
        }
    }
}
