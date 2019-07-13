
using System;
using FSM.Triggers;

namespace FSM.Events {
    public abstract class EventSource {

    }

    public class TriggerEventArgs<S,T> : EventArgs {
        public ITrigger<S,T> trigger { get; set; }
        public TriggerEventArgs (ITrigger <S,T> trigger){
            this.trigger = trigger;
        }
    }
}