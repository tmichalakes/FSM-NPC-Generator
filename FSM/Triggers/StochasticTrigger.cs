using System;
using System.Collections.Generic;
using FSM.Transitions;

namespace FSM.Triggers {
    public class StochasticTrigger : ITrigger<StochasticTransition> {

        public Transition GetTransition(IEnumerable<StochasticTransition> set)
        {
            double target = (new Random()).NextDouble() * GetRandRange(set);
            double d = 0;
            foreach(var s in set){
                d += s;
                if (d > target) return s;
            }
            throw new Exception("Code aint should get here");
        }

                /**
            SetRandRange

            Returns the total random range of a set of stochastic transitions.
        */
        public static double GetRandRange(IEnumerable<StochasticTransition> set){
            double sum = 0;
            foreach(var s in set){
                sum += s;
            }
            return sum;
        }
    }
}