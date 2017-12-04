using System;
using NUnit.Framework;

namespace Snake_Game.Tests
{
    abstract class TestBase<T>
    {
        protected T _sut;

        public virtual void Init()
        {
        }
        public virtual void Dispose()
        {
        }
    }
}