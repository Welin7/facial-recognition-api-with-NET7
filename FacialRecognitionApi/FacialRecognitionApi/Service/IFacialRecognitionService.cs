namespace FacialRecognitionApi.Service
{
    public interface IFacialRecognitionService
    {
        Task<string> RecognizeFace(IFormFile file);
    }
}
