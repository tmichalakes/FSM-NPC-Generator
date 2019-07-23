using System;
using System.Collections.Generic;
using FSM.Events;
using FSM.Triggers;

namespace FSM.States {
    public abstract class StateMachine<S,T> : EventConsumer<NameTrigger<S,T>>{
        public StateMachine(EventsSource<NameTrigger<S,T>> source) : base(source) {}

        private State<S,T> _CurrentState;
        State<S,T> CurrentState { get => _CurrentState; set => _CurrentState = value; }
        List<State<S,T>> States { get; set; }

        public override void OnEvent(object sender, NameTrigger<S,T> args){
            State<S,T>.StateTransition(ref _CurrentState, args);
        }
    }
}