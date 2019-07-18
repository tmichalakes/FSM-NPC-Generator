using System;
using System.Collections.Generic;
using FSM.Triggers;

namespace FSM.States {
    public abstract class StateMachine<S,T>{
        State<S,T> CurrentState { get; set; }
        List<State<S,T>> States { get; set; }

        public StateMachine<S,T>(EventSource events) {

        }

        protected virtual void OnTriggerReceived(EventArgs e)
        {

        }
    }
}