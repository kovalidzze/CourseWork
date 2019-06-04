
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


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.calculate_KBJY);


            List<string> gendersName = new List<string>();
            foreach (var item in genders) gendersName.Add(item.Key);
            List<string> activingNames = new List<string>();
            foreach (var item in activing) activingNames.Add(item.Key);



            Spinner genderSpinner = FindViewById<Spinner>(Resource.Id.genderSpinner);
            Spinner activingSpinner = FindViewById<Spinner>(Resource.Id.activingSpinner);

            var adapterForGenderSpinner = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, gendersName);
            var adapterForActivingSpinner = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, activingNames);



            adapterForGenderSpinner.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            genderSpinner.Adapter = adapterForGenderSpinner;
            adapterForActivingSpinner.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            activingSpinner.Adapter = adapterForActivingSpinner;
        }
    }
}
