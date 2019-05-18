using System;
using System.Collections.Generic;
using FSM.States;
using FSM.Transitions;

namespace FSM.Triggers {
    public class NameTrigger<T> : ITrigger<T>
    {
        // key to look up
        private string name;
        // optional: state to return when the key is not found
        public Transition<T> failsafe { get; set; }
        public NameTrigger(string name, Transition<T> failsafe = null){
            this.name = name;
            this.failsafe = failsafe;
        }
        public Transition<T> NextState(Dictionary<string, Transition<T>> Transitions)
        {
            var t = Transitions[name];
            return t ?? failsafe;
        }
    }
}