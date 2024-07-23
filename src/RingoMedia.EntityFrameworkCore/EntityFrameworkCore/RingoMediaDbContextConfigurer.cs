using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace RingoMedia.EntityFrameworkCore
{
    public static class RingoMediaDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<RingoMediaDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<RingoMediaDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}