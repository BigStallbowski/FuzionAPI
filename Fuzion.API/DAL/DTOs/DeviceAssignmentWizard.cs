namespace Fuzion.API.DAL.DTOs
{
    public class DeviceAssignmentWizard
    {
        public int Id { get; set; }
        public int PurposeId { get; set; }
        public string AssignedTo { get; set; }
        public string NoteBody { get; set; }
    }
}