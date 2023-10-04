using System;
using Valorant;

class Program
{
    static void Main(string[] args)
    {
        PickAgent Agent1 = new PickAgent();
        Agent1.SetAgentName();
        Agent1.EntryLine();
        Agent1.GetAgentName();
        Agent1.WarmUp();
        Agent1.WarmUp("i miss her");
        Agent1.BattleStart();
    }
}