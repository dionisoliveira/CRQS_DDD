using Microsoft.EntityFrameworkCore;
using DDDSample._3___InfraStructure.Repository.EF.Mapping;
using DDDSample.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DDDSample._3___InfraStructure.Repository.EF
{
    public class UserDbContext : DbContext
    {
        public DbSet<Domain.User> Alunos { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options)
       : base(options)
        { }


       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          //  new AlunoMap(modelBuilder.Entity<Aluno>());
        }*/
    }
}
