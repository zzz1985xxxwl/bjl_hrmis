using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;


namespace SEP.HRMIS.Presenter
{
    public interface IAddFamilyMemberView
    {
        string Title { get; set;}

        string Name{ get; set;}
        string NameMessage{ get; set;}
        string Relationship{ get; set;}
        string RelationshipMessage{ get; set;}
        string Birthday { get; set;}
        string BirthdayMessage { get; set;}
        string Age { get; set;}
        string AgeMessage{ get; set;}
        string Company{ get; set;}
        string Remark{ get; set;}

        string Id { get; set;}

    }
}
