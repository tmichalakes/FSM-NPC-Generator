using System;
using FSM.States;
using FSM.Utilities;

namespace FSM.Transitions {
    public class TransitionFactory<S,T> : IFactory{
        protected Transition<S,T> _transition;
        public State<S,T> DefaultState { 
            get => _defaultState; set{
                _defaultState = value;
                _transition.NextState = _defaultState;
            } }
        private State<S,T> _defaultState;
        public Transition<S,T> Transition {
            get {
                var temp = _transition;
                CreateTransition();
                return temp;
            }
        }

        public TransitionFactory () {
            CreateTransition();
        }

        public TransitionFactory<S,T> Value (T value){
            _transition.Value = value;
            return this;
        }

        public TransitionFactory<S,T> Name (string name){
            _transition.Name = name;
            return this;
        }

        public TransitionFactory<S,T> NextState (State<S,T> nextState){
            _transition.NextState = nextState;
            return this;
        }

        protected void CreateTransition(){
            _transition = new Transition<S,T>();
            _transition.NextState = DefaultState;
        }

        public void Reset()
        {
            DefaultState = null;
            CreateTransition();
        }
    }
}   