using System;
using System.Collections.Generic;
using FSM.States;
using FSM.Transitions;

namespace FSM.Triggers {
    public interface ITrigger<S,T>{ 
        Transition<S,T> Transition(Dictionary<string, Transition<S,T>> TransitionSet);
    }
}