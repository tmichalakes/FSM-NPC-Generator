using System;
using FSM.States;

namespace FSM.Transitions {
    public class Transition <T> {
        public Transition(State<T> NextState){
            this.NextState = NextState;
        }

        public Transition () {}
        public State<T> NextState { get; set; }
        public string Name { get; set; }
        public T Value { get; set; }
    }
}