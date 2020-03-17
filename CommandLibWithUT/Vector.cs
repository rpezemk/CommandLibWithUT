using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace CommandLibWithUT
{
    public class Vector
    {
        public string Name;
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector()
        {
            Name = string.Empty;
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Vector(Vector vector)
        {
            this.Name = vector.Name;
            this.X = vector.X;
            this.Y = vector.Y;
            this.Z = vector.Z;
        }

        public Vector(double x, double y, double z, string name = "")
        {
            X = x;
            Y = y;
            Z = z;
            Name = name;
        }

        public void Set(Vector vector)
        {
            this.Name = vector.Name;
            this.X = vector.X;
            this.Y = vector.Y;
            this.Z = vector.Z;
        }

        public Vector Add(Vector vector)
        {
            this.X += vector.X;
            this.Y += vector.Y;
            this.Z += vector.Z;
            return this;
        }

        public Vector Substract(Vector vector)
        {
            this.X -= vector.X;
            this.Y -= vector.Y;
            this.Z -= vector.Z;
            return this;
        }

        public Vector Mulitply(Vector vector)
        {
            X = X * vector.X;
            Y = Y * vector.Y; 
            Z = Z * vector.Z;
            return this;
        }

        public Vector Divide(Vector vector)
        {
            X = X / vector.X;
            Y = Y / vector.Y;
            Z = Z / vector.Z;
            return this;
        }

        public Vector GetVector()
        {
            return this; //new Vector() { X = this.X, Y = this.Y, Z = this.Z };
        }



        public void Print()
        {
            Console.WriteLine($"{Name} = [{X}; {Y}; {Z}]");
        }

        public void SetName(string name)
        {
            this.Name = name;
        }

        public void Reset()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

    }
}
