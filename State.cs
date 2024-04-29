using ContextNamespace;

namespace StateNamespace;
abstract class State {
    protected Context currentContext;
    public void SetContext(Context context) {
        currentContext = context;
    }
    public abstract void Handle1();
    public abstract void Handle2();
    public abstract void Handle3();   
}

class ConcreteStateC : State {
    public override void Handle1() {
        // ConcreteStateA will be implemented by group member
        Console.WriteLine("ConcretesStateC handles request 1");
    }
    public override void Handle2() {
        // ConcreteStateB will be implemented by group member
        Console.WriteLine("ConcreteStateC handles request 2");
    }
    public override void Handle3() {
        Console.WriteLine("ConcreteStateC handles request 3");
        Console.WriteLine("ConcreteStateC is changing states...");
        currentContext.TransitionTo(new ConcreteStateA());
    }
}