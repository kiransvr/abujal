using AbujalWebsite.Models;

namespace AbujalWebsite.Services;

// In-memory content store; swap for a database-backed repository later without changing callers.
public class SiteDataService : ISiteDataService
{
    private readonly List<Service> _services;
    private readonly List<Project> _projects;
    private readonly List<Insight> _insights;

    public SiteDataService()
    {
        _services = new List<Service>
        {
            new()
            {
                Slug = "research-evaluation",
                Title = "Research & Evaluation",
                Icon = "bi-search",
                Summary = "Evidence-based decision making",
                Description = "We design and conduct rigorous research, baseline studies, and impact evaluations that help institutions make evidence-based decisions across development, financial and social programs.",
                KeyOfferings = new() { "Baseline & endline surveys", "Impact & outcome evaluations", "Data collection & analysis", "Policy research" }
            },
            new()
            {
                Slug = "training-capacity-building",
                Title = "Training & Capacity Building",
                Icon = "bi-mortarboard",
                Summary = "Knowledge for better performance",
                Description = "We deliver customized training programs and capacity-building initiatives that strengthen the skills and performance of staff across government, financial and development institutions.",
                KeyOfferings = new() { "Customized training curricula", "Institutional capacity assessments", "Workshops & professional development", "Training-of-trainers programs" }
            },
            new()
            {
                Slug = "business-management-consulting",
                Title = "Business & Management Consulting",
                Icon = "bi-people",
                Summary = "Strategy and organizational growth",
                Description = "We support organizations to strengthen their strategy, governance and operations, helping leadership teams plan and execute sustainable growth.",
                KeyOfferings = new() { "Strategic planning", "Organizational restructuring", "Business process improvement", "Governance advisory" }
            },
            new()
            {
                Slug = "financial-inclusion-rural-finance",
                Title = "Financial Inclusion & Rural Finance",
                Icon = "bi-cash-coin",
                Summary = "Microfinance, SACCOs and financial literacy",
                Description = "We work with microfinance institutions, SACCOs and rural finance actors to expand access to finance and improve financial literacy among underserved communities.",
                KeyOfferings = new() { "Microfinance institution advisory", "SACCO strengthening", "Financial literacy programs", "Rural finance product design" }
            },
            new()
            {
                Slug = "institutional-development",
                Title = "Institutional Development",
                Icon = "bi-building",
                Summary = "Stronger systems for greater impact",
                Description = "We help institutions build stronger systems, structures and processes that increase efficiency, accountability and long-term impact.",
                KeyOfferings = new() { "Systems & process design", "Organizational development", "Monitoring & evaluation systems", "Change management" }
            },
            new()
            {
                Slug = "knowledge-management",
                Title = "Knowledge Management",
                Icon = "bi-lightbulb",
                Summary = "Research, publications and learning products",
                Description = "We create and curate knowledge products, publications and learning resources that capture lessons learned and inform future practice.",
                KeyOfferings = new() { "Publications & reports", "Learning briefs & case studies", "Knowledge sharing platforms", "Documentation of best practice" }
            }
        };

        _projects = new List<Project>
        {
            new()
            {
                Slug = "financial-literacy-and-inclusion-program",
                Title = "Financial Literacy and Inclusion Program",
                Category = "Development",
                Country = "Ethiopia",
                Year = 2023,
                ImageUrl = "/images/projects/project-1.png",
                Summary = "Capacity building and awareness creation for rural communities in Ethiopia.",
                Body = "This program builds the financial capability of rural communities through community-level financial literacy sessions, awareness campaigns and linkage support to formal financial institutions."
            },
            new()
            {
                Slug = "data-collection-and-impact-assessment",
                Title = "Data Collection and Impact Assessment",
                Category = "Research",
                Country = "Ethiopia",
                Year = 2023,
                ImageUrl = "/images/projects/project-2.png",
                Summary = "Evidence-based research to inform policy and program decisions.",
                Body = "A large-scale data collection and impact assessment exercise designed to give policymakers and program managers reliable evidence to guide decision-making."
            },
            new()
            {
                Slug = "training-on-microfinance-innovations",
                Title = "Training on Microfinance Innovations",
                Category = "Training",
                Country = "Ethiopia",
                Year = 2023,
                ImageUrl = "/images/projects/project-3.png",
                Summary = "Professional development for MFI staff and regulatory institutions.",
                Body = "A structured professional development program covering emerging trends and innovations in microfinance, delivered to staff of microfinance institutions and regulators."
            }
        };

        _insights = new List<Insight>
        {
            new()
            {
                Slug = "financial-inclusion-trends-ethiopia",
                Title = "Financial Inclusion Trends in Ethiopia",
                Type = "Report",
                PublishDate = new DateOnly(2024, 3, 12),
                Summary = "An overview of financial inclusion progress, gaps and opportunities across Ethiopia."
            },
            new()
            {
                Slug = "capacity-building-lessons-learned",
                Title = "Capacity Building: Lessons Learned",
                Type = "Article",
                PublishDate = new DateOnly(2024, 1, 20),
                Summary = "Key lessons from five years of institutional capacity-building engagements."
            }
        };
    }

    public IReadOnlyList<Service> GetServices() => _services;
    public Service? GetServiceBySlug(string slug) => _services.FirstOrDefault(s => s.Slug == slug);

    public IReadOnlyList<Project> GetProjects() => _projects;
    public Project? GetProjectBySlug(string slug) => _projects.FirstOrDefault(p => p.Slug == slug);

    public IReadOnlyList<Insight> GetInsights() => _insights;
    public Insight? GetInsightBySlug(string slug) => _insights.FirstOrDefault(i => i.Slug == slug);
}
