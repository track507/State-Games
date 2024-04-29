using StateNamespace;
class ConcreteStateC : State {
    Dictionary<string, int> Deck; 

    public override void Play() {
        // ConcreteStateA will be implemented by group member
        Console.WriteLine("ConcretesStateC handles request 1");
    }
    public override void NextGame() {
        // ConcreteStateB will be implemented by group member
        Console.WriteLine("ConcreteStateC handles request 2");
    }
}