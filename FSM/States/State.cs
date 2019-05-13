using System;
using System.Collections.Generic;
using FSM.Transitions;
using FSM.Triggers;

namespace FSM.States
{
    public abstract class State<T> where T : Transition
    {
        public string Name { get; set; }
        public IEnumerable<T> Transitions { get; set; }

        public ITrigger<T> Trigger { get; set; }

        public abstract State<Transition> NextState();
    }
}
