namespace MedicalAppointment.Api.Helpers;

public class Response
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public Object Data { get; set; }
}