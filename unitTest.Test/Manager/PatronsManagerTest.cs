using Moq;
namespace Opcion1LosCules.Tests
{
    public class PatronsManagerTests
    {
        private readonly PatronsManager _patronsManager;

        public PatronsManagerTests()
        {
            _patronsManager = new PatronsManager(new Database());
        }

        [Fact]
        public async void AddPatron_ShouldAddValidPatronToList()
        {
            var patron = new Patron("Sandra", 45845, "sandra@example.com");

            await _patronsManager.AddPatron(patron);

            Assert.Contains(patron, await _patronsManager.GetAllPatrons());
        }

        [Fact]
        public async void AddPatron_ShouldNotAddDuplicatePatron()
        {
            var patron = new Patron("Jane Doe", 12345, "jane@example.com");

            await _patronsManager.AddPatron(patron);
            await _patronsManager.AddPatron(patron);

            Assert.Single(await _patronsManager.GetAllPatrons());
        }

        [Fact]
        public async void UpdatePatron_ShouldUpdatePatronDetails_WhenPatronExists()
        {
            var patron = new Patron("Alice Johnson", 12345, "alice@example.com");
            await _patronsManager.AddPatron(patron);

            patron.Name = "Alice Doe";
            patron.ContactDetails = "alice.doe@example.com";
            await _patronsManager.UpdatePatron(patron.Id.ToString(), patron);

            var updatedPatron = (await _patronsManager.GetAllPatrons()).FirstOrDefault(p => p.MembershipNumber == 12345);
            Assert.NotNull(updatedPatron);
            Assert.Equal("Alice Doe", updatedPatron.Name);
            Assert.Equal("alice.doe@example.com", updatedPatron.ContactDetails);
        }

        [Fact]
        public async void UpdatePatron_ShouldNotUpdateNonExistentPatron()
        {
            var patron = new Patron("Bob Johnson", 54321, "bob@example.com");

            await _patronsManager.UpdatePatron(patron.Id.ToString(), patron);

            Assert.Empty(await _patronsManager.GetAllPatrons());
        }

        [Fact]
        public async void RemovePatron_ShouldRemovePatronFromList()
        {
            var patron = new Patron("John Smith", 11111, "john.smith@example.com");
            await _patronsManager.AddPatron(patron);

            await _patronsManager.RemovePatron(patron.Id.ToString());

            Assert.DoesNotContain(patron, await _patronsManager.GetAllPatrons());
        }

        [Fact]
        public async void RemovePatron_ShouldDoNothing_WhenPatronDoesNotExist()
        {
            var patron = new Patron("Jane Smith", 11111, "jane.smith@example.com");

            await _patronsManager.RemovePatron(patron.Id.ToString());

            Assert.Empty(await _patronsManager.GetAllPatrons());
        }

    }

}
