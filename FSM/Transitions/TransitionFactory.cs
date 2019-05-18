using System;
using FSM.States;
using FSM.Utilities;

namespace FSM.Transitions {
    public class TransitionFactory<T> : IFactory{
        private Transition<T> _transition;
        public State<T> DefaultState { get; set; }
        public Transition<T> Transition {
            get {
                var temp = _transition;
                CreateTransition();
                return temp;
            }
        }

        public TransitionFactory () {
            CreateTransition();
        }

        public TransitionFactory<T> Value (T value){
            _transition.Value = value;
            return this;
        }

        public TransitionFactory<T> Name (string name){
            _transition.Name = name;
            return this;
        }

        public TransitionFactory<T> NextState (State<T> nextState){
            _transition.NextState = nextState;
            return this;
        }

        public void CreateTransition(){
            _transition = new Transition<T>();
            NextState(DefaultState);
        }

        public void Reset()
        {
            DefaultState = null;
            CreateTransition();
        }
    }
}   