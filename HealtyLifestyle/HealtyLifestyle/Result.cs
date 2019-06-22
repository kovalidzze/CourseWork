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
            set
            {
                squirrels = value;
            }
        }
        private int fats;
        public int Fats
        {
            get
            {
                return fats;
            }
            set
            {
                fats = value;
            }
        }
        private int carbohydeates;
        public int Carbohydeates
        {
            get
            {
                return carbohydeates;
            }
            set
            {
                carbohydeates = value;
            }
        }
        private int calories;
        public int Calories
        {
            get
            {
                return calories;
            }
            set
            {
                calories = value;
            }
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
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
