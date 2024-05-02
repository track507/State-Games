using ContextNamespace;

class Program {
    static void Main(string[] args) {
        // StateA has not been implemented yet
        var context = new Context(new ConcreteStateA());
        context.Request1(); 
        context.Request2(); 
        context = new Context(new HangmanState());
        context.Request1(); 
        context.Request2(); 
        context = new Context(new BlackJack());
        context.Request1(); 
        context.Request2(); 
    }
}