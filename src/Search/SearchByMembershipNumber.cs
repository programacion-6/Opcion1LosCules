namespace Opcion1LosCules;
public class SearchByMembershipNumber : IPatronSearchStrategy
{
    public List<Patron> Search(string membershipNumber, List<Patron> patrons)
    {
        return patrons.Where(patron => patron.MembershipNumber.ToString().Equals(membershipNumber)).ToList();
    }
}