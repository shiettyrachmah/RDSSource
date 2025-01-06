using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiSiram.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "activites",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    reg_no = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    last_updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activites", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "activity_logs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    log_name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: false),
                    subject_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    subject_id = table.Column<long>(type: "bigint", maxLength: 20, nullable: true),
                    causer_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    causer_id = table.Column<long>(type: "bigint", maxLength: 20, nullable: true),
                    events = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    properties = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    batch_uuid = table.Column<Guid>(type: "uuid", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    deleted_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activity_logs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "app_settings",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    key = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    deleted_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_settings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "demographic",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    reg_no = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    nik = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    full_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    place_of_birth = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: false),
                    gender = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    blood_type = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    rt = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    rw = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    village = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    sub_district = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    regency = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    province = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    religion = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    maritalStatus = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    occupation = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    nationality = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    foto = table.Column<byte[]>(type: "bytea", nullable: true),
                    signature = table.Column<byte[]>(type: "bytea", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    last_updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_demographic", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "detail_activities",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    reg_no = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detail_activities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "divisi",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    divisi_id = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    komando_id = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    nama_divisi = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    deskripsi = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    last_updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_divisi", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "groups",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    group_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    last_updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "jabatan",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    jabatan_id = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    nama_jabatan = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    tingkat_jabatan = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    last_updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jabatan", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "komando",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    komando_id = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    nama_komando = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    jenis_komando = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    wilayah = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    deskripsi = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    last_updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_komando", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "menus",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    menu_id = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    menu_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    siite_url = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    icon = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    is_parent = table.Column<int>(type: "integer", nullable: true),
                    parent_seq = table.Column<int>(type: "integer", nullable: true),
                    child_seq = table.Column<int>(type: "integer", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    last_updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ms_fields",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    key = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    value = table.Column<string>(type: "text", nullable: true),
                    text = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    last_updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ms_fields", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pangkat",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    divisi_id = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    kategori = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    sub_kategori = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    pangkat_id = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    kd_pangkat = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    nama_pangkat = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    herarki = table.Column<int>(type: "integer", nullable: true),
                    parent_id = table.Column<int>(type: "integer", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    last_updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pangkat", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    permissions_id = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    roles_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    guard_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    last_updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "personel",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    personel_id = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    user_id = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    upline_id = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    nrp = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    divisi_id = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    pangkat_id = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    jabatan_id = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    nik = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true),
                    nama = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    tempat_lahir = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    tanggal_lahir = table.Column<DateOnly>(type: "date", nullable: false),
                    jenis_kelamin = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    golongan_darah = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    alamat = table.Column<string>(type: "text", nullable: true),
                    rt = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    rw = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    desa = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    kecamatan = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    kabupaten = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    provinsi = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    agama = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    status_perkawinan = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    pekerjaan = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    kewarganegaraan = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    foto = table.Column<byte[]>(type: "bytea", nullable: true),
                    signature = table.Column<byte[]>(type: "bytea", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    last_updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role_has_permissions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    permissions_id = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    roles_id = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    last_updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_has_permissions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roles_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    guard_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    last_updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_groups",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    group_id = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    last_updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_groups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    last_updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    user_id = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    first_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    last_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    telepon = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    personel_id = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    last_updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activites");

            migrationBuilder.DropTable(
                name: "activity_logs");

            migrationBuilder.DropTable(
                name: "app_settings");

            migrationBuilder.DropTable(
                name: "demographic");

            migrationBuilder.DropTable(
                name: "detail_activities");

            migrationBuilder.DropTable(
                name: "divisi");

            migrationBuilder.DropTable(
                name: "groups");

            migrationBuilder.DropTable(
                name: "jabatan");

            migrationBuilder.DropTable(
                name: "komando");

            migrationBuilder.DropTable(
                name: "menus");

            migrationBuilder.DropTable(
                name: "ms_fields");

            migrationBuilder.DropTable(
                name: "pangkat");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "personel");

            migrationBuilder.DropTable(
                name: "role_has_permissions");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "user_groups");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
