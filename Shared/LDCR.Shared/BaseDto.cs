using Mapster;

namespace LDCR.Shared;

public abstract class BaseDto<TTarget> : IRegister
    where TTarget : class
{
    private TypeAdapterConfig config { get; set; } = new TypeAdapterConfig();


    public TTarget ToTarget()
        => this.Adapt<TTarget>();

    public TTarget ToTarget(TTarget entity)
        => (this as TTarget).Adapt(entity);

    public virtual void AddCustomMappings() { }

    public TypeAdapterSetter SetCustomMappings()
        => config.ForType(this.GetType(), typeof(TTarget));

    public void Register(TypeAdapterConfig config)
    {
        SetCustomMappings();
        AddCustomMappings();
    }
}
