namespace MedicalAppointment.Domain.Commons;

public abstract class Auditable
{
    public long Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
}