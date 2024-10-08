﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ePrrodaja.Service.Database;

#nullable disable

namespace ePrrodaja.Service.Migrations
{
    [DbContext(typeof(EProdajaContext))]
    partial class EProdajaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ePrrodaja.Service.Database.Dobavljaci", b =>
                {
                    b.Property<int>("DobavljacId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DobavljacId"));

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KontaktOsoba")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Napomena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Web")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZiroRacuni")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DobavljacId");

                    b.ToTable("Dobavljaci");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.IzlazStavke", b =>
                {
                    b.Property<int>("IzlazStavkaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IzlazStavkaId"));

                    b.Property<decimal>("Cijena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("IzlazId")
                        .HasColumnType("int");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<decimal?>("Popust")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProizvodId")
                        .HasColumnType("int");

                    b.HasKey("IzlazStavkaId");

                    b.HasIndex("IzlazId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("IzlazStavke");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.Izlazi", b =>
                {
                    b.Property<int>("IzlazId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IzlazId"));

                    b.Property<string>("BrojRacuna")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("IznosBezPdv")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IznosSaPdv")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int?>("NarudzbaId")
                        .HasColumnType("int");

                    b.Property<int>("SkladisteId")
                        .HasColumnType("int");

                    b.Property<bool>("Zakljucen")
                        .HasColumnType("bit");

                    b.HasKey("IzlazId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("NarudzbaId");

                    b.HasIndex("SkladisteId");

                    b.ToTable("Izlazi");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.JediniceMjere", b =>
                {
                    b.Property<int>("JedinicaMjereId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JedinicaMjereId"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JedinicaMjereId");

                    b.ToTable("JediniceMjere");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.Korisnici", b =>
                {
                    b.Property<int>("KorisnikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KorisnikId"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LozinkaHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LozinkaSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KorisnikId");

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.KorisniciUloge", b =>
                {
                    b.Property<int>("KorisnikUlogaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KorisnikUlogaId"));

                    b.Property<DateTime>("DatumIzmjene")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int>("UlogaId")
                        .HasColumnType("int");

                    b.HasKey("KorisnikUlogaId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("UlogaId");

                    b.ToTable("KorisniciUloge");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.Kupci", b =>
                {
                    b.Property<int>("KupacId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KupacId"));

                    b.Property<DateTime>("DatumRegistracije")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LozinkaHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LozinkaSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("KupacId");

                    b.ToTable("Kupci");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.NarudzbaStavke", b =>
                {
                    b.Property<int>("NarudzbaStavkaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NarudzbaStavkaId"));

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int>("NarudzbaId")
                        .HasColumnType("int");

                    b.Property<int>("ProizvodId")
                        .HasColumnType("int");

                    b.HasKey("NarudzbaStavkaId");

                    b.HasIndex("NarudzbaId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("NarudzbaStavke");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.Narudzbe", b =>
                {
                    b.Property<int>("NarudzbaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NarudzbaId"));

                    b.Property<string>("BrojNarudzbe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("KupacId")
                        .HasColumnType("int");

                    b.Property<bool?>("Otkazano")
                        .HasColumnType("bit");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("NarudzbaId");

                    b.HasIndex("KupacId");

                    b.ToTable("Narudzbe");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.Ocjene", b =>
                {
                    b.Property<int>("OcjenaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OcjenaId"));

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("KupacId")
                        .HasColumnType("int");

                    b.Property<int>("Ocjena")
                        .HasColumnType("int");

                    b.Property<int>("ProizvodId")
                        .HasColumnType("int");

                    b.HasKey("OcjenaId");

                    b.HasIndex("KupacId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("Ocjene");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.Proizvodi", b =>
                {
                    b.Property<int>("ProizvodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProizvodId"));

                    b.Property<decimal>("Cijena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("JedinicaMjereId")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Slika")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("SlikaThumb")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("StateMachine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("VrstaId")
                        .HasColumnType("int");

                    b.HasKey("ProizvodId");

                    b.HasIndex("JedinicaMjereId");

                    b.HasIndex("VrstaId");

                    b.ToTable("Proizvodi");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.Skladistum", b =>
                {
                    b.Property<int>("SkladisteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SkladisteId"));

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SkladisteId");

                    b.ToTable("Skladistum");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.UlazStavke", b =>
                {
                    b.Property<int>("UlazStavkaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UlazStavkaId"));

                    b.Property<decimal>("Cijena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int>("ProizvodId")
                        .HasColumnType("int");

                    b.Property<int>("UlazId")
                        .HasColumnType("int");

                    b.HasKey("UlazStavkaId");

                    b.HasIndex("ProizvodId");

                    b.HasIndex("UlazId");

                    b.ToTable("UlazStavke");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.Ulazi", b =>
                {
                    b.Property<int>("UlazId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UlazId"));

                    b.Property<string>("BrojFakture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("DobavljacId")
                        .HasColumnType("int");

                    b.Property<decimal>("IznosRacuna")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<string>("Napomena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Pdv")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SkladisteId")
                        .HasColumnType("int");

                    b.HasKey("UlazId");

                    b.HasIndex("DobavljacId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("SkladisteId");

                    b.ToTable("Ulazi");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.Uloge", b =>
                {
                    b.Property<int>("UlogaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UlogaId"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UlogaId");

                    b.ToTable("Uloge");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.VrsteProizvodum", b =>
                {
                    b.Property<int>("VrstaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VrstaId"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VrstaId");

                    b.ToTable("VrsteProizvodum");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.IzlazStavke", b =>
                {
                    b.HasOne("ePrrodaja.Service.Database.Izlazi", "Izlaz")
                        .WithMany("IzlazStavkes")
                        .HasForeignKey("IzlazId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ePrrodaja.Service.Database.Proizvodi", "Proizvod")
                        .WithMany("IzlazStavkes")
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Izlaz");

                    b.Navigation("Proizvod");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.Izlazi", b =>
                {
                    b.HasOne("ePrrodaja.Service.Database.Korisnici", "Korisnik")
                        .WithMany("Izlazis")
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ePrrodaja.Service.Database.Narudzbe", "Narudzba")
                        .WithMany("Izlazis")
                        .HasForeignKey("NarudzbaId");

                    b.HasOne("ePrrodaja.Service.Database.Skladistum", "Skladiste")
                        .WithMany("Izlazis")
                        .HasForeignKey("SkladisteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");

                    b.Navigation("Narudzba");

                    b.Navigation("Skladiste");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.KorisniciUloge", b =>
                {
                    b.HasOne("ePrrodaja.Service.Database.Korisnici", "Korisnik")
                        .WithMany("KorisniciUloges")
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ePrrodaja.Service.Database.Uloge", "Uloga")
                        .WithMany("KorisniciUloges")
                        .HasForeignKey("UlogaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");

                    b.Navigation("Uloga");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.NarudzbaStavke", b =>
                {
                    b.HasOne("ePrrodaja.Service.Database.Narudzbe", "Narudzba")
                        .WithMany("NarudzbaStavkes")
                        .HasForeignKey("NarudzbaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ePrrodaja.Service.Database.Proizvodi", "Proizvod")
                        .WithMany("NarudzbaStavkes")
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Narudzba");

                    b.Navigation("Proizvod");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.Narudzbe", b =>
                {
                    b.HasOne("ePrrodaja.Service.Database.Kupci", "Kupac")
                        .WithMany("Narudzbes")
                        .HasForeignKey("KupacId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kupac");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.Ocjene", b =>
                {
                    b.HasOne("ePrrodaja.Service.Database.Kupci", "Kupac")
                        .WithMany("Ocjenes")
                        .HasForeignKey("KupacId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ePrrodaja.Service.Database.Proizvodi", "Proizvod")
                        .WithMany("Ocjenes")
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kupac");

                    b.Navigation("Proizvod");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.Proizvodi", b =>
                {
                    b.HasOne("ePrrodaja.Service.Database.JediniceMjere", "JedinicaMjere")
                        .WithMany("Proizvodis")
                        .HasForeignKey("JedinicaMjereId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ePrrodaja.Service.Database.VrsteProizvodum", "Vrsta")
                        .WithMany("Proizvodis")
                        .HasForeignKey("VrstaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JedinicaMjere");

                    b.Navigation("Vrsta");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.UlazStavke", b =>
                {
                    b.HasOne("ePrrodaja.Service.Database.Proizvodi", "Proizvod")
                        .WithMany("UlazStavkes")
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ePrrodaja.Service.Database.Ulazi", "Ulaz")
                        .WithMany("UlazStavkes")
                        .HasForeignKey("UlazId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proizvod");

                    b.Navigation("Ulaz");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.Ulazi", b =>
                {
                    b.HasOne("ePrrodaja.Service.Database.Dobavljaci", "Dobavljac")
                        .WithMany("Ulazis")
                        .HasForeignKey("DobavljacId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ePrrodaja.Service.Database.Korisnici", "Korisnik")
                        .WithMany("Ulazis")
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ePrrodaja.Service.Database.Skladistum", "Skladiste")
                        .WithMany("Ulazis")
                        .HasForeignKey("SkladisteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dobavljac");

                    b.Navigation("Korisnik");

                    b.Navigation("Skladiste");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.Dobavljaci", b =>
                {
                    b.Navigation("Ulazis");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.Izlazi", b =>
                {
                    b.Navigation("IzlazStavkes");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.JediniceMjere", b =>
                {
                    b.Navigation("Proizvodis");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.Korisnici", b =>
                {
                    b.Navigation("Izlazis");

                    b.Navigation("KorisniciUloges");

                    b.Navigation("Ulazis");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.Kupci", b =>
                {
                    b.Navigation("Narudzbes");

                    b.Navigation("Ocjenes");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.Narudzbe", b =>
                {
                    b.Navigation("Izlazis");

                    b.Navigation("NarudzbaStavkes");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.Proizvodi", b =>
                {
                    b.Navigation("IzlazStavkes");

                    b.Navigation("NarudzbaStavkes");

                    b.Navigation("Ocjenes");

                    b.Navigation("UlazStavkes");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.Skladistum", b =>
                {
                    b.Navigation("Izlazis");

                    b.Navigation("Ulazis");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.Ulazi", b =>
                {
                    b.Navigation("UlazStavkes");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.Uloge", b =>
                {
                    b.Navigation("KorisniciUloges");
                });

            modelBuilder.Entity("ePrrodaja.Service.Database.VrsteProizvodum", b =>
                {
                    b.Navigation("Proizvodis");
                });
#pragma warning restore 612, 618
        }
    }
}
