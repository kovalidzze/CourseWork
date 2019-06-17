
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


        private List<Result> results = new List<Result>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.calculate_KBJY);


            Button mes = FindViewById<Button>(Resource.Id.button2);
            var resultsBtn = FindViewById<Button>(Resource.Id.button3);
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


            resultsBtn.Click += delegate {
                Intent set = new Intent(this, typeof(ResultsActivity));
                List<string> myResults = new List<string>();
                foreach (var item in results)
                {
                    string name = item.Name;
                    string cal = "Калл-" + item.Squirrels.ToString();
                    string sq = "Белки-" + item.Squirrels.ToString();
                    string f = "Жиры-" + item.Fats.ToString();
                    string c = "Углеводы-" + item.Fats.ToString();
                    string str = name + "\n" + cal + " " + sq + " " + f + " " + c;
                    myResults.Add(str);
                }

                set.PutStringArrayListExtra(ResultsActivity.keyForList, myResults);
                StartActivity(set);
            };

            mes.Click += delegate {
                LayoutInflater layoutInflater = LayoutInflater.From(this);
                View view = layoutInflater.Inflate(Resource.Layout.user_input_dialog_box, null);
                Android.Support.V7.App.AlertDialog.Builder alertbuilder = new Android.Support.V7.App.AlertDialog.Builder(this);
                alertbuilder.SetView(view);
                var userdata = view.FindViewById<EditText>(Resource.Id.editText);
                alertbuilder.SetCancelable(false)
                .SetPositiveButton("Submit", delegate
                {
                    //Toast.MakeText(this, "Submit Input: " + userdata.Text, ToastLength.Short).Show(); // Сообщение для отлатки)0)0))

                    var name = userdata.Text;
                    var w = Convert.ToInt32(weightInput.Text);
                    var o = Convert.ToInt32(oldInput.Text);
                    var g = Convert.ToInt32(growInput.Text);
                    var k = activing[activingSpinner.SelectedItem.ToString()];
                    goal goal = goals[goalSpinner.SelectedItem.ToString()];
                    var res = Calculator.CalorieCalculation(w, g, o, k, goal);
                    int squirrels = (int)((res * 30) / 100) / 4;
                    int fats = (int)((res * 30) / 100) / 9;
                    int carbohydeates = (int)((res * 40) / 100) / 4;
                    int calories = (int)res;
                    Result r = new Result(squirrels, fats, carbohydeates, calories,name);
                    results.Add(r);

                })
                .SetNegativeButton("Cancel", delegate
                {
                    alertbuilder.Dispose();
                });
                Android.Support.V7.App.AlertDialog dialog = alertbuilder.Create();
                dialog.Show();
            };
        }
    }
}
