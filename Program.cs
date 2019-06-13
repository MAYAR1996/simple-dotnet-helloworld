using System;


namespace HelloWorldSample
{
    public static class Program
    {
      //  public static void Main()
       // {
       //     Console.WriteLine("Hello World!");
       // }
        public string GetEmployeeName(int empId)
        {
            string name;
            if (empId == 1)
            {
                name="mayar";
            }
            else if (empId == 2)
            {
                name="Aya";
            }
            else 
            {
                name="Not found"
            }
            return name;
        }
    }
}
