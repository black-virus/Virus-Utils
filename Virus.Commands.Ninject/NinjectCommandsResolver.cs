using System;
using Ninject;

namespace Virus.Commands.Ninject
{
    public class NinjectCommandsResolver : CommandsResolver
    {

        private readonly IKernel kernel;

        public NinjectCommandsResolver(IKernel ninjectKernel)
        {
            kernel = ninjectKernel;
        }

        public T GetCommand<T>()
        {
            return kernel.Get<T>();
        }
    }
}
