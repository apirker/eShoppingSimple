using eShoppingSimple.ServiceChassis.Storage.EfCore;
using eShoppingSimple.Shippings.Storage.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShoppingSimple.Shippings.Storage.EfCore
{
    class PacketModelBuilderConfiguration : IModelBuilderConfiguration
    {
        private const string PacketsServiceDatabaseSchema = "packet";
        private const string PacketsTableName = "Packets";

        public void OnCreatingModels(ModelBuilder builder)
        {
            builder.HasDefaultSchema(PacketsServiceDatabaseSchema);

            builder.Entity<Packet>(packet =>
            {
                packet.ToTable(PacketsTableName);
                packet.Property(x => x.Id).ValueGeneratedNever();
                packet.Property(x => x.DeliveryService);
                packet.Property(x => x.Destination);

                packet.OwnsMany(c => c.Items, item =>
                {
                    item.Property(i => i.Id).ValueGeneratedNever();
                    item.Property(i => i.Weight);
                    item.OwnsOne(i => i.Order, order =>
                    {
                        order.Property(o => o.Id).ValueGeneratedNever();
                    });
                });
            });
        }
    }
}
