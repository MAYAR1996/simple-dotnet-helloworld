using Nunit.FrameWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorldSample;

namespace Tests
{
   public class Tests
   {
     [SetUp]
     public void Setup()
     {}
     [Test]
     public void Test1()
     {
       Program home = new Program();
       string result =home.GetEmployeeName(1);
       Assert.AreEqual("mayar",result);
     }
   }
}
