using System;
using Xunit;
using FSM.States;
using FSM.Transitions;
using FSM.Triggers;

namespace FSM.Tests
{
    public class NameStateTestFixture : IDisposable {
        
        StateFactory<double> sfDouble;
        public NameStateTestFixture() {
            sfDouble = new StateFactory<double>();
        }

        public void Dispose() {

        }

        public void Cleanup() {
            sfDouble.Reset();
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

        [Fact]
        public void StateFactoryWorks(){
            StateFactory<double> sf_double = new StateFactory<double>();
            string testStateName = "testState";
            string testTransitionName = "testTransition";
            double testTransitionValue = 1.0;
            var state = sf_double.Name(testStateName)
                .Transition(testTransitionName, new Transition<double> {
                    Name = testTransitionName,
                    Value = testTransitionValue,
                    NextState = null
                }).State;

            Assert.Equal(1, state.numTransitions);
            Assert.Equal(testStateName, state.StateName);
        }
    }
}
