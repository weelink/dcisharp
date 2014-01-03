namespace dcisharp.Experiments
{
    public interface Role<TRole>
    {
        void MapContext(ContextMapping<TRole> mapping);
    }
}