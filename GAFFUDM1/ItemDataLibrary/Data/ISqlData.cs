using ItemDataLibrary.Models;

namespace ItemDataLibrary.Data
{
    public interface ISqlData
    {
        void AddItem(ItemForm item);
        UserModel Authenticate(string username, string password);
        void DeleteItem(int id);
        List<ItemModel> ListItems();
        void Register(string username, string password);
        ItemModel ShowItemDetails(int id);
        void UpdateItem(int id, ItemForm item);
    }
}