using System.ComponentModel.DataAnnotations.Schema;

namespace Rocket.Elevators.RestApi.Model
{
    [Table("interventions")]
    public class Intervention
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("author")]
        public long Author { get; set; }

        [Column("customerId")]
        public long CustomerId { get; set; }

        [Column("buildingId")]
        public long BuildingId { get; set; }

        [Column("batteryId")]
        public long batteryId { get; set; }

        [Column("columnId")]
        public long? ColumnId { get; set; }

        [Column("elevatorId")]
        public long? ElevatorId { get; set; }

        [Column("employeeId")]
        public long? EmployeeId { get; set; }

        [Column("interventionStartAt")]
        public DateTime? InterventionStartAt { get; set; }

        [Column("interventionEndAt")]
        public DateTime? InterventionEndAt { get; set; }

        [Column("result")]
        public string? Result { get; set; }

        [Column("report")]
        public string? Report { get; set; }

        [Column("status")]
        public string Status { get; set; }


    }
}
