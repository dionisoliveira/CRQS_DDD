using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DDDSample.Domain;

namespace DDDSample._3___InfraStructure.Repository.EF.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public UserMap(EntityTypeBuilder<User> builder)
        {
      /*      builder.Property(c => c.cod_aluno)
              .HasColumnName("cod_aluno").p;

            builder.Property(c => c.pessoa_nome)
                .HasColumnName("pessoa_nome")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);*/


        }
        public void Configure(EntityTypeBuilder<User> builder)
        {
            

         

            

        }
    }
}
