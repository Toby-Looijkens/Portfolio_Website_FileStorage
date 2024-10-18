namespace Portfolio_Website_Filestorage.PublicClasses
{
    public class UploadHandler
    {
        public TransferableFile Upload(IFormFile file) 
        {
            //extension
            List<string> validExtensions = new List<string>() 
            { 
                ".jpg", 
                ".jpeg", 
                ".png",
                ".gif",
                ".mp4", 
                ".blend", 
                ".obj", 
                ".stl", 
                ".fbx",
                ".glb",
                ".gltf"
            }; 

            string extension = Path.GetExtension(file.FileName);
            if (!validExtensions.Contains(extension)) {
                throw new Exception($"Extension is not valid ({string.Join(",", validExtensions) })");
            }

            //file size
            long size = file.Length;
            long maxSize = ((1024 * 1024 * 1024) / 2); // 500 MB filesize limit
            if (size > maxSize) {
                throw new Exception($"File is too big({maxSize.ToString() + "MB limit"})");
            }

            //name changing
            Guid ID = Guid.NewGuid();
            string storedFileName = ID.ToString() + extension;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Files");

            using FileStream stream = new FileStream(Path.Combine(path, storedFileName), FileMode.Create);
            file.CopyTo(stream);

            return new TransferableFile(ID, file.FileName, Path.GetExtension(file.FileName));
        }
    }
}
