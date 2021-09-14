using CineTeatroItalianoLobos.DataComun;

namespace CineTeatroItalianoLobos.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CineTeatroDbContext _context;
        public UnitOfWork(CineTeatroDbContext context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
