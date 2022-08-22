# CodeContracts

Small experimental library to implement "Design by Contract" by Bertrand Meyer, inspired by Zoran Horvat Course "Writing Highly Maintainable Unit Tests"

Example:
```
public double AddNumbersBetween_1_And_100(double first, double second)
{
    // Check if the method is defined for the input
    // by ContractRequirements
    Contract.RequiresAll(new[]{first, second}, Requirements.For(first).GreaterEquals(1).LesserEquals(100));
    // by Lambda
    Contract.RequiresAll(new[]{first, second}, (d) => d >= 1 && d <= 100);
      
    var result = first + second;  
    
    // Check if the method returns the promised output
    // by ContractRequirements
    Contract.Ensures(result, Requirements.For(result).Positive());
    // by Lambda
    Contract.Ensures(() => result >= 0);
}
```
