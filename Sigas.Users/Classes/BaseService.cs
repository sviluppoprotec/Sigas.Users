using DevExpress.Xpo;

namespace Sigas.Users.Classes
{
    public abstract class BaseService
    {
        readonly IDataLayer dataLayer;
        protected readonly UnitOfWork readUnitOfWork;
        public BaseService(IDataLayer dataLayer, UnitOfWork readUnitOfWork)
        {
            this.dataLayer = dataLayer;
            this.readUnitOfWork = readUnitOfWork;
        }
        protected UnitOfWork CreateModificationUnitOfWork()
        {
            return new UnitOfWork(dataLayer);
        }
    }
}
