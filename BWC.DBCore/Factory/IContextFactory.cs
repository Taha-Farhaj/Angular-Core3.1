using BWC.DBCore.Context.EFContext;

namespace BWC.DBCore.Factory
{
    public interface IContextFactory
    {
        IDatabaseContext DbContext { get; }
    }
}
