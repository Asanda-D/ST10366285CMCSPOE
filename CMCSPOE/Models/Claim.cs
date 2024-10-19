namespace CMCSPOE.Models
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public string LecturerName { get; set; }
        public int HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
        public string AdditionalNotes { get; set; }
        public DateTime SubmittedDate { get; set; }
        public string SupportingDocumentPath { get; set; }
        public string Status { get; set; } // Pending, Approved, Rejected
    }

}
