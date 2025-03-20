namespace ImagesStoreInDb
{
    public class ImageEntity
    {
        public int Id { get; set; }
        public byte[] ImageData { get; set; } // Store image as binary data
        public string ContentType { get; set; } // Store MIME type
    }
}
