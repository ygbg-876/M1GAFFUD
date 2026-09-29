using ItemDataLibrary.Database;
using ItemDataLibrary.Models;

namespace ItemDataLibrary.Data
{
    public class SqlData : ISqlData
    {
        private readonly ISqlDataAccess _db;
        private const string connectionStringName = "SqlDb";

        public SqlData(ISqlDataAccess db)
        {
            _db = db;
        }

        // ===== ITEM METHODS =====

        public List<ItemModel> ListItems()
        {
            return _db.LoadData<ItemModel, dynamic>(
                "dbo.spItems_List",
                new { },
                connectionStringName,
                true).ToList();
        }

        public ItemModel ShowItemDetails(int id)
        {
            return _db.LoadData<ItemModel, dynamic>(
                "dbo.spItems_Detail",
                new { id },
                connectionStringName,
                true).FirstOrDefault();
        }

        public void AddItem(ItemForm item)
        {
            _db.SaveData(
                "dbo.spItems_Insert",
                new { item.Name, item.Code, item.Brand, item.UnitPrice },
                connectionStringName,
                true);
        }

        public void UpdateItem(int id, ItemForm item)
        {
            _db.SaveData(
                "dbo.spItems_Update",
                new { id, item.Name, item.Code, item.Brand, item.UnitPrice },
                connectionStringName,
                true);
        }

        public void DeleteItem(int id)
        {
            _db.SaveData(
                "dbo.spItems_Delete",
                new { id },
                connectionStringName,
                true);
        }

        // ===== USER METHODS (Optional) =====

        public UserModel Authenticate(string username, string password)
        {
            return _db.LoadData<UserModel, dynamic>(
                "dbo.spUsers_Authenticate",
                new { username, password },
                connectionStringName,
                true).FirstOrDefault();
        }

        public void Register(string username, string password)
        {
            _db.SaveData(
                "dbo.spUsers_Register",
                new { username, password },
                connectionStringName,
                true);
        }
    }
}