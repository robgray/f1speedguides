namespace atomicf1.services
{
    public interface IContentService {

        string GetContent(string pageName, string args, string host);

        string GetContentByPostback(string pageName, string data, string host);

        string GetNews();
    }
}