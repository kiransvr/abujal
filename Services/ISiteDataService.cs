using AbujalWebsite.Models;

namespace AbujalWebsite.Services;

public interface ISiteDataService
{
    IReadOnlyList<Service> GetServices();
    Service? GetServiceBySlug(string slug);

    IReadOnlyList<Project> GetProjects();
    Project? GetProjectBySlug(string slug);

    IReadOnlyList<Insight> GetInsights();
    Insight? GetInsightBySlug(string slug);
}
