using StateNamespace;

namespace ContextNamespace;
class Context {
    private State currentState = null;
    public Context(State state) {
        TransitionTo(state);
    }
    public void TransitionTo(State state) {
        Console.WriteLine($"Context: Transition to {state.GetType().Name}.");
        currentState = state;
        currentState.SetContext(this);
    }
    public void Request1() {
        currentState.Handle1();
    }
    public void Request2() {
        currentState.Handle2();
    }
}

