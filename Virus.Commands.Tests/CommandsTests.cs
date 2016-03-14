using Moq;
using Xunit;
using FluentAssertions;
using Virus.Commands.Tests.Fixtures;

namespace Virus.Commands.Tests
{
    [Trait("", "Commands tests")]
    public class CommandsTests : IClassFixture<CommandsFactoryFixture>
    {

        private CommandsFactoryFixture factoryFixture;

        public CommandsTests(CommandsFactoryFixture commandsFactoryFixture)
        {
            factoryFixture = commandsFactoryFixture;
        }

        [Fact(DisplayName = "Test commands factory")]
        public void CommandWithoutInAndOutParametersFactoryTest()
        {
            factoryFixture.SetupBindAbstractCommandToHisImplementation<SimpleCommand, CommandWithoutInAndOutParameters>(() => new CommandWithoutInAndOutParameters());

            var simpleCommand = CommandsFactory.GetCommand<SimpleCommand>();

            simpleCommand.Should().NotBeNull().And.BeAssignableTo<SimpleCommand>();
        }

        [Fact(DisplayName = "Execute simple command")]
        public void ExecuteSimpleCommandTest()
        {
            factoryFixture.SetupBindAbstractCommandToHisImplementation<SimpleCommand, CommandWithoutInAndOutParameters>(() => new CommandWithoutInAndOutParameters());

            var simpleCommand = CommandsFactory.GetCommand<SimpleCommand>();
            simpleCommand.Execute();

            CommandWithoutInAndOutParameters.Executed.Should().BeTrue();
        }

        [Fact(DisplayName = "Execute command with result")]
        public void ExecuteCommandWithOutputValueTest()
        {
            factoryFixture.SetupBindAbstractCommandToHisImplementation<WithResultCommand, WithBoolResultCommand>(() => new WithBoolResultCommand());

            var command = CommandsFactory.GetCommand<WithResultCommand>();
            var result = command.Execute();

            result.Should().BeTrue();
        }

        [Fact(DisplayName = "Execute command with result and input parameters")]
        public void ExecuteCommandWithOutputValueAndInputTest()
        {
            factoryFixture.SetupBindAbstractCommandToHisImplementation<WithResultAndInCommand, WithBoolResultAndInputCommand>(() => new WithBoolResultAndInputCommand(3));

            var command = CommandsFactory.GetCommand<WithResultAndInCommand>();
            var falseResult = command.Execute(1);
            var trueResult = command.Execute(3);

            falseResult.Should().BeFalse();
            trueResult.Should().BeTrue();
        }

    }
}
