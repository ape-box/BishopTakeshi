namespace BishopTakeshi.Service.Repositories
{
    public interface IRepository<in TIdentity, TResource>
    {
        bool Save(TIdentity identity, TResource resource);
        bool TryLoad(TIdentity identity, out TResource resource);
    }
}