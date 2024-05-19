﻿// <auto-generated />
using System;
using EventPlanner.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventPlanner.Migrations
{
    [DbContext(typeof(EventPlannerContext))]
    partial class EventPlannerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EventPlanner.Models.Evento", b =>
                {
                    b.Property<int>("IdEvento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEvento"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUbicacion")
                        .HasColumnType("int");

                    b.Property<string>("NombreEvento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEvento");

                    b.HasIndex("IdUbicacion");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("EventPlanner.Models.Participante", b =>
                {
                    b.Property<int>("IdParticipante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdParticipante"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdParticipante");

                    b.ToTable("Participantes");
                });

            modelBuilder.Entity("EventPlanner.Models.Recurso", b =>
                {
                    b.Property<int>("IdRecurso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRecurso"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdEvento")
                        .HasColumnType("int");

                    b.Property<string>("NombreRecurso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRecurso");

                    b.HasIndex("IdEvento");

                    b.ToTable("Recursos");
                });

            modelBuilder.Entity("EventPlanner.Models.Registro", b =>
                {
                    b.Property<int>("IdRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRegistro"));

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdEvento")
                        .HasColumnType("int");

                    b.Property<int>("IdParticipante")
                        .HasColumnType("int");

                    b.HasKey("IdRegistro");

                    b.HasIndex("IdEvento");

                    b.HasIndex("IdParticipante");

                    b.ToTable("Registros");
                });

            modelBuilder.Entity("EventPlanner.Models.Ubicacion", b =>
                {
                    b.Property<int>("IdUbicacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUbicacion"));

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUbicacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUbicacion");

                    b.ToTable("Ubicaciones");
                });

            modelBuilder.Entity("EventPlanner.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EventPlanner.Models.Evento", b =>
                {
                    b.HasOne("EventPlanner.Models.Ubicacion", "Ubicacion")
                        .WithMany("Eventos")
                        .HasForeignKey("IdUbicacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ubicacion");
                });

            modelBuilder.Entity("EventPlanner.Models.Recurso", b =>
                {
                    b.HasOne("EventPlanner.Models.Evento", "Evento")
                        .WithMany("Recursos")
                        .HasForeignKey("IdEvento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");
                });

            modelBuilder.Entity("EventPlanner.Models.Registro", b =>
                {
                    b.HasOne("EventPlanner.Models.Evento", "Evento")
                        .WithMany("Registros")
                        .HasForeignKey("IdEvento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventPlanner.Models.Participante", "Participante")
                        .WithMany("Registros")
                        .HasForeignKey("IdParticipante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Participante");
                });

            modelBuilder.Entity("EventPlanner.Models.Evento", b =>
                {
                    b.Navigation("Recursos");

                    b.Navigation("Registros");
                });

            modelBuilder.Entity("EventPlanner.Models.Participante", b =>
                {
                    b.Navigation("Registros");
                });

            modelBuilder.Entity("EventPlanner.Models.Ubicacion", b =>
                {
                    b.Navigation("Eventos");
                });
#pragma warning restore 612, 618
        }
    }
}
