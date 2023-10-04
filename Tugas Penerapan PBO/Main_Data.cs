using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Data
{
    abstract class Agent
    {
        public string EnemyAgent;
        public sbyte yourdamage, enemydamage;
        protected string AgentName;
        protected sbyte hpfriend = 125, hpenemy = 125;
        public abstract void EntryLine();
    }

    interface Action
    {
        void Shoot1(sbyte yourdamage);
        void Shoot2(sbyte enemydamage);
    }
}