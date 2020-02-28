using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace CommandLibWithUT
{
    public class Vector
    {
        public string Name;
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }



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


        public Vector Translate(Vector vector)
        {
            this.X += vector.X;
            this.Y += vector.Y;
            this.Z += vector.Z;
            return this;
        }

        public Vector GetVector()
        {
            return new Vector() { X = this.X, Y = this.Y, Z = this.Z };
        }

        public void Print()
        {
            Console.WriteLine($"{Name} = [{X}; {Y}; {Z}]");
        }

        public void SetName(string name)
        {
            this.Name = name;
        }
    }
}
