namespace Reflection_Tasks;

public class BlackBoxInt
{
    private int value;

    // Added private parameterless constructor for reflection
    private BlackBoxInt()
    {
        value = 0;
    }

    public BlackBoxInt(int initialValue = 0)
    {
        value = initialValue;
    }

    private void Add(int number)
    {
        value += number;
    }

    private void Subtract(int number)
    {
        value -= number;
    }

    private void Multiply(int number)
    {
        value *= number;
    }

    private void Divide(int number)
    {
        if (number == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }
        value /= number;
    }

    private void LeftShift(int positions)
    {
        value <<= positions;
    }

    private void RightShift(int positions)
    {
        value >>= positions;
    }
}
