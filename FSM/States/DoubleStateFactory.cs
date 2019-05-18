namespace FSM.States {
    public class DStateFactory : StateFactory<double,double> {
        public new State<double, double> State{ get {
            var temp = _state;
            _state = new State<double, double>();
            return temp;
        } }
    }
}