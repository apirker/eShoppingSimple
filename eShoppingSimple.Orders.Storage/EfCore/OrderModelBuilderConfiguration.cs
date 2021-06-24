using eShoppingSimple.Orders.Storage.Model;
using eShoppingSimple.ServiceChassis.Storage.EfCore;
using Microsoft.EntityFrameworkCore;

namespace eShoppingSimple.Orders.Storage.EfCore
{
    class OrderModelBuilderConfiguration : IModelBuilderConfiguration
    {
        private const string OrderServiceDatabaseSchema = "order";
        private const string OrdersTableName = "Orders";
        //private string PicturesTableName = "Pictures";
        //private string ItemsTableName = "Items";

        public void OnCreatingModels(ModelBuilder builder)
        {
            builder.HasDefaultSchema(OrderServiceDatabaseSchema);

            builder.Entity<Order>(order =>
            {
                order.ToTable(OrdersTableName);
                order.Property(x => x.Id).ValueGeneratedNever();
                order.Property(x => x.CustomerId);
                order.OwnsMany(c => c.Items, item =>
                {
                    item.Property(x => x.Id).ValueGeneratedNever();
                    item.Property(x => x.Name);
                    item.Property(x => x.Price);
                    item.OwnsMany(c => c.Pictures, picture =>
                    {
                        picture.Property(x => x.Id).ValueGeneratedOnAdd();
                        picture.Property(x => x.Content);
                    });
                });
            });

            //builder.Entity<Item>(item =>
            //{
            //    item.ToTable(ItemsTableName);
            //    item.Property(x => x.Id).ValueGeneratedNever();
            //    item.Property(x => x.Name);
            //    item.Property(x => x.Price);
            //    item.HasMany(c => c.Pictures);
            //});

            //builder.Entity<Picture>(picture =>
            //{
            //    picture.ToTable(PicturesTableName);
            //    picture.Property(x => x.Id).ValueGeneratedOnAdd();
            //    picture.Property(x => x.Content);
            //});
        }
    }
}
