using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrocodileManager
{
    class Crocodile
    {
        private string? name;
        private int weight;
        private double length;
        private int age;
        private Genders gender;

        public string? Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid Name");
                }
                
                name = value;
            }
        }
        public int Weight
        {
            get { return weight; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid Name");
                }

                weight = value;
            }
        }
        public double Length
        {
            get { return length; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid Name");
                }

                length = value;
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid Name");
                }

                age = value;
            }
        }
        public Genders Gender { get => gender; private set => gender = value; }

        public Crocodile(string name, int weight, double length, int age, Genders gender = 0)
        {
            Name = name;
            Weight = weight;
            Length = length;
            Age = age;
            Gender = gender;
        }

        public override string ToString()
        {
            return new string($"Name: {Name}\nWeight: {Weight}\n" +
                $"Length: {Length}\nAge: {Age}\nGender: {Gender}");
        }
    }

    enum Genders
    {
        None = 0,
        Male,
        Female
    }
}
