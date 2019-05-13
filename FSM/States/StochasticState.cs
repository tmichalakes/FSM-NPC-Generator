using System;
using FSM.Transitions;
using FSM.Triggers;

namespace FSM.States {
    public class StochasticState : State<StochasticTransition>
    {
        public StochasticState () {
            this.Trigger = new StochasticTrigger();
        }
        public override State<Transition> NextState()
        {
            return Trigger.GetTransition(Transitions).NextState;
        }
    }
}