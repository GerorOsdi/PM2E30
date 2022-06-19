using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using PM2E30.Models;
using System.Threading.Tasks;

namespace PM2E30.Control
{
   public class DataBase
    {
        readonly SQLiteAsyncConnection dBase;

        public DataBase(String dbPath)
        {
            dBase = new SQLiteAsyncConnection(dbPath);

            dBase.CreateTableAsync<Lugares>();
        }

        public Task<int> savePlace(Lugares place)
        {
            if(place.id != null)
            {
                return dBase.InsertAsync(place);
            }
            else
            {
                return dBase.InsertAsync(place);
            }
        }

        public Task<List<Lugares>> getPlaces()
        {
            return dBase.Table<Lugares>().ToListAsync();
        }

        public Task<Lugares> getPlace(int idPlace)
        {
            return dBase.Table<Lugares>()
                .Where(i => i.id == idPlace)
                .FirstOrDefaultAsync();
        }

        public Task<int> DeletePlace(Lugares pla)
        {
            return dBase.DeleteAsync(pla);
        }
    }
}
