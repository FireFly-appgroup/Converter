using Converter.UserInterface.Models;

namespace Converter.DataAccessLayer.Interfaces
{
    interface IFile
    {
        void Save<T>(T trade);
        FilesModel Load();
    }
}
