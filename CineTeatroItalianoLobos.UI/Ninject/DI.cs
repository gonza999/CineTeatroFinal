﻿using Ninject;
using System.Reflection;

namespace CineTeatroItalianoLobos.UI.Ninject
{
    public class DI
    {
        private static StandardKernel _kernel;

        public static void Inicialize()
        {
            _kernel = new StandardKernel();
            _kernel.Load(Assembly.GetExecutingAssembly());
        }

        public static T Create<T>()
        {
            return _kernel.Get<T>();
        }

    }

}
