using System;
using Xunit;
using FSM.States;
using FSM.Transitions;
using FSM.Triggers;

namespace FSM.Tests
{
    public class NameStateTestFixture : IDisposable {
        
        public DStateFactory dsf;
        public DTransitionFactory dtf; // lol
        public NameStateTestFixture() {
            dsf = new DStateFactory();
            dtf = new DTransitionFactory();
        }

        public State<double,double> GetADState(){
            string testStateName = "testState";
            var state = dsf.Name(testStateName).State;
            return state;
        }

        public void transition(ref State<double, double> current_state, ITrigger<double,double> trigger){
            State<double,double>.StateTransition(ref current_state, trigger);
        }
        public void Dispose() {

        }

        public void Cleanup() {
            dsf.Reset();
            dtf.Reset();
        }
    }

    public class NameStateTests : IDisposable, IClassFixture<NameStateTestFixture>
    {
        NameStateTestFixture fixture;
        public NameStateTests(NameStateTestFixture fixture)
        {
            this.fixture = fixture;
        }

        public void Dispose(){
            fixture.Cleanup();
        }

        ///////// TESTS ////////////////////////

        /**
        Test to make sure that state factory properly generates a state
        and resets when its finished and returns new states when the
        'State' property is called.
         */
        [Fact]
        public void StateFactoryWorks(){
            var sf = fixture.dsf;
            string testStateName = "testState";
            string testTransitionName = "testTransition";
            double testTransitionValue = 1.0;
            var state = sf.Name(testStateName)
                .Transition(new Transition<double,double> {
                    Name = testTransitionName,
                    Value = testTransitionValue,
                    NextState = null
                }).State;
            
            var state2 = sf.State;

            Assert.Equal(1, state.numTransitions);
            Assert.Equal(testStateName, state.Name);
            Assert.NotEqual(state, state2);
        }

        /**
        Sanity Check:
        Makes sure
        1. The transition factory is correctly creating transitions.
        2. Calling the transition property on the factory resets the
          its transition property.
        3. New transitions' NextState property is set to the default
          after the default is set on the factory.
        */
        [Fact]
        public void TransitionFactoryWorks() {
            var tf = fixture.dtf;
            string tran1Name = "transition-1";
            string tran2Name = "transition-1";
            string tran3Name = "transition-2";
            double tran1value = 1.0;
            double tran2value = 1.0;
            double tran3value = 2.0;

            var tran1 = tf.Name(tran1Name)
                .Value(tran1value)
                .Transition;

            var tran2 = tf.Name(tran2Name)
                .Value(tran2value)
                .Transition;

            Assert.Equal(tran1Name, tran1.Name);
            Assert.Equal(tran1value, tran1.Value);
            Assert.NotEqual(tran1, tran2);
            Assert.Null(tran1.NextState);

            var defaultState = fixture.GetADState();
            tf.DefaultState = defaultState;
            
            var tran3 = tf.Name(tran3Name)
                .Value(tran3value)
                .Transition;
            Assert.NotNull(tran3.NextState);
            Assert.Equal(defaultState, tran3.NextState);
        }

        /**
            Check that chaining works properly
            Create 3 states: A,B,C
            Create 2 transtions ab, bc
            Create two name triggers, tab, tbc
            Check that triggering ab then bc
            results in state being C

        */
        [Fact]
        public void StateChaining (){
            var C = fixture.dsf.Name("C").Value(3.0).State;
            var bc = fixture.dtf.Name("bc").Value(2.0).NextState(C).Transition;
            var B = fixture.dsf.Name("B").Value(2.0).Transition(bc).State;
            var ab = fixture.dtf.Name("ab").Value(1.0).NextState(B).Transition;
            var A = fixture.dsf.Name("A").Value(1.0).Transition(ab).State;
            var ca = fixture.dtf.Name("ca").Value(3.0).NextState(A).Transition;
            C.AddTransition(ca);
            
            var tab = new NameTrigger<double, double>("ab");
            var tbc = new NameTrigger<double, double>("bc");
            var tca = new NameTrigger<double, double>("ca");

            Assert.NotEqual(A,B);
            Assert.NotEqual(B,C);
            Assert.NotEqual(A,C);

            State<double,double> current_state = A;
            State<double,double>.StateTransition(ref current_state, tab);
            Assert.Equal(current_state, B);
            State<double,double>.StateTransition(ref current_state, tbc);
            Assert.Equal(current_state,C);
            State<double,double>.StateTransition(ref current_state, tca);
            Assert.Equal(current_state, A);
        }

        /**
        Another test of state chaining.
        Create 2 states and 4 transitions: A,B aa,ab,ba,bb
        set the name property of aa, ab to a and b respectively
        set the name property ob ba, bb to a and b respectively
        Create 2 triggers with names a and b

        1 State A + trigger a -> State A
        2 State A + trigger b -> State B
        3 State B + trigger a -> State A
        4 State B + trigger b -> State B
        */
        [Fact]
        public void StateChaining2 () {
            var A = fixture.dsf.Name("A").Value(1.0).State;
            var B = fixture.dsf.Name("B").Value(2.0).State;
            var tf = fixture.dtf;
            tf.DefaultState = A;
            var aa = tf.Name("a").Transition;
            var ba = tf.Name("a").Transition;
            tf.DefaultState = B;
            var ab = tf.Name("b").Transition;
            var bb = tf.Name("b").Transition;
            A.AddTransitions(new Transition<double,double>[] {aa, ab});
            B.AddTransitions(new Transition<double,double>[] {ba, bb});

            var ta = new NameTrigger<double, double>("a");
            var tb = new NameTrigger<double, double>("b");

            State<double,double> current_state = A;
            fixture.transition(ref current_state, ta);
            Assert.Equal(A, current_state);
            fixture.transition(ref current_state, tb);
            Assert.Equal(B, current_state);
            fixture.transition(ref current_state, tb);
            Assert.Equal(B, current_state);
            fixture.transition(ref current_state, ta);
            Assert.Equal(A, current_state);
        }
    }
}
