using ECommerce.Brand;
using ECommerce.Persistence;
using Microsoft.Extensions.Time.Testing;

namespace ECommerce.UnitTests.Persistence;

public class EfRepositoryTests
{
    private readonly FakeTimeProvider _clock = new(DateTimeOffset.UtcNow);

    [Fact]
    public async Task Add_and_save_then_get_by_id()
    {
        await using var context = PersistenceTestContext.Create(_clock);
        var repository = new EfRepository<DefBrand>(context);

        var brand = new DefBrand { BrandName = "Acme" };
        repository.Add(brand);
        await context.SaveChangesAsync(TestContext.Current.CancellationToken);

        var found = await repository.GetByIdAsync(brand.Id, TestContext.Current.CancellationToken);
        found.ShouldNotBeNull().BrandName.ShouldBe("Acme");
    }

    [Fact]
    public async Task List_count_and_any_apply_predicate()
    {
        await using var context = PersistenceTestContext.Create(_clock);
        var repository = new EfRepository<DefBrand>(context);
        repository.Add(new DefBrand { BrandName = "Acme" });
        repository.Add(new DefBrand { BrandName = "Globex" });
        repository.Add(new DefBrand { BrandName = "Acme Outdoor" });
        await context.SaveChangesAsync(TestContext.Current.CancellationToken);

        var ct = TestContext.Current.CancellationToken;
        (await repository.ListAsync(b => b.BrandName.StartsWith("Acme"), ct)).Count.ShouldBe(2);
        (await repository.CountAsync(cancellationToken: ct)).ShouldBe(3);
        (await repository.AnyAsync(b => b.BrandName == "Globex", ct)).ShouldBeTrue();
        (await repository.FirstOrDefaultAsync(b => b.BrandName == "Initech", ct)).ShouldBeNull();
    }
}
