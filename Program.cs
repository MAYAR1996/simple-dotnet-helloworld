using System;


//namespace HelloWorldSample
//{
   // public static class Program
    //{
      //  public static void Main()
       // {
       //     Console.WriteLine("Hello World!");
       // }
   public class HomeController{
       public static void Main()
       {
          string name;
          name=HomeController.GetEmployeeName(1);
         Console.WriteLine(name);
          
       }
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
                name="Not found";
            }
            return name;
        }
   }
   // }
//}
