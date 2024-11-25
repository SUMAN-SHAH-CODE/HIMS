using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PatientLibrary;
using System.Reflection.Metadata;

namespace RepositoryPatient
{
    public class PatientDbContext :DbContext
    {
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //configuration
            optionsBuilder.UseSqlServer("");
        }*/

        //The DbContextOptions<PatientDbContext> parameter is used to" configure the database connection."
        public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options) { }
       //constructor that takes a DbContextOptions<PatientDbContext> parameter.
        //This constructor is used to initialize the PatientDbContext instance with the necessary options for connecting to the database.
        // In this case, the options parameter is passed to the base DbContext constructor using the : base(options) syntax.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //mapping code
            modelBuilder.Entity<Patient>().ToTable("tblPatient");//it will mapping between your .NET classes and the database tables.
    }
    public DbSet<Patient> Patients { get; set; }   //The Patients property is a DbSet<Patient> that represents a collection of Patient entities.
                                                   //This property is used to interact with the "tblPatient" table in the database.
    }

}
//1.create class named as PatientDbContext which inherit DbContext and gies option to "override of ONCREATE AND ON CONFIGURE"
//2.constructor which have DbContextOptions oftype <PatientDbContext> and parameter is option =>Connect to database
//3.ONCREATE la mapped to table("table_name")
//4.DbSet oftype<Patient> obj Patients    =>"interact to table of database
//after that make connection string in app.json
//-------------------
//use this connection string in program.cs file and also inject PatientDbcontext class so we can use in any place in our application
// go to controller use the ctor which (PatientDbContext  dbContext) 
//_______//we inject patientDbcontext from program.cs
//we can assign a private field and use dbContext 

