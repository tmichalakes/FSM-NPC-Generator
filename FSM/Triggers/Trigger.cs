using System;
using System.Collections.Generic;
using FSM.Transitions;

namespace FSM.Triggers {
    public interface ITrigger<T> where T: Transition {
        Transition GetTransition(IEnumerable<T> transitions);
    }
}