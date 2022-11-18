using DryIoc;

public class OptionPricingRegistration
{
    private readonly IContainer container;

    public OptionPricingRegistration()
    {
        container = new Container();
    }

    public void Register<TInterface, TClass>(object serviceKey = null) where TClass : TInterface
    {
        container.Register<TInterface, TClass>(serviceKey: serviceKey);
    }

    public T Resolve<T>(object serviceKey = null)
    {
        return container.Resolve<T>(serviceKey: serviceKey);
    }
}
