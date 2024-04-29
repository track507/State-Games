using ContextNamespace;

namespace StateNamespace;
abstract class State {
    protected Context currentContext;
    public void SetContext(Context context) {
        currentContext = context;
    }
    public abstract void Handle1();
    public abstract void Handle2();   
}