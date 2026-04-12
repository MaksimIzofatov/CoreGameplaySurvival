using System.Collections.Generic;
using Data;

namespace Interfaces
{
    public interface ILevel
    {
        public int CurrentLevel { get; }
        public IList<Resource>  Resources { get; }
        public bool IsUpLevel();
    }
}