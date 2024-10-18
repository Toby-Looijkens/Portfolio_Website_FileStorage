namespace Portfolio_Website_Filestorage.PublicClasses
{
    public class DownloadHandler 
    {
        public byte[] GetFileAsByteArray(TransferableFile file) =>
            ConvertFileToByteArray(file);
        
        private byte[] ConvertFileToByteArray(TransferableFile file)
        {
            string directory = Directory.GetCurrentDirectory();
            string path = Path.Combine(directory, "Files", $"{file.ID.ToString() + file.Extension}");
            
            return File.ReadAllBytes(path);
        }
    }
}
