using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Curso.Core.Domain.Pedido.Entidades;

namespace Projeto.Curso.Core.Infra.Data.Mappings
{
    public class ClientesMapping : IEntityTypeConfiguration<Clientes>
    {
        public void Configure(EntityTypeBuilder<Clientes> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Apelido)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.HasIndex(c => c.Apelido).IsUnique();

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.OwnsOne(c => c.CPFCNPJ, cpfcnpj =>
            {
                cpfcnpj.Property(c => c.Numero)
                    .IsRequired()
                    .HasColumnName("CpfCnpj")
                    .HasColumnType("varchar(14)");

                cpfcnpj.HasIndex(c => c.Numero).IsUnique();

            });

            builder.OwnsOne(c => c.Email, email =>
            {
                email.Property(e => e.Endereco)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasColumnType("varchar(100)");

            });

            builder.OwnsOne(c => c.Endereco, ender =>
            {
                ender.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasColumnName("Endereco")
                    .HasColumnType("varchar(100)");

                ender.Property(e => e.Bairro)
                   .HasColumnName("Bairro")
                   .HasColumnType("varchar(30)");

                ender.Property(e => e.Cidade)
                   .HasColumnName("Cidade")
                   .IsRequired()
                   .HasColumnType("varchar(30)");
            });

            builder.OwnsOne(f => f.Endereco).OwnsOne(u => u.UF, uf =>
            {
                uf.Property(e => e.UF)
                    .HasColumnName("UF")
                    .HasColumnType("varchar(2)");
            });

            builder.OwnsOne(c => c.Endereco).OwnsOne(c => c.CEP, cep =>
            {
                cep.Property(e => e.Codigo)
                    .HasColumnName("CEP")
                    .HasColumnType("varchar(8)");

                cep.Ignore(c => c.Endereco);
                cep.Ignore(c => c.Bairro);
                cep.Ignore(c => c.Cidade);
                cep.Ignore(c => c.UF);
            });


            builder.Ignore(c => c.ListaErros);

            builder.ToTable("Clientes");

        }
    }
}
