

namespace Sigas.Users.Classes
{
    public static class PersistentTypesHelper
    {
        static Type[] sigasPeersistentTypes = new Type[] {
                typeof( DevExpress.ExpressApp.Security.Strategy.SecuritySystemRole),
                typeof( DevExpress.ExpressApp.Security.Strategy.SecuritySystemUser),
                typeof( DevExpress.ExpressApp.Security.Strategy.SecuritySystemTypePermissionObject),
                typeof( DevExpress.Persistent.BaseImpl.BaseObject),
                typeof( DevExpress.Persistent.BaseImpl.FileData),
                // typeof( XCRM.Module.DataDB.Utente)
            };
        public static Type[] GetPersistentTypes()
        {
            Type[] result = new Type[sigasPeersistentTypes.Length];

            sigasPeersistentTypes.CopyTo(result, 0);

            return result;
        }
    }
}
