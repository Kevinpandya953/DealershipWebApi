namespace DealershipWebApi.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AddressId { get; set; }
        public DateTime DateJoined { get; set; }
        public int DesignationId { get; set; }
        public int Salary { get; set; }
        public string Email { get; set; }
    }
}
