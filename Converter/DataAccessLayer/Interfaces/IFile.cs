namespace Converter.DataAccessLayer.Interfaces
{
    interface IFile
    {
        void ToBinary();
        void Save(TradeRecord trade);
    }
}
