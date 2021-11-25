using System;
using System.Collections.Generic;

namespace Application
{
    public abstract class Command<T>
    {
        public abstract T Execute(List<string> content);
    }
}
