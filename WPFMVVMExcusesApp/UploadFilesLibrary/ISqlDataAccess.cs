namespace UploadFilesLibrary
{
    public interface ISqlDataAccess
    {
        Task<List<T>> LoadData<T>(string storedProc, string connectionName, object? parameter);
        Task SaveData(global::System.String storedProc, global::System.String connectionName, global::System.Object parameter);
    }
}