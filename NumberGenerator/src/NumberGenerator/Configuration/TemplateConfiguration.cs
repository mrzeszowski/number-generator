namespace NumberGenerator.Configuration;

public class TemplateConfiguration
{
    public string Template { get; }
    public IReadOnlyCollection<TemplateTag> Tags { get; }

    public TemplateConfiguration(string template, IReadOnlyCollection<TemplateTag> tags)
    {
        AssertSupportedTags(template, tags);
        Template = template;
        Tags = tags;
    }

    private void AssertSupportedTags(string template, IReadOnlyCollection<TemplateTag> tags)
    {
        // todo
    }
}

public record TemplateTag(string Tag, SupportedTagType Type);