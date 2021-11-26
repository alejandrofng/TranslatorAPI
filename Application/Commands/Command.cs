using System.Collections.Generic;
using Domain.Entities;

namespace Application
{
    public abstract class Command<T>
    {
        public abstract T Execute();
    }
}
