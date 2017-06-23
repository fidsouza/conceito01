using conceito01.Model;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace conceito01.Services
{
    public class Data
    {
        readonly SQLiteAsyncConnection database;

        public Data(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<oficinatable>().Wait();
            database.CreateTableAsync<Opinion>().Wait();

        }

        public Task<int> SaveItemAsync(oficinatable item)
        {
            if (item.id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                
                var s =  database.InsertAsync(item);
                return s;
            }

        }

        public Task<int> SaveItemAsyncOpinion(Opinion opinion)
        {
            if (opinion.id != 0)
            {
                return database.UpdateAsync(opinion);
            }
            else
            {
                var o =  database.InsertAsync(opinion);


           
                return o;
            }
        }

        public Task<List<oficinatable>> GetItemsAsync()
        {
            return database.Table<oficinatable>().ToListAsync();
        }

        public Task<List<Opinion>> GetItemsAsyncOpinionID(int id)
        {
            return database.Table<Opinion>().Where(i => i.oficinaid == id).ToListAsync();
        }

        public Task<List<Opinion>> GetItemsAsyncOpinion()
        {
            return database.Table<Opinion>().ToListAsync();
        }

        public Task<List<oficinatable>> GetLabelAsync(string label)
        {
            return database.Table<oficinatable>().Where(i => i.label == label).ToListAsync();
        }
    }
}
