using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.Revisao.Api.Domains
{
    public partial class SP_Medical_Group_TESTE1Context : DbContext
    {
        public SP_Medical_Group_TESTE1Context()
        {
        }

        public SP_Medical_Group_TESTE1Context(DbContextOptions<SP_Medical_Group_TESTE1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<TSmgClinica> TSmgClinica { get; set; }
        public virtual DbSet<TSmgConsultas> TSmgConsultas { get; set; }
        public virtual DbSet<TSmgEspecialidades> TSmgEspecialidades { get; set; }
        public virtual DbSet<TSmgMedicos> TSmgMedicos { get; set; }
        public virtual DbSet<TSmgPacientes> TSmgPacientes { get; set; }
        public virtual DbSet<TSmgStatus> TSmgStatus { get; set; }
        public virtual DbSet<TSmgTipoUsuario> TSmgTipoUsuario { get; set; }
        public virtual DbSet<TSmgUsuarios> TSmgUsuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog= SP_Medical_Group_TESTE1;user id=sa; password=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TSmgClinica>(entity =>
            {
                entity.HasKey(e => e.IdClinica);

                entity.ToTable("T_SMG_CLINICA");

                entity.Property(e => e.IdClinica).HasColumnName("id_clinica");

                entity.Property(e => e.DsEndereco)
                    .HasColumnName("ds_endereco")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DsHorarioAtendimento)
                    .HasColumnName("ds_horario_atendimento")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DsRazaoSocial)
                    .HasColumnName("ds_razao_social")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NmClinica)
                    .IsRequired()
                    .HasColumnName("nm_clinica")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NumCnpj)
                    .IsRequired()
                    .HasColumnName("num_cnpj")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TSmgConsultas>(entity =>
            {
                entity.HasKey(e => e.IdConsulta);

                entity.ToTable("T_SMG_CONSULTAS");

                entity.Property(e => e.IdConsulta).HasColumnName("id_consulta");

                entity.Property(e => e.DatDataConsulta)
                    .HasColumnName("dat_data_consulta")
                    .HasColumnType("datetime");

                entity.Property(e => e.DsDescricao)
                    .IsRequired()
                    .HasColumnName("ds_descricao")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdMedico).HasColumnName("id_medico");

                entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");

                entity.Property(e => e.IdStatus).HasColumnName("id_status");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.TSmgConsultas)
                    .HasForeignKey(d => d.IdMedico)
                    .HasConstraintName("FK__T_SMG_CON__id_me__5CD6CB2B");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.TSmgConsultas)
                    .HasForeignKey(d => d.IdPaciente)
                    .HasConstraintName("FK__T_SMG_CON__id_pa__5BE2A6F2");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.TSmgConsultas)
                    .HasForeignKey(d => d.IdStatus)
                    .HasConstraintName("FK__T_SMG_CON__id_st__5DCAEF64");
            });

            modelBuilder.Entity<TSmgEspecialidades>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidade);

                entity.ToTable("T_SMG_ESPECIALIDADES");

                entity.Property(e => e.IdEspecialidade).HasColumnName("id_especialidade");

                entity.Property(e => e.NmEspecialidade)
                    .IsRequired()
                    .HasColumnName("nm_especialidade")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TSmgMedicos>(entity =>
            {
                entity.HasKey(e => e.IdMedico);

                entity.ToTable("T_SMG_MEDICOS");

                entity.Property(e => e.IdMedico).HasColumnName("id_medico");

                entity.Property(e => e.IdEspecialidade).HasColumnName("id_especialidade");

                entity.Property(e => e.IdUsuarios).HasColumnName("id_usuarios");

                entity.Property(e => e.NumCrm)
                    .IsRequired()
                    .HasColumnName("num_crm")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEspecialidadeNavigation)
                    .WithMany(p => p.TSmgMedicos)
                    .HasForeignKey(d => d.IdEspecialidade)
                    .HasConstraintName("FK__T_SMG_MED__id_es__59063A47");

                entity.HasOne(d => d.IdUsuariosNavigation)
                    .WithMany(p => p.TSmgMedicos)
                    .HasForeignKey(d => d.IdUsuarios)
                    .HasConstraintName("FK__T_SMG_MED__id_us__5812160E");
            });

            modelBuilder.Entity<TSmgPacientes>(entity =>
            {
                entity.HasKey(e => e.IdPaciente);

                entity.ToTable("T_SMG_PACIENTES");

                entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");

                entity.Property(e => e.DsDataNascimento)
                    .HasColumnName("ds_data_nascimento")
                    .HasColumnType("datetime");

                entity.Property(e => e.DsEndereco)
                    .IsRequired()
                    .HasColumnName("ds_endereco")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.NumCpf)
                    .IsRequired()
                    .HasColumnName("num_cpf")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NumRg)
                    .IsRequired()
                    .HasColumnName("num_rg")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TSmgPacientes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__T_SMG_PAC__id_us__5535A963");
            });

            modelBuilder.Entity<TSmgStatus>(entity =>
            {
                entity.HasKey(e => e.IdStatus);

                entity.ToTable("T_SMG_STATUS");

                entity.Property(e => e.IdStatus).HasColumnName("id_status");

                entity.Property(e => e.DsStatus)
                    .HasColumnName("ds_status")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TSmgTipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario);

                entity.ToTable("T_SMG_TIPO_USUARIO");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("id_tipo_usuario");

                entity.Property(e => e.NmUsuario)
                    .IsRequired()
                    .HasColumnName("nm_usuario")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TSmgUsuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuarios);

                entity.ToTable("T_SMG_USUARIOS");

                entity.Property(e => e.IdUsuarios).HasColumnName("id_usuarios");

                entity.Property(e => e.DsEmail)
                    .IsRequired()
                    .HasColumnName("ds_email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DsSenha)
                    .IsRequired()
                    .HasColumnName("ds_senha")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdClinica).HasColumnName("id_clinica");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("id_tipo_usuario");

                entity.Property(e => e.NmUsuario)
                    .IsRequired()
                    .HasColumnName("nm_usuario")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NumTelefone)
                    .IsRequired()
                    .HasColumnName("num_telefone")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.TSmgUsuarios)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK__T_SMG_USU__id_cl__5165187F");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.TSmgUsuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__T_SMG_USU__id_ti__52593CB8");
            });
        }
    }
}
