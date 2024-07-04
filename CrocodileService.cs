using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CrocodileManager
{
    public delegate void CrocodileHandler(string text);
    class CrocodileService
    {
        private List<Crocodile> crocodilesList = new();
        private CrocodileHandler? taken;

        public void RegisterHandler(CrocodileHandler del)
        {
            taken = del;
        }

        public void CreateCrocodile(string name, int weight, double length, int age, Genders gender)
        {
            try
            {
                crocodilesList.Add(new Crocodile(name, weight, length, age, gender));
            }
            catch (Exception e)
            {
                taken?.Invoke($"{e.Message}\n");
            }
        }

        public void GetAllCrocodiles()
        {
            foreach (var crocodile in crocodilesList)
            {
                taken?.Invoke($"{crocodile.ToString()}\n");
            }
        }

        public void FindLongCrocodiles(double length)
        {
            var longCrocodilesEnum = from crocodile in crocodilesList
                                     where crocodile.Length >= length
                                     select crocodile;

            foreach (var crocodile in longCrocodilesEnum)
            {
                taken?.Invoke($"{crocodile.ToString()}\n");
            }
        }

        public void FindOldestCrocodile()
        {
            int indexOfMax = 0;
            int maxAge = crocodilesList[0].Age;

            for (int i = 1; i < crocodilesList.Count - 1; i++)
            {
                if (crocodilesList[i].Age > maxAge)
                    indexOfMax = i;
            }

            taken?.Invoke($"{crocodilesList[indexOfMax].ToString()}\n");

            // taken?.Invoke($"{crocodilesList.MaxBy(a => a.Age)}\n"); // можно было так, через LINQ
        }

        public void FindBiggestCrocodile()
        {
            int indexOfMax = 0;
            int maxWeight = crocodilesList[0].Weight;

            for (int i = 1; i < crocodilesList.Count - 1; i++)
            {
                if (crocodilesList[i].Weight > maxWeight)
                    indexOfMax = i;
            }

            taken?.Invoke($"{crocodilesList[indexOfMax].ToString()}\n");

            // taken?.Invoke($"{crocodilesList.MaxBy(w => w.Weight)}\n"); // можно было так, через LINQ
        }
    }
}
