using System;
using System.Collections.Generic;
using FSM.States;
using FSM.Transitions;

namespace FSM.Triggers {
    public interface ITrigger<T>{ 
        Transition<T> NextState(Dictionary<string, Transition<T>> Transitions);
    }
}