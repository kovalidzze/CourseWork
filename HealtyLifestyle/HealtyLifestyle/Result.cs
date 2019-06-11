using System;
namespace HealtyLifestyle
{
    public class Result
    {
        private int squirrels;
        public int Squirrels
        {
            get
            {
                return squirrels;
            }
        }
        private int fats;
        public int Fats
        {
            get
            {
                return fats;
            }
        }
        private int carbohydeates;
        public int Carbohydeates
        {
            get
            {
                return carbohydeates;
            }
        }
        private int calories;
        public int Calories
        {
            get
            {
                return calories;
            }
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
        }

        public Result(int squirrels, int fats, int carbohydeates, int calories, string name)
        {
            this.squirrels = squirrels;
            this.fats = fats;
            this.carbohydeates = carbohydeates;
            this.calories = calories;
            this.name = name;
        }
    }
}
