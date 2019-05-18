using System;
using System.Collections.Generic;
using FSM.Transitions;
using FSM.Triggers;
using FSM.Utilities;

namespace FSM.States
{
    public class StateFactory<T> : IFactory {
        public State<T> State { get {
            var temp = _state;
            _state = new State<T>();
            return temp;
        } }
        private State<T> _state;

        public StateFactory () {
            _state = new State<T>();
        }

        public StateFactory<T> Name (String name){
            _state.StateName = name;
            return this;
        }

        public StateFactory<T> Transition (string transitionName, Transition<T> transition) {
            _state.AddTransition(transitionName, transition);
            return this;
        }

        public StateFactory<T> Transition (Transition<T> transition) {
            _state.AddTransition(transition);
            return this;
        }

        public void Reset()
        {
            _state = new State<T>();
        }
    }
}