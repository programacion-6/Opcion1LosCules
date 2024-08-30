namespace Opcion1LosCules;

public class SearchByMembershipNumber : ISearchStrategy<Patron>
{
    public int MembershipNumber;

    public SearchByMembershipNumber(int membershipNumber)
    {
        MembershipNumber = membershipNumber;
    }

    public List<Patron> Search(List<Patron> patrons)
    {
        return patrons
            .Where(patron => patron.MembershipNumber.Equals(MembershipNumber))
            .ToList();
    }
}
