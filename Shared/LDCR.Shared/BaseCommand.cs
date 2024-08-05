using Mapster;

namespace LDCR.Shared;

public abstract class BaseCommand<TCommand, TEntity> : IRegister
    where TCommand : class
    where TEntity : class
{
    private TypeAdapterConfig config { get; set; } = new TypeAdapterConfig();


    public TEntity ToEntity()
        => this.Adapt<TEntity>();

    public TEntity ToEntity(TEntity entity)
        => (this as TCommand).Adapt(entity);

    public TCommand FromEntity(TEntity entity)
        => entity.Adapt<TCommand>();


    protected TypeAdapterSetter<TCommand, TEntity> SetCustomMappings()
        => config.ForType<TCommand, TEntity>();

    protected TypeAdapterSetter<TEntity, TCommand> SetCustomMappingsInverse()
        => config.ForType<TEntity, TCommand>();


    public virtual void AddCustomMappings() { }


    public void Register(TypeAdapterConfig config)
    {
        this.config = config;
        AddCustomMappings();
    }
}
