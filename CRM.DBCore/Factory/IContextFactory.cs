using CRM.DBCore.Context.EFContext;

namespace CRM.DBCore.Factory
{
    public interface IContextFactory
    {
        IDatabaseContext DbContext { get; }
    }
}
