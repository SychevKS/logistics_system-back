namespace logistics_system_back.DataTransferObjects
{
    using Models;

    public class WorkerDTO
    {
        public WorkerDTO(Worker worker)
        {
            Id = worker.Id;
            Surname = worker.Surname;
            Name = worker.Name;
            BirthDate = worker.BirthDate;

        }

        public Guid Id { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
