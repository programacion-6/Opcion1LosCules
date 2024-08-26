namespace Opcion1LosCules.Tests
{
    public class PatronTests
    {
        [Fact]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            string name = "John Doe";
            int membershipNumber = 12345;
            string contactDetails = "johndoe@example.com";

            Patron patron = new Patron(name, membershipNumber, contactDetails);

            Assert.Equal(name, patron.Name);
            Assert.Equal(membershipNumber, patron.MembershipNumber);
            Assert.Equal(contactDetails, patron.ContactDetails);
            Assert.Empty(patron.BorrowedBooks);
            Assert.Empty(patron.HistoryBorrowedBooks);
        }

        [Fact]
        public void NameProperty_ShouldGetAndSetCorrectly()
        {
            string initialName = "Jane Smith";
            string updatedName = "Jane Doe";
            Patron patron = new Patron(initialName, 67890, "janedoe@example.com");

            patron.Name = updatedName;

            Assert.Equal(updatedName, patron.Name);
        }

        [Fact]
        public void MembershipNumberProperty_ShouldGetAndSetCorrectly()
        {
            int initialMembershipNumber = 67890;
            int updatedMembershipNumber = 54321;
            Patron patron = new Patron("Alice Johnson", initialMembershipNumber, "alicejohnson@example.com");

            patron.MembershipNumber = updatedMembershipNumber;

            Assert.Equal(updatedMembershipNumber, patron.MembershipNumber);
        }

        [Fact]
        public void ContactDetailsProperty_ShouldGetAndSetCorrectly()
        {
            string initialContactDetails = "alicejohnson@example.com";
            string updatedContactDetails = "alicej@example.com";
            Patron patron = new Patron("Alice Johnson", 67890, initialContactDetails);

            patron.ContactDetails = updatedContactDetails;

            Assert.Equal(updatedContactDetails, patron.ContactDetails);
        }

        [Fact]
        public void BorrowedBooks_ShouldBeInitiallyEmpty()
        {
            Patron patron = new Patron("Tom Brown", 11111, "tombrown@example.com");

            var borrowedBooks = patron.BorrowedBooks;

            Assert.NotNull(borrowedBooks);
            Assert.Empty(borrowedBooks);
        }

        [Fact]
        public void HistoryBorrowedBooks_ShouldBeInitiallyEmpty()
        {
            Patron patron = new Patron("Emily Davis", 22222, "emilydavis@example.com");

            var historyBorrowedBooks = patron.HistoryBorrowedBooks;

            Assert.NotNull(historyBorrowedBooks);
            Assert.Empty(historyBorrowedBooks);
        }
    }
}
