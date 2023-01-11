using NumberGenerator.Configuration;

namespace NumberGenerator;

public class NumberGenerator
{
    private readonly IEnumerable<IValueGenerator> _valueGenerators;

    public NumberGenerator(IEnumerable<IValueGenerator> valueGenerators) => _valueGenerators = valueGenerators; // registered in DI

    public string GetNext(string type, TemplateConfiguration configuration)
    {
        var value = configuration.Template;
        foreach (var templateTag in configuration.Tags)
        {
            if (templateTag.Type == SupportedTagType.Type) 
                value = value.Replace(templateTag.Tag, type);
            else
            {
                var valueGenerator = GetValueGenerator(templateTag);
                value = value.Replace(templateTag.Tag, valueGenerator.GetValue());
            }
        }

        return value;
    }

    private IValueGenerator GetValueGenerator(TemplateTag templateTag) 
        => _valueGenerators.Single(x => x.Type == templateTag.Type);
}