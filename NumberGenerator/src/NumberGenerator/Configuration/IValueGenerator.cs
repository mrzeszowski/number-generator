using NumberGenerator.Externals;

namespace NumberGenerator.Configuration;

public interface IValueGenerator
{
    SupportedTagType Type { get; }
    string GetValue();
}

public class MonthValueGenerator : IValueGenerator
{
    public SupportedTagType Type => SupportedTagType.Month;
    public string GetValue() => DateTime.Now.Month.ToString();
}

public class YearValueGenerator : IValueGenerator
{
    public SupportedTagType Type => SupportedTagType.Year;
    public string GetValue() => DateTime.Now.Year.ToString();
}

public class SequenceValueGenerator : IValueGenerator
{
    private readonly ISequenceProvider _sequenceProvider;

    public SequenceValueGenerator(ISequenceProvider sequenceProvider) => _sequenceProvider = sequenceProvider;

    public SupportedTagType Type => SupportedTagType.Sequence;
    public string GetValue() => _sequenceProvider.Next().ToString();
}

public class DemoSuffixValueGenerator : IValueGenerator
{
    private readonly IConfiguration _configuration;

    public DemoSuffixValueGenerator(IConfiguration configuration) => _configuration = configuration;

    public SupportedTagType Type => SupportedTagType.Demo;
    public string GetValue() => _configuration.IsDemo() ? "DEMO/" : "";
}

public class AuditValueGenerator : IValueGenerator
{
    private readonly ISession _session;

    public AuditValueGenerator(ISession session) => _session = session;

    public SupportedTagType Type => SupportedTagType.Audit;
    public string GetValue() => _session.IsAudit() ? "/AUDIT" : "";
}
