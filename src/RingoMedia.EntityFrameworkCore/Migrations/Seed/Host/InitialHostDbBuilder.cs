using RingoMedia.EntityFrameworkCore;

namespace RingoMedia.Migrations.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly RingoMediaDbContext _context;

        public InitialHostDbBuilder(RingoMediaDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
