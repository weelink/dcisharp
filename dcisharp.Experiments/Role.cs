namespace dcisharp.Experiments
{
    public interface Role<TData, TContext>
    {
        void MapContext(ContextMapping<TData, TContext> mapping);
    }
}