using Catalog.DAL.Entities;


namespace DAL.Entities
{
    public class UserRequest
    {
        public int IdUserRequests { get; set; }
        public int IdUser { get; set; }
        public int? IdVacationRequest { get; set; }
        public int? IdTrainingRequest { get; set; }
        public string Type { get; set; } // ENUM ('Vacation', 'Training')

        // Навігаційні властивості
        public User User { get; set; }
        public VacationRequest VacationRequest { get; set; }
        public TrainingRequest TrainingRequest { get; set; }
    }

}
