﻿namespace TestCaseRestApi.ModelsDTO
{
    public class PointDTO
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public PointDTO(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
