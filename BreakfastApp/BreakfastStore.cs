using BreakfastApp.Models;
using SQLite;

namespace BreakfastApp
{
    public class BreakfastStore
    {
        private readonly SQLiteConnection database;

        public BreakfastStore()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Breakfast.db");
            database = new SQLiteConnection(dbPath);
            database.CreateTable<BreakfastTable>();
        }

        public List<BreakfastTable> GetAllItems() =>
            database.Table<BreakfastTable>().ToList();

        public int Create(BreakfastTable entity) =>
            database.Insert(entity);

        public int Delete(int id) =>
            database.Delete(database.Table<BreakfastTable>()
                .FirstOrDefault(e => e.Id == id));

        public int Reset() =>
            database.DeleteAll<BreakfastTable>();

        public BreakfastTable GetItem(int id) =>
            database.Table<BreakfastTable>()
                .FirstOrDefault(e => e.Id == id);

        public int Update(BreakfastTable entity) =>
            database.Update(entity);
    }
}
