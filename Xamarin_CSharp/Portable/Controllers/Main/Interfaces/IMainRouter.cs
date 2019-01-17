namespace Portable.Controllers.Main.Interfaces
{
    public interface IMainRouter
    {
        void GoToSelector();
        void GoToDetail(string id);
    }
}