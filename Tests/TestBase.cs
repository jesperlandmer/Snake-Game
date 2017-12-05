using System;
using Xunit;

namespace Snake_Game.Tests
{
    public abstract class TestBase<T> : IDisposable
    {
        protected T _sut;
        public virtual void Dispose()
        {
        }
    }
}