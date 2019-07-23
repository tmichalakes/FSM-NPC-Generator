using System;
using System.Collections.Generic;
using FSM.States;
using FSM.Transitions;

namespace FSM.Triggers {
    public class NameTrigger<S,T> : EventArgs, ITrigger<S,T> 
    {
        // key to look up
        private string name;
        // optional: state to return when the key is not found
        public Transition<S,T> failsafe { get; set; }
        public NameTrigger(string name, Transition<S,T> failsafe = null){
            this.name = name;
            this.failsafe = failsafe;
        }
        public Transition<S,T> Transition(Dictionary<string, Transition<S,T>> TransitionSet)
        {
            var t = TransitionSet[name];
            return t ?? failsafe;
        }
    }
}