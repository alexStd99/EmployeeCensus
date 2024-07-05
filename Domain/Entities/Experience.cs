namespace EmployeeCensus.Domain.Entities
{
    public class Experience : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Guid ProgrammingLanguageId { get; set; }
        public ProgrammingLanguage ProgrammingLanguage { get; set; }
    }
}