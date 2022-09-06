using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using AppCompras.Model;

using System.Threading.Tasks;

namespace AppCompras.Helper
{
    public class SQLiteDatabase
    {
        readonly SQLiteAsyncConnection _db;
        public SQLiteDatabase(string path)
        {
            _db = new SQLiteAsyncConnection(path);

            _db.CreateTableAsync<Item>().Wait();
        }

        public Task<List<Item>> GetAllRows()
        {
            return _db.Table<Item>().OrderByDescending(o => o.Id).ToListAsync();
        }

        public Task<Item> GetById(int id)
        {
            return _db.Table<Item>().FirstAsync(o => o.Id == id);
        }

        public Task<int> Insert(Item NovoItem)
        {
            return _db.InsertAsync(NovoItem);
        }

        public Task<List<Item>> Update(Item NovoItem)
        {
            string sql = "UPDATE Item SET PRODUTO=?, QUANTIDADE=?, PRECOUNITARIO=?, DESCRICAO=? TOTAL=?" +
            "WHERE Id=?";

            return _db.QueryAsync<Item>(sql,
                NovoItem.Produto,
                NovoItem.Qtd,
                NovoItem.PrecoUnt,
                NovoItem.Desc,
                NovoItem.Total,
                NovoItem.Id);
        }

        public Task<int> Delete(int id)
        {
            return _db.Table<Item>().DeleteAsync(o => o.Id == id);
        }

        public Task<List<Item>> Search(string search)
        {
            string sql = "SELECT * FROM Item WHERE Descricao LIKE %?%";

            return _db.QueryAsync<Item>(sql);
        }
    }
}