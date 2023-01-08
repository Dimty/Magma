namespace Test_Practice_CSharp.DTO
{
    public class QueryDto
    {
        public int Total { get; set; }
        public int Correct { get; set; }
        public int Errors { get; set; }
        public string[] Filenames { get; set; }
    }
}