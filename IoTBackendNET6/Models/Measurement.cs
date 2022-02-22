using System;
using System.Collections.Generic;

namespace IoTBackendNET6.Models
{
    public partial class Measurement
    {
        public int MeasurementId { get; set; }
        public int DeviceId { get; set; }
        public DateTime? Time { get; set; }
        public decimal? Temperature { get; set; }
        public decimal? Humidity { get; set; }
        public decimal? Pressure { get; set; }
        public string? Command { get; set; }
        public string? Optional { get; set; }
    }
}
