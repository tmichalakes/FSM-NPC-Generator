using System;
using System.Collections.Generic;
using FSM.Transitions;
using FSM.Triggers;

namespace FSM.States
{
    public class State<T>
    {
        public string StateName { get; set; }
        private Dictionary<string, Transition<T>> Transitions;
        
        public State (){
            Transitions = new Dictionary<string, Transition<T>>();
        }
        
        public void AddTransition(string transitionName, Transition<T> transition){
            Transitions.Add(transitionName, transition);
        }

        public State<T> NextState (ITrigger<T> Trigger){
            return Trigger.NextState(Transitions).NextState;
        }
    }
}
