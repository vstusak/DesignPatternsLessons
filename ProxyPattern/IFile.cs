namespace _02_ProxyPattern
{
    public interface IFile
    {
        FileStream OpenWrite(string path);
    }
}
