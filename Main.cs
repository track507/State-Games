using ContextNamespace;

class Program {
    static void Main(string[] args) {
        // ConcreteStateA has not been implemented yet
        var context = new Context(new ConcreteStateA());
        context.Request1(); // Switch to ConcreteStateB
        context.Request2(); // Switch to ConcreteStateC
    }
}