using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace VCProjectGallery.Data.Base
{
    public class BaseDbInitializer<C> : IDbInitializer where C : DbContext
    {
        protected C context = null;

        public BaseDbInitializer(C context)
        {
            this.context = context;
        }

        public virtual void Initialize()
        {
            try
            {
                if (context.Database.GetPendingMigrations().Count() > 0)
                    context.Database.Migrate();
            }
            catch
            {
            }
        }
    }
}
