namespace Linkdev.Intern.EQuiz.Data.EntityFrameWork
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Linkdev.Intern.EQuiz.Data.Domain;

    public partial class EQuizContext : DbContext
    {
        public EQuizContext()
            : base("name=EQuizContext")
        {
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employees_Questions_Templates> Employees_Questions_Templates { get; set; }
        public virtual DbSet<Employees_Templates> Employees_Templates { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Questions_Quizes> Questions_Quizes { get; set; }
        public virtual DbSet<Questions_Templates> Questions_Templates { get; set; }
        public virtual DbSet<Quize> Quizes { get; set; }
        public virtual DbSet<Template> Templates { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                .HasMany(e => e.Employees_Questions_Templates)
                .WithRequired(e => e.Answer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Employees_Questions_Templates)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Templates)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Employees_Templates)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Answers)
                .WithRequired(e => e.Question)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Employees_Questions_Templates)
                .WithRequired(e => e.Question)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Questions_Quizes)
                .WithRequired(e => e.Question)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Questions_Templates)
                .WithRequired(e => e.Question)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quize>()
                .HasMany(e => e.Questions_Quizes)
                .WithRequired(e => e.Quiz)
                .HasForeignKey(e => e.QuizID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quize>()
                .HasMany(e => e.Templates)
                .WithRequired(e => e.Quiz)
                .HasForeignKey(e => e.QuizID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Template>()
                .HasMany(e => e.Employees_Questions_Templates)
                .WithRequired(e => e.Template)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Template>()
                .HasMany(e => e.Employees_Templates)
                .WithRequired(e => e.Template)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Template>()
                .HasMany(e => e.Questions_Templates)
                .WithRequired(e => e.Template)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Topic>()
                .HasMany(e => e.Questions)
                .WithRequired(e => e.Topic)
                .WillCascadeOnDelete(false);
        }
    }
}
