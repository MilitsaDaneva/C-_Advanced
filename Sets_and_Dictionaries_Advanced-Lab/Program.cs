using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentsNum = int.Parse(Console.ReadLine());
            var studentsRecordsDict = new Dictionary<string, List<double>>();

            for (int i = 0; i < studentsNum; i++)
            {
                var inputArray = Console
                    .ReadLine()
                    .Split();
                var studentName = inputArray[0];
                var grade = double.Parse(inputArray[1]);

                if (!studentsRecordsDict.ContainsKey(studentName))
                {
                    studentsRecordsDict.Add(studentName, new List<double>());
                }
                studentsRecordsDict[studentName].Add(grade);
            }
            foreach (var student in studentsRecordsDict)
            {
                var averageGrade = studentsRecordsDict[student.Key].Average();
                Console.Write($"{student.Key} -> ");
                foreach (var grade in studentsRecordsDict[student.Key])
                {
                    Console.Write($"{grade:F2} ");
                }
                Console.Write($"(avg: {averageGrade:F2})");
                Console.WriteLine();
            }
        }
    }
}
