namespace Virus.Commands.Tests
{
    public class WithBoolResultAndInputCommand : WithResultAndInCommand
    {

        private readonly int trueValue;

        public WithBoolResultAndInputCommand(int expectedValue)
        {
            trueValue = expectedValue;
        }

        public bool Execute(int value)
        {
            return value == trueValue;
        }
    }
}
