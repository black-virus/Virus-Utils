using System;

namespace Virus.Commands
{
    public static class CommandsFactory
    {

        private static CommandsResolver commandsResolver;

        public static void SetResolver(CommandsResolver resolver)
        {
            commandsResolver = resolver;
        }

        public static T GetCommand<T>()
        {
            return commandsResolver.GetCommand<T>();
        }
    }
}
