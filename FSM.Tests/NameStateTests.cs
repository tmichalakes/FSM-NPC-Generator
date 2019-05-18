using System;
using Xunit;

namespace FSM.Tests
{
    public class NameStateTestFixture : IDisposable {
        public NameStateTestFixture() {

        }

        public void Dispose() {

        }

        public void Cleanup() {

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
        public void Smoke()
        {
            Assert.True(true);
        }
    }
}
