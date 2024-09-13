namespace ServiceRecordApi.Models
{
    public class UpdateRecordDTO
    {
        public string? Owner { get; set; } // Owner name
        public DateTime Date { get; set; } // Date of service
        public string? Make { get; set; } // Audi, Volkswagen, etc
        public string? Model { get; set; } // A4, Atlas, etc
        public int Year { get; set; } // Model year
        public string? VIN { get; set; } // Vehicle Identification Number
        public string? License { get; set; } // License plate number
        public int Mileage { get; set; } // Mileage at time of service
        public string? Service { get; set; } // Description of service performed
        public double Charge { get; set; } // Amount owed for this service
    }
}
