namespace MetriFit;

    public record UserCalculatedMeasurments
    {
        public double BodyFat { get; set; }
        public double LeanerBodyMass { get; set; }
        public double BasalMetabolicRate { get; set; }
        public double BMRAfterActivityLevel { get; set; }
    }

