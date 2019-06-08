
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HealtyLifestyle
{
    [Activity(Label = "CalculateKBJUActivity")]
    public class CalculateKBJUActivity : Activity
    {
        private Dictionary<string, string> genders = new Dictionary<string, string>  // Отображаемое имя, значение для прогрера
        {
            {"Мужской", "Мужской" },
            {"Женский", "Женский" }
        };

        //Минимальные нагрузки(сидячая работа) - К=1.2 
        //Немного дневной активности и легкие упражнения 1-3 раза в неделю - К=1.3 (Марафон.Упражнения для дома) 
        //Тренировки 4-5 раз в неделю(или работа средней тяжести) - К= 1.4 (Марафон.Упражнения для зала) 
        //Интенсивные тренировки 4-5 раз в неделю - К=1.5 
        //Ежедневные тренировки - К=1.6 
        //Ежедневные интенсивные тренировки или тренировки 2 раза в день - К=1.7 
        //Тяжелая физическая работа или интенсивные тренировки 2 раза в день - К=1.9
        private Dictionary<string, double> activing = new Dictionary<string, double>
        {
            {"Минимальные нагрузки", 1.2},
            {"Немного дневной активности", 1.3},
            {"Тренировки 4-5 раз в неделю", 1.4},
            {"Интенсивные тренировки", 1.5},
            {"Ежедневные тренровки", 1.6},
            {"Ежедневные интенсивные тренировки", 1.7},
            {"Тяжелая физ работа", 1.9}
        };


        private Dictionary<string, goal> goals = new Dictionary<string, goal>
        {
            {"Поддержание", goal.keeping},
            {"Похуйдение", goal.sliming},
            {"Набор", goal.setting}
        };

        private List<string> results = new List<string>
        {
            "asdasd",
            "bbbbbb"
        };


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.calculate_KBJY);


            Button mes = FindViewById<Button>(Resource.Id.button2);
            EditText weightInput = FindViewById<EditText>(Resource.Id.widthInput);
            EditText growInput = FindViewById<EditText>(Resource.Id.growInput);
            EditText oldInput = FindViewById<EditText>(Resource.Id.oldInput);


            List<string> gendersName = new List<string>();
            foreach (var item in genders) gendersName.Add(item.Key);
            List<string> activingNames = new List<string>();
            foreach (var item in activing) activingNames.Add(item.Key);
            List<string> goalNames = new List<string>();
            foreach (var item in goals) goalNames.Add(item.Key);


            Spinner genderSpinner = FindViewById<Spinner>(Resource.Id.genderSpinner);
            Spinner activingSpinner = FindViewById<Spinner>(Resource.Id.activingSpinner);
            Spinner goalSpinner = FindViewById<Spinner>(Resource.Id.goalSpinner);

            var adapterForGenderSpinner = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, gendersName);
            var adapterForActivingSpinner = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, activingNames);
            var adapterForGoalSpinner = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, goalNames);

            adapterForGenderSpinner.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            genderSpinner.Adapter = adapterForGenderSpinner;
            adapterForActivingSpinner.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            activingSpinner.Adapter = adapterForActivingSpinner;
            adapterForGoalSpinner.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            goalSpinner.Adapter = adapterForGoalSpinner;









            mes.Click += delegate {
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                var w = Convert.ToInt32(weightInput.Text);
                var o = Convert.ToInt32(oldInput.Text);
                var g = Convert.ToInt32(growInput.Text);
                var k = activing[activingSpinner.SelectedItem.ToString()];
                goal goal = goals[goalSpinner.SelectedItem.ToString()];
                var res = Calculator.CalorieCalculation(w, g, o, k, goal);
                alert.SetTitle("<2");
                alert.SetMessage(res.ToString());
                alert.SetNeutralButton("oK", delegate
                {
                    alert.Dispose();
                });
                alert.Show();
            };
        }
    }
}
