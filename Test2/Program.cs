using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            var VacationDictionary = new Dictionary<string, List<DateTime>>()
            {
                ["Иванов Иван Иванович"] = new List<DateTime>(),
                ["Петров Петр Петрович"] = new List<DateTime>(),
                ["Юлина Юлия Юлиановна"] = new List<DateTime>(),
                ["Сидоров Сидор Сидорович"] = new List<DateTime>(),
                ["Павлов Павел Павлович"] = new List<DateTime>(),
                ["Георгиев Георг Георгиевич"] = new List<DateTime>()
            };

            //использование встроенного списка enum DayOfWeek
            var AviableDaysOfWeek = new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
            
            // Список отпусков сотрудников
            List<DateTime> Vacations = new List<DateTime>();
            List<DateTime> dateList = new List<DateTime>();
            List<DateTime> SetDateList = new List<DateTime>();
            foreach (var VacationList in VacationDictionary)
            {
                Random random = new Random();
                
                DateTime start = new DateTime(DateTime.Now.Year, 1, 1);
                DateTime end = new DateTime(DateTime.Today.Year, 12, 31);
                
                dateList = VacationList.Value;
                int vacationCount = 28;
                while (vacationCount > 0)
                {
                    int range = (end - start).Days;
                    var startDate = start.AddDays(random.Next(range));
                    if (AviableDaysOfWeek.Contains(startDate.DayOfWeek))
                    {
                        string[] vacationSteps = { "7", "14" };
                        int vacIndex = random.Next(vacationSteps.Length);
                        /*
                        избаление от второй переменной "difference" и 
                        присваение переменной endDate эквивалентного значения из массива "vacationSteps"
                        */
                        var endDate = startDate.AddDays(int.Parse(vacationSteps[vacIndex]));

                        // Проверка условий по отпуску
                        bool CanCreateVacation = false;
                        
                        if (CanCreateVacation = !Vacations.Any(element => element >= startDate && element <= endDate))
                        {
                            if (!Vacations.Any(element => element.AddDays(3) >= startDate && element.AddDays(3) <= endDate))
                            {
                                bool existStart = !dateList.Any(element => element.AddMonths(1) >= startDate && element.AddMonths(1) >= endDate);
                                bool existEnd = !dateList.Any(element => element.AddMonths(-1) <= startDate && element.AddMonths(-1) <= endDate);
                                if (existStart && existEnd)
                                    CanCreateVacation = true;
                            }
                        }

                        if (CanCreateVacation)
                        {
                            var AllVacationCount = 0;
                            for (DateTime dt = startDate; dt < endDate; dt = dt.AddDays(1))
                            {
                                Vacations.Add(dt);
                                dateList.Add(dt);
                            }
                            AllVacationCount++;
                            vacationCount -= int.Parse(vacationSteps[vacIndex]);
                        }
                    }
                }
            }
            foreach (var VacationList in VacationDictionary)
            {
                SetDateList = VacationList.Value;
                Console.WriteLine("Дни отпуска " + VacationList.Key + " : ");
                for (int i = 0; i < SetDateList.Count; i++) { Console.WriteLine(SetDateList[i]); }
            }
            Console.ReadKey();
        }
    }
}



