using Moq;
namespace Opcion1LosCules.Tests
{
    public class PatronsManagerTests
    {
        private readonly PatronsManager _patronsManager;
        private readonly Mock<IStorage<Patron>> _mockPatronStorage;

        public PatronsManagerTests()
        {
            _mockPatronStorage = new Mock<IStorage<Patron>>();
            _mockPatronStorage.Setup(x => x.Load()).Returns(new List<Patron>());
            _patronsManager = new PatronsManager(_mockPatronStorage.Object);
        }

        [Fact]
        public void AddPatron_ShouldAddValidPatronToList()
        {
            var patron = new Patron("Sandra", 45845, "sandra@example.com");

            _patronsManager.AddItem(patron);

            Assert.Contains(patron, _patronsManager.Items);
        }

        [Fact]
        public void AddPatron_ShouldNotAddDuplicatePatron()
        {
            var patron = new Patron("Jane Doe", 12345, "jane@example.com");
            _patronsManager.AddItem(patron);
       
            _patronsManager.AddItem(patron);

            Assert.Single(_patronsManager.Items);
        }

        [Fact]
        public void UpdatePatron_ShouldUpdatePatronDetails_WhenPatronExists()
        {
            var patron = new Patron("Alice Johnson", 12345, "alice@example.com");
            _patronsManager.AddItem(patron);

            patron.Name = "Alice Doe";
            patron.ContactDetails = "alice.doe@example.com";
            _patronsManager.UpdateItem(patron);

            var updatedPatron = _patronsManager.Items.FirstOrDefault(p => p.MembershipNumber == 12345);
            Assert.NotNull(updatedPatron);
            Assert.Equal("Alice Doe", updatedPatron.Name);
            Assert.Equal("alice.doe@example.com", updatedPatron.ContactDetails);
        }

        [Fact]
        public void UpdatePatron_ShouldNotUpdateNonExistentPatron()
        {
            var patron = new Patron("Bob Johnson", 54321, "bob@example.com");

            _patronsManager.UpdateItem(patron);

            Assert.Empty(_patronsManager.Items);
        }

        [Fact]
        public void RemovePatron_ShouldRemovePatronFromList()
        {
            var patron = new Patron("John Smith", 11111, "john.smith@example.com");
            _patronsManager.AddItem(patron);

            _patronsManager.RemoveItem(patron);

            Assert.DoesNotContain(patron, _patronsManager.Items);
        }

        [Fact]
        public void RemovePatron_ShouldDoNothing_WhenPatronDoesNotExist()
        {
            var patron = new Patron("Jane Smith", 11111, "jane.smith@example.com");

            _patronsManager.RemoveItem(patron);

            Assert.Empty(_patronsManager.Items);
        }

    }

}
