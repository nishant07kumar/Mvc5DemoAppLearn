namespace Mvc5DemoAppLearn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres(GenreType) values ('Comedy')");
            Sql("Insert into Genres(GenreType) values ('Action')");
            Sql("Insert into Genres(GenreType) values ('Romance')");
            Sql("Insert into Genres(GenreType) values ('Drama')");
        }

        public override void Down()
        {
        }
    }
}
