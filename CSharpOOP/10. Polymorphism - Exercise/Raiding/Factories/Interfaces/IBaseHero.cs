using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Factories.Interfaces
{
    internal interface IBaseHero
    {
        BaseHero CreateHero(string name, string type);
    }
}
