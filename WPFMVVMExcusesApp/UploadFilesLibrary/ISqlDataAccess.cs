namespace UploadFilesLibrary
{
    public interface ISqlDataAccess
    {
        Task SaveData(global::System.String storedProc, global::System.String connectionName, global::System.Object parameter);
    }
}