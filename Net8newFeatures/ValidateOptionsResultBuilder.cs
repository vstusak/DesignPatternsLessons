using Microsoft.Extensions.Options;
internal class Temp()
{

    public void doSomething()
    {
        ValidateOptionsResultBuilder builder = new();
        builder.AddError("Error: invalid operation code");
        builder.AddResult(ValidateOptionsResult.Fail("Invalid request parameters"));
        builder.AddError("Malformed link", "Url");

// Build ValidateOptionsResult object has accumulating multiple errors.
        ValidateOptionsResult result = builder.Build();

        if (result.Failed)
        {
            foreach (var resultFailure in result.Failures)
            {
                Console.WriteLine(resultFailure);
            }
        }

// Reset the builder to allow using it in new validation operation.
        builder.Clear();
    }
}