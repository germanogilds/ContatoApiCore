using med.domain;
using Microsoft.EntityFrameworkCore;


namespace Med.Repository.Data
{

    public class DataContext : DbContext
    {
    public DataContext(DbContextOptions<DataContext> options) 
    :base(options)
    {}
        public DbSet<Contato> Contatos {get;set;}
    


    }
}