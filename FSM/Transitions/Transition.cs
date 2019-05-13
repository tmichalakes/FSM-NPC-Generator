using System;
using FSM.States;

namespace FSM.Transitions {
    public class Transition {
        public Transition(State<Transition> NextState){
            this.NextState = NextState;
        }

        public Transition () {}
        public State<Transition> NextState { get; set; }
    }
}