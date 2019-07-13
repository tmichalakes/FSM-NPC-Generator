using System;
using Xunit;

namespace FSM.Tests.Idiot {

    public delegate void SayNameDelegate();
    public class IdiotTests {
        [Fact]
        public void DelegatesAndYou () {
            SayNameDelegate d;
            
            Idiot pete = new Idiot("Pete");
            Idiot bob = new Idiot("Bob");

            d = pete.SayName;
            d += bob.SayName;
            d();
        }
    }

    public class Idiot {
        public string Name { get; set; }
        public void SayName() { Console.WriteLine( $"My name is {Name}" ); }

        public Idiot(string Name){
            this.Name = Name;
        }
    }
}