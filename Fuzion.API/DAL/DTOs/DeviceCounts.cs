namespace Fuzion.API.DAL.DTOs
{
    public class DeviceCounts
    {
        public int TotalAvailableDevices { get; set; }
        public int TotalDeployedDevices { get; set; }

        public int TotalAvailableWorkstations { get; set; }
        public int TotalDeployedWorkstations { get; set; }

        public int TotalAvailableLaptops { get; set; }
        public int TotalDeployedLaptops { get; set; }

        public int TotalAvailableMobileDevices { get; set; }
        public int TotalDeployedMobileDevices { get; set; }
    }
}