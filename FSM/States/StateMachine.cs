using System;
using System.Collections.Generic;
using FSM.Triggers;

namespace FSM.States {
    public abstract class StateMachine<S,T>{
        State<S,T> CurrentState {get;set;}
        List<State<S,T>> States {get;set;}

        protected virtual void OnTriggerReceived(EventArgs e)
        {

        }
    }
}