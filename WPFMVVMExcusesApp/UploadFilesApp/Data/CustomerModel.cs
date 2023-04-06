namespace UploadFilesApp.Data
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string UserName { get; set; } = "Ander";
        public string? FirstName { get; set; }//nullable
        public string? LastName { get; set; }//nullable
        public string? FileName { get; set; }//nullable
    }
}
