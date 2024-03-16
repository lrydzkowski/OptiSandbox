using EPiServer.Validation;
using OptiSandbox.Models.Pages;

namespace OptiSandbox.Business.Validators;

public class CustomFieldsPageValidator : IContentSaveValidate<CustomFieldsPage>
{
    public IEnumerable<ValidationError> Validate(CustomFieldsPage instance, ContentSaveValidationContext context)
    {
        List<ValidationError> validationErrors = new();
        string valueToFind = "Value2";
        if (instance.SingleValue?.Equals(valueToFind, StringComparison.InvariantCultureIgnoreCase) == true
            && instance.MultipleValues?.Count > 0
            && instance.MultipleValues[0].Contains(valueToFind, StringComparison.InvariantCultureIgnoreCase))
        {
            validationErrors.Add(
                new ValidationError
                {
                    Severity = ValidationErrorSeverity.Error,
                    ErrorMessage = "Wrong values :)",
                    RelatedProperties = new List<string>
                        { nameof(instance.SingleValue), nameof(instance.MultipleValues) }
                }
            );
        }

        return validationErrors;
    }
}
