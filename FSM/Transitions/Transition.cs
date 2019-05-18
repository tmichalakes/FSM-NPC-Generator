using System;
using FSM.States;

namespace FSM.Transitions {
    public class Transition <S,T> {
        public Transition(State<S,T> NextState){
            this.NextState = NextState;
        }

        public Transition () {}
        public State<S,T> NextState { get; set; }
        public string Name { get; set; }
        public T Value { get; set; }
    }
}