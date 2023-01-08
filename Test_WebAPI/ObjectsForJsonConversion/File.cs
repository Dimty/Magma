namespace Test_WebAPI.ObjectsForJsonConversion
{
    public class File
    {
        public string FileName { get; set; }
        public bool Result { get; set; }
        public Error[] Errors { get; set; }
        
        public DateTime ScanTime { get; set; }

    }
}