using System;

namespace Virus.Commands.Tests
{
    public class WithBoolResultCommand : WithResultCommand
    {
        public bool Execute()
        {
            return true;
        }
    }
}
