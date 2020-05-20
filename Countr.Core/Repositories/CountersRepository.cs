using System;
using System.IO;
using Countr.Core.Models;
using PCLStorage;                                                  
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Core.Platform;

namespace Countr.Core.Repositories
{
    public class CountersRepository : ICountersRepository
    {
        readonly SQLiteAsyncConnection connection;                   

        public CountersRepository()
        {
            Console.WriteLine("Tatiana: inside CountersRepository() constructor");
            //var local = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var local = FileSystem.Current.LocalStorage.Path;
            var datafile = Path.Combine(local, "counters.db3");
            connection = new SQLiteAsyncConnection(datafile);
            connection.GetConnection().CreateTable<Counter>();

            Console.WriteLine("Tatiana: Db file -  " + datafile);
        }

        public Task Save(Counter counter)
        {
            return connection.InsertOrReplaceAsync(counter); 
        }

        public Task<List<Counter>> GetAll()
        {
            return connection.Table<Counter>().ToListAsync(); 
        }

        public Task Delete(Counter counter)
        {
            return connection.DeleteAsync(counter); 
        }

    }
}
