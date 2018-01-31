using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    public interface ISingableItem
    {
        string Name { get; }
        string MakeSoundOnce();
        string MakeSoundTwice();

    }
}
