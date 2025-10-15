using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    public interface IAttack
    {
        void Attack(IAttack target);
    }
}
