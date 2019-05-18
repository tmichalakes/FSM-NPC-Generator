using System;
using System.Collections.Generic;
using System.Linq;
using FSM.Transitions;
using FSM.Triggers;

namespace FSM.States
{
    public class State<S,T>
    {
        public string Name { get; set; }
        public S Value { get; set; }
        public int numTransitions { get => Transitions != null ? Transitions.Count : 0; }
        private Dictionary<string, Transition<S,T>> Transitions;
        
        public State (){
            Transitions = new Dictionary<string, Transition<S,T>>();
        }
        
        public void AddTransition(string transitionName, Transition<S,T> transition){
            Transitions.Add(transitionName, transition);
        }

        public void AddTransitions(IEnumerable<Transition<S,T>> transitions){
            transitions.ToList().ForEach(t => Transitions.Add(t.Name, t));
        }

        public void AddTransitions(Dictionary<string, Transition<S,T>> transitions){
            transitions.ToList().ForEach(kv => Transitions.Add(kv.Key, kv.Value));
        }

        public void AddTransition(Transition<S,T> transition){
            AddTransition(transition.Name, transition);
        }

        public State<S,T> NextState (ITrigger<S,T> Trigger){
            return Trigger.Transition(Transitions).NextState;
        }

        public static void StateTransition(ref State<S,T> state, ITrigger<S,T> trigger){
            state = state.NextState(trigger);
        }
    }
}
