using System;
using System.Collections.Generic;
using FSM.Transitions;
using FSM.Triggers;
using FSM.Utilities;

namespace FSM.States
{
    public class StateFactory<S,T> : IFactory {
        public State<S,T> State { get {
            var temp = _state;
            _state = new State<S,T>();
            return temp;
        } }
        protected State<S,T> _state;

        public StateFactory () {
            _state = new State<S,T>();
        }

        public StateFactory<S,T> Name (String name){
            _state.Name = name;
            return this;
        }

        public StateFactory<S,T> Transition (string transitionName, Transition<S,T> transition) {
            _state.AddTransition(transitionName, transition);
            return this;
        }

        public StateFactory<S,T> Transition (Transition<S,T> transition) {
            _state.AddTransition(transition);
            return this;
        }

        public StateFactory<S,T> Value (S Value){
            _state.Value = Value;
            return this;
        }

        public void Reset()
        {
            _state = new State<S,T>();
        }
    }
}