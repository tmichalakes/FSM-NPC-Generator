using System;

namespace FSM.Events {
    public abstract class EventConsumer<E> where E : EventArgs {
        public EventConsumer(EventsSource<E> source) {
            source.EventQueue += OnEvent;
        }

        public abstract void OnEvent(object sender, E args);
    }
}