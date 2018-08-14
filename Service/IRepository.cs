namespace BishopTakeshi.Service
{
    public interface IRepository<in TIdentity, TResource>
    {
        bool Save(TIdentity identity, TResource resource);
        TResource Load(TIdentity identity);
    }
}