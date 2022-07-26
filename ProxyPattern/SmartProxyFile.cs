namespace _02_ProxyPattern
{
    public class SmartProxyFile : IFile
    {
        private FileStream _fileStream;
        private Dictionary<string, FileStream> fileStreams = new Dictionary<string, FileStream>();
        public FileStream OpenWrite(string path)
        //todo: implement dictionary
        {
            if (!fileStreams.ContainsKey(path))
            {
                fileStreams.Add(path, File.OpenWrite(path));
            }

            return fileStreams[path];


            //if (_fileStream == null)
            //{
            //    _fileStream = File.OpenWrite(path);
            //}
            //return _fileStream;
        }
    }
}
