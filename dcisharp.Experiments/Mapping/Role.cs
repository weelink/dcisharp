namespace dcisharp.Experiments.Mapping
{
    public interface Role<TData, TContext>
    {
        ContextMapping<TData, TContext> MapContext(ContextMapping<TData, TContext> mapping);
    }
}