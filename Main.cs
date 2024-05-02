using ContextNamespace;

class Program {
    static void Main(string[] args) {
        // ConcreteStateA has not been implemented yet
        var context = new Context(new ConcreteStateA());
        context.Request1(); 
        context.Request2(); 
        context = new Context(new ConcreteStateB());
        context.Request1(); 
        context.Request2(); 
        context = new Context(new ConcreteStateC());
        context.Request1(); 
        context.Request2(); 
    }
}