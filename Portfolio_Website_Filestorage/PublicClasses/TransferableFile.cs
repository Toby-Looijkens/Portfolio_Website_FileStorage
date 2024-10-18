namespace Portfolio_Website_Filestorage.PublicClasses
{
    public class TransferableFile
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string? URL { get; set; }
        public TransferableFile(Guid ID, string name, string extension) 
        { 
            this.ID = ID;
            this.Name = name;
            this.Extension = extension;
        }
    }
}
