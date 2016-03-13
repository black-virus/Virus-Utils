namespace Virus.Commands
{
    public interface CommandsResolver
    {

        T GetCommand<T>();

    }
}
