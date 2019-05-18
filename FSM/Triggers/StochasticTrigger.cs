using System;
using System.Collections.Generic;
using FSM.States;
using FSM.Transitions;

namespace FSM.Triggers {
    public class StochasticTrigger<S> : ITrigger<S,double>
    {
        public Transition<S,double> Transition(Dictionary<string, Transition<S,double>> TransitionSet)
        {
            double aggr = 0;
            foreach(var t in TransitionSet){
                aggr += t.Value.Value;
            }
            double randTarget = new Random().NextDouble() * aggr;
            aggr = 0;
            foreach(var t in TransitionSet){
                if (t.Value.Value > randTarget)
                    return t.Value;
                aggr += t.Value.Value;
            }
            throw new Exception("Bad Code Path! Random Didn't Work!");
        }
    }
}