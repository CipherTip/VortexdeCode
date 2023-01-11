namespace VortexdeCodeAPI.ViewModel
{
    public class InspectionReportViewModel
    {
        public int Id { get; set; }
        public int TimeSlotId { get; set; }
        public int FloorId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public string? Notes { get; set; }
        public DateTime? LogEntryTime { get; set; }
        public bool? IsEdited { get; set; }
        public string? ReasonForEdit { get; set; }
        public bool? IsManualEntry { get; set; }
        public string? ReasonForManualentry { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
