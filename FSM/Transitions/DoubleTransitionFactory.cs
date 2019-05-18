namespace FSM.Transitions {
    public class DTransitionFactory : TransitionFactory<double,double> {
        public new Transition<double, double> Transition {
            get {
                var temp = _transition;
                CreateTransition();
                return temp;
            }
        }
    }
}