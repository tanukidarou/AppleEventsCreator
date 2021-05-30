namespace AppleEventsCreator
{
    public class AppleEventsFile
    {
        public string FileExtension { get; }
        public string Data { get; }

        public AppleEventsFile(string data, string fileExtension)
        {
            Data = data;
            FileExtension = fileExtension;
        }
    }
}
