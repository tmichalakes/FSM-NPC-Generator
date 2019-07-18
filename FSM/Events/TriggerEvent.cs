namespace FSM.Events {
    public abstract class TriggerEvent<S,T> {
        public Trigger<S,T> Trigger { get; set; }
    }
}