namespace Mvc5DemoAppLearn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateMembershipTypes1 : DbMigration
    {
        public override void Up()
        {
            Sql("update  MembershipTypes set MembershipName='Pay as you go.' where ID=1");
            Sql("update  MembershipTypes set MembershipName='Monthly.' where ID=2");
            Sql("update  MembershipTypes set MembershipName='Quarterly.' where ID=3");
            Sql("update  MembershipTypes set MembershipName='Annualy.' where ID=4");
        }

        public override void Down()
        {
        }
    }
}
