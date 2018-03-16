namespace Starveler.Common.Entities 
{
    public class Address : BasicEntity 
    {
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string FlatNumber { get; set; }
    }
}