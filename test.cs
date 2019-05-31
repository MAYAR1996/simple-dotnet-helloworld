[Test]
public void AConstructedErrorContainsTheFaultingItemName()
{
    IErrorBuilder builder = new ErrorBuilder();
    string faultingItem = "Faulting Item";
 
    string errorMessage = builder.BuildError(faultingItem);
 
    StringAssert.Contains(faultingItem, errorMessage);
}
