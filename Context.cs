using StateNamespace;

namespace ContextNamespace;
class Context {
    private State currentState = null;
    // On context update, call transition
    public Context(State state) {
        TransitionTo(state);
    }
    // Transition handler
    public void TransitionTo(State state) {
        Console.WriteLine($"Context: Transition to {state.GetType().Name}.");
        currentState = state;
        currentState.SetContext(this);
    }
    // Start Game
    public void Request1() {
        currentState.Play();
    }
    // 
    public void Request2() {
        currentState.NextGame();
    }
}

