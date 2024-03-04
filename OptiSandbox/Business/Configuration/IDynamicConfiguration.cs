namespace OptiSandbox.Business.Configuration;

public interface IDynamicConfiguration
{
    public PageReference? OtherPagesRoot { get; set; }
}

public class DynamicConfiguration : IDynamicConfiguration
{
    public PageReference? OtherPagesRoot { get; set; }
}
