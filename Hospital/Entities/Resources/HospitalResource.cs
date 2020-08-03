namespace Hospital.Entities.Resources
{
    public class HospitalResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int FreeUnits { get; set; }
        public string AddedBy { get; set; }
    }
}
