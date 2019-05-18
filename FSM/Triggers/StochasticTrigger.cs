using System;
using System.Collections.Generic;
using FSM.States;
using FSM.Transitions;

namespace FSM.Triggers {
    public class StochasticTrigger : ITrigger<double>
    {
        public Transition<double> NextState(Dictionary<string, Transition<double>> Transitions)
        {
            double aggr = 0;
            foreach(var t in Transitions){
                aggr += t.Value.Value;
            }
            double randTarget = new Random().NextDouble() * aggr;
            aggr = 0;
            foreach(var t in Transitions){
                if (t.Value.Value > randTarget)
                    return t.Value;
                aggr += t.Value.Value;
            }
            throw new Exception("Bad Code Path! Random Didn't Work!");
        }
    }
}