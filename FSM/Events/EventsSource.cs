using System;

namespace FSM.Events {
    public abstract class EventsSource<E> where E : EventArgs {
        public event EventHandler<E> EventQueue;

        protected virtual void OnEvent(E args) {
            EventHandler<E> handler = EventQueue;
            handler?.Invoke(this, args);
        }
    }
}