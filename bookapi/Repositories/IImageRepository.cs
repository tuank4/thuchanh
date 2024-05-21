using System.Drawing;

namespace bookapi.Repositories
{
    public class IImageRepository
    {
        Image Upload (Image image);
        List<Image> GetAllInfoImages();
        (byte[], string, string) DownloadFile(int Id);
    }
}
