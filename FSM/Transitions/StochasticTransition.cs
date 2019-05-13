using System;
using System.Collections.Generic;
using FSM.States;

namespace FSM.Transitions {
    public class StochasticTransition : Transition{
        public double RandRange { get; set; }
        public static double operator+ (StochasticTransition A, StochasticTransition B) {
            return A.RandRange + B.RandRange;
        }
        public static double operator+ (double A, StochasticTransition B){
            return A + B.RandRange;
        }
    }
}